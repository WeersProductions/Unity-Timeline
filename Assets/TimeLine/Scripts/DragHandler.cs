using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	private IDragOwner _dragOwner;
	[SerializeField]
	private Direction _direction;
	public enum Direction
	{
		Left,
		Right,
		Top,
		Bottom
	}

	public void SetOwner(IDragOwner owner) {
		this._dragOwner = owner;
	}

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        switch (_direction)
		{
			case Direction.Right: {
				_dragOwner.DragRight(eventData);
				break;
			}
			case Direction.Bottom: {
				_dragOwner.DragBottom(eventData);
				break;
			}
			case Direction.Top: {
				_dragOwner.DragTop(eventData);
				break;
			}
			case Direction.Left: {
				_dragOwner.DragLeft(eventData);
				break;
			}
		}
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
}
