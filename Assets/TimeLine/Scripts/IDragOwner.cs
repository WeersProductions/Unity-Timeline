using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IDragOwner {

	void DragLeft(PointerEventData eventData);
	void DragRight(PointerEventData eventData);
	void DragTop(PointerEventData eventData);
	void DragBottom(PointerEventData eventData);
}
