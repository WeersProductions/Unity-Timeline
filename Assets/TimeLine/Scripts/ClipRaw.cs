using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// A clip object when it cannot be edited, E.G. when showing in the list of raw recordings
/// </summary>
public class ClipRaw : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IClipHandler
{
	private ClipData _clipData;

	public Texture2D _icon;

	private void Awake() {
		ClipData clipData = new ClipData();
		clipData.Title = "A title";
		clipData.Thumbnail = _icon;
		clipData.Duration = 100;
		SetClip(clipData);
	}

	public void SetClip(ClipData ClipData) {
		_clipData = ClipData;
	}

    public void OnBeginDrag(PointerEventData eventData)
    {
        PrefabController.ClipDragCurrent = Instantiate(PrefabController.ClipDragPrefab);
		PrefabController.ClipDragCurrent.transform.SetParent(PrefabController.CanvasInstance.transform, false);
		PrefabController.ClipDragCurrent.SetData(_clipData);
    }

    public void OnDrag(PointerEventData eventData)
    {
		PrefabController.ClipDragCurrent.SetPosition(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(PrefabController.ClipDragCurrent.gameObject);
    }

    public ClipData GetClip()
    {
        return _clipData;
    }
}
