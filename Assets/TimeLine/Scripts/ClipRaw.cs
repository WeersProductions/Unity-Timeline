using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// A clip object when it cannot be edited, E.G. when showing in the list of raw recordings
/// </summary>
public class ClipRaw : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IClipHandler
{
	[SerializeField]
	private Canvas _canvas;

	private ClipData _clipData;

	[SerializeField]
	private ClipDrag _clipDragPrefab;

	private ClipDrag _clipDrag;

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
        _clipDrag = Instantiate(_clipDragPrefab);
		_clipDrag.transform.SetParent(_canvas.transform, false);
		_clipDrag.SetData(_clipData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _clipDrag.SetPosition(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(_clipDrag.gameObject);
    }

    public ClipData GetClip()
    {
        return _clipData;
    }
}
