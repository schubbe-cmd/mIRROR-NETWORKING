using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Draggable.Slot takesTypeOfCard = Draggable.Slot.ATTACK;
	public int x = 0;
	
	public void OnPointerEnter(PointerEventData eventData)
	{
		//Debug.Log("OnPointerEnter");
		if (eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if (d != null)
		{
			d.placeholderParent = this.transform;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		//Debug.Log("OnPointerExit");
		if (eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if (d != null && d.placeholderParent == this.transform)
		{
			d.placeholderParent = d.parentToReturnTo;
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
		Debug.Log(eventData.pointerDrag.name);
		
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if (d != null)
		{
				if (takesTypeOfCard == d.typeOfCard || takesTypeOfCard == Draggable.Slot.INVENTORY)
				{
					if (x == 0)
					{
					
						d.parentToReturnTo = this.transform;
							if (gameObject.name == "TableTop")
							{
								x++;
							}
				}
			}
		}
	}
}
