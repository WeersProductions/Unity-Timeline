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
			Clip clip = Instantiate(_clipPrefab, eventData.position, Quaternion.identity);
			clip.transform.SetParent(this.transform);
			clip.transform.position = eventData.position;
			clip.SetHeight(0.2f * _rectTransform.rect.height);
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
		if(!dragObj) {
			return null;
		}

		IClipHandler clipHandler = dragObj.GetComponent<IClipHandler>();

		if(clipHandler == null) {
			return null;
		}

		return clipHandler.GetClip();
	}
}
