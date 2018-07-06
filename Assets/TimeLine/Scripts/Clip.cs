using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Clip : MonoBehaviour, IDragOwner {

	[System.Serializable]
	public class DragEvent : UnityEvent<float> { }

	[SerializeField]
	private DragEvent _onDragLeft;
	[SerializeField]
	private DragEvent _onDragRight;
	[SerializeField]
	private DragEvent _onDragTop;
	[SerializeField]
	private DragEvent _onDragBottom;

	private RectTransform _rectTransform;

	private ClipData _clipData;

	private void Awake() {
		_rectTransform = this.GetComponent<RectTransform>();
		DragHandler[] dragHandlers = this.GetComponentsInChildren<DragHandler>();
		for(int i = 0; i < dragHandlers.Length; i++) {
			dragHandlers[i].SetOwner(this);
		}
	}

	public void SetClip(ClipData clipData) {
		this._clipData = clipData;
		SetWidth(clipData.Duration);
	}

	public void DragLeft(PointerEventData eventData) {
		float amount = eventData.delta.x;
		if(_onDragLeft != null) {
			_onDragLeft.Invoke(amount);
		}
		ResizeClip(DragHandler.Direction.Left, eventData);
	}

	public void DragRight(PointerEventData eventData) {
		float amount = eventData.delta.x;
		if(_onDragRight != null) {
			_onDragRight.Invoke(amount);
		}
		ResizeClip(DragHandler.Direction.Right, eventData);
	}

	public void DragTop(PointerEventData eventData) {
		float amount = eventData.delta.y;
		if(_onDragTop != null) {
			_onDragTop.Invoke(amount);
		}
		ResizeClip(DragHandler.Direction.Top, eventData);
	}

	public void DragBottom(PointerEventData eventData) {
		float amount = eventData.delta.y;
		if(_onDragBottom != null) {
			_onDragBottom.Invoke(amount);
		}
		ResizeClip(DragHandler.Direction.Bottom, eventData);
	}

	private void ResizeClip(DragHandler.Direction direction, PointerEventData eventData) {
		Vector2 delta = eventData.delta;
		Vector2 difference = Vector2.zero;

		int multiplier = 1;

		switch (direction)
		{
			case DragHandler.Direction.Bottom: {
				difference =  new Vector2 (0, -delta.y);
				multiplier = -1;
				break;
			}
			case DragHandler.Direction.Right: {
				difference =  new Vector2 (delta.x, 0);
				break;
			}
			case DragHandler.Direction.Left: {
				difference =  new Vector2 (-delta.x, 0);
				multiplier = -1;
				break;
			}
			case DragHandler.Direction.Top: {
				difference =  new Vector2 (0, delta.y);
				break;
			}
		}
		
		_rectTransform.sizeDelta += difference;		
		Vector2 deltaPosition = multiplier * new Vector3(_rectTransform.pivot.x * difference.x, _rectTransform.pivot.y * difference.y, 0);
		_rectTransform.anchoredPosition += deltaPosition;
	}

	public void SetHeight(float height) {
		_rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, height);
	}

	public void SetWidth(float width) {
		_rectTransform.sizeDelta = new Vector2(width, _rectTransform.sizeDelta.y);
	}
}
