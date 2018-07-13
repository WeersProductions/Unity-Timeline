using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape)) {
			Debug.Log("escape");
			// TODO: deselect the current target (E.G. dragging)
			EventSystem.current.SetSelectedGameObject(null);
		}
	}
}
