using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipData {

	private Texture2D _thumbnail;
	private string _title;
	private float _duration;

	public Texture2D Thumbnail {
		get {
			return _thumbnail;
		}
		set{
			_thumbnail = value;
		}
	}

	public Sprite ThumbnailToSprite() {
		return Sprite.Create(Thumbnail, new Rect(0,0,Thumbnail.width, Thumbnail.height), new Vector2(0.5f,0.5f));
	}

	public string Title {
		get {
			return _title;
		} 
		set {
			_title = value;
		}
	}

	public float Duration {
		get {
			return _duration;
		}
		set {
			_duration = value;
		}
	}
}
