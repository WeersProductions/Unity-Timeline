using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A clip object when it is being dragged
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public class ClipDrag : MonoBehaviour {
	[SerializeField]
	private Image _image;
	[SerializeField]
	private Text _text;

	public void SetData(ClipData clipData) {
		_image.sprite = clipData.ThumbnailToSprite();
		_text.text = clipData.Title;
		CanvasGroup canvasGroup = this.GetComponent<CanvasGroup>();
		canvasGroup.blocksRaycasts = false;
	}

	public void SetPosition(Vector3 position) {
		transform.position = position;
	}
}
