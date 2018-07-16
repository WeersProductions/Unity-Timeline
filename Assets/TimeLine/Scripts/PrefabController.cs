using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabController : MonoBehaviour {
	private static PrefabController _instance;

	[SerializeField]
	private ClipDrag _clipDragPrefab;

	[SerializeField]
	private Canvas _canvas;

	private ClipDrag _currentDragClip;

	private void Awake() {
		_instance = this;
	}

	public static ClipDrag ClipDragPrefab {
		get {
			return _instance._clipDragPrefab;
		}
	}

	public static Canvas CanvasInstance {
		get {
			return _instance._canvas;
		}
	}

	public static ClipDrag ClipDragCurrent {
		get {
			return _instance._currentDragClip;
		}
		set {
			if(_instance._currentDragClip && value != _instance._currentDragClip) {
				Destroy(_instance._currentDragClip.gameObject);
			}
			_instance._currentDragClip = value;
		}
	}
}
