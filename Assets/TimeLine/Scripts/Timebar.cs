using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timebar : MonoBehaviour {

	private List<Clip> _clips;

	private void Awake() {
		_clips = new List<Clip>();
	}
}
