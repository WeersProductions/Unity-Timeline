using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Timebar : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler{

	[SerializeField]
	private Clip _clipPrefab;

	private List<Clip> _clips;

	[SerializeField]
	private Image _containerImage;

	private Color normalColor = Color.white;
	private Color highlightColor = Color.yellow;

	private RectTransform _rectTransform;

    public void OnDrop(PointerEventData eventData)
    {
        _containerImage.color = normalColor;

		ClipData clipDrag = GetClipDrag(eventData);
		if(clipDrag != null) {
			Vector3 clipPosition = new Vector3(eventData.position.x, _rectTransform.position.y, _rectTransform.position.z);
			Clip clip = Instantiate(_clipPrefab, clipPosition, Quaternion.identity);
			clip.transform.SetParent(this.transform);
			// clip.transform.position = new Vector2(eventData.position.x, _rectTransform.position.z);
			clip.SetHeight(_rectTransform.rect.height);
			clip.SetClip(clipDrag);
		}
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(GetClipDrag(eventData) != null) {
			_containerImage.color = highlightColor;
		}
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _containerImage.color = normalColor;
    }

    private void Awake() {
		_clips = new List<Clip>();
		_rectTransform = this.GetComponent<RectTransform>();
	}

	private ClipData GetClipDrag(PointerEventData data) {
		GameObject dragObj = data.pointerDrag;
		if(!dragObj || !PrefabController.ClipDragCurrent) {
			return null;
		}

		IClipHandler clipHandler = dragObj.GetComponent<IClipHandler>();

		if(clipHandler == null) {
			return null;
		}

		return clipHandler.GetClip();
	}

	public void MoveTime(float time) {
		for(int i = 0; i < _clips.Count; i++){
			_clips[i].MovePosition(time);
		}
	}
}
