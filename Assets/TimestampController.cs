using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TimestampController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
	/// <summary>
	/// Frame number of the first frame in our current window
	/// </summary>
	private int _startWindow = 0;
	/// <summary>
	/// Frame number of the last frame in our current window
	/// </summary>
	private int _endWindow = 250;

	/// <summary>
	/// Current frame that is selected.
	/// </summary>
	private int _currentFrame = 0;

	private int _minimumDifferenceFrames = 40;

	public class TimeChangeEvent : UnityEvent<float> { }

	[SerializeField]
	private Timestamp _timestamp;

	private RectTransform _rectTransform;

	private void Awake() {
		_rectTransform = GetComponent<RectTransform>();
	}

	private void Start() {
		_timestamp.SetPosition(0);
	}

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        SetTimestamp(eventData.position.x);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
     	SetTimestamp(eventData.position.x);   
    }

	private void SetTimestamp(float position) {
		_timestamp.SetPosition(position);
		_currentFrame = (int)(position/_rectTransform.rect.width * (_endWindow - _startWindow)) + _startWindow;
		if(_currentFrame - _startWindow < _minimumDifferenceFrames) {
			MoveWindow(-(_minimumDifferenceFrames - _currentFrame - _startWindow));
		}
		if(_endWindow - _currentFrame < _minimumDifferenceFrames) {
			MoveWindow(_minimumDifferenceFrames - (_endWindow - _currentFrame));
		}
	}

	public void MoveWindow(int amount) {
		int maxDifference = amount;
		if(amount < 0) {
			maxDifference = Mathf.Min(-_startWindow, amount);
		}
		_startWindow += amount;
		_endWindow += amount;

		SetTimestamp(FrameToPosition(_currentFrame));

		UpdateTexts();
	}

	private float FrameToPosition(int frameNumber, bool clamp = true) {
		float result = ((float)frameNumber - _startWindow) / (_endWindow - _startWindow) * _rectTransform.rect.width;
		if(clamp) {
			return Mathf.Clamp(result, FrameToPosition(_startWindow + _minimumDifferenceFrames, false), FrameToPosition(_endWindow - _minimumDifferenceFrames, false));
		} else {
			return result;
		}
	}

	private void UpdateTexts() {
		Debug.Log(_startWindow);
		Debug.Log(_endWindow);
	}
}
