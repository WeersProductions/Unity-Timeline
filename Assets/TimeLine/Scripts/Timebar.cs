using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Timebar : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler{

	private List<Clip> _clips;

	[SerializeField]
	private Image _containerImage;

	private Color normalColor = Color.white;
	private Color highlightColor = Color.yellow;

    public void OnDrop(PointerEventData eventData)
    {
        _containerImage.color = normalColor;

		ClipData clipDrag = GetClipDrag(eventData);
		if(clipDrag != null) {
			Debug.Log("Dropped a clip!");
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
