using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using Mirror;

public class Draggable : NetworkBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;
	public GameObject Canvas;
	public GameObject DropZone;
	private bool isDraggable = true;
	public PlayerManager PlayerManager;
	public enum Slot { ATTACK, DEFEND, DODGE, INVENTORY};
	public enum Slot1 { NONE, SOFT, HARD, SHARP, BOUNCE, SPIN };
	public enum Slot2 { NONE, DODGE, BLOCK, DEFLECT, SPLIT, REBOUND, CATCH };
	
	public Slot typeOfCard = Slot.ATTACK;
	public Slot1 typeOfAttackCard = Slot1.NONE;
	public Slot2 typeOfDefenseCard = Slot2.NONE;

	GameObject placeholder = null;

    private void Start()
    {
		Canvas = GameObject.Find("Main Canvas");
		DropZone = GameObject.Find("DropZone");
        if (!hasAuthority)
        {
			isDraggable = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
	{
		//Debug.Log("OnBeginDrag");
		if (!isDraggable) return;
		placeholder = new GameObject();
		placeholder.transform.SetParent(this.transform.parent);
		LayoutElement le = placeholder.AddComponent<LayoutElement>();
		le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;

		placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

		parentToReturnTo = this.transform.parent;
		placeholderParent = parentToReturnTo;
		this.transform.SetParent(this.transform.parent.parent);

		GetComponent<CanvasGroup>().blocksRaycasts = false;

		//DropZone[] zones = GameObject.FindObjectsOfType<DropZone>();
	}

	public void OnDrag(PointerEventData eventData)
	{
		//Debug.Log ("OnDrag");
		this.transform.position = eventData.position;

		if (placeholder.transform.parent != placeholderParent)
			placeholder.transform.SetParent(placeholderParent);

		int newSiblingIndex = placeholderParent.childCount;

		for (int i = 0; i < placeholderParent.childCount; i++)
		{
			if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
			{

				newSiblingIndex = i;

				if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
					newSiblingIndex--;

				break;
			}
		}

		placeholder.transform.SetSiblingIndex(newSiblingIndex);

	}

	public void OnEndDrag(PointerEventData eventData)
	{
		//Debug.Log("OnEndDrag");
		if (!isDraggable) return;
		isDraggable = false;
		this.transform.SetParent(parentToReturnTo);
		this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		
		NetworkIdentity networkidentity = NetworkClient.connection.identity;
		PlayerManager = networkidentity.GetComponent<PlayerManager>();
		//PlayerManager.PlayCard(gameObject);
		Destroy(placeholder);
		
	}



}
