using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timestamp : MonoBehaviour {
	[SerializeField]
	private Image _image;
	private RectTransform _rectTransform;

	private void Awake() {
		_rectTransform = this.GetComponent<RectTransform>();
	}

	public void SetPosition(float xPosition) {
		_rectTransform.position = new Vector3(xPosition, _rectTransform.position.y, _rectTransform.position.z);
	}

	public void SetSelected(bool selected) {
		if(selected) {
			_image.color = Color.yellow;
		} else {
			_image.color = Color.red;
		}
	}
}
