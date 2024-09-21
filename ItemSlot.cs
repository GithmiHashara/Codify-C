using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public int correctItem;
    public bool isCorrectItemPlaced = false;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }

        DragDrop draggedItem = eventData.pointerDrag.gameObject.GetComponent<DragDrop>();

        if (draggedItem.objectNum == correctItem)
        {
            Debug.Log("Correct item placed!");
            isCorrectItemPlaced = true;
        }
        else
        {
            Debug.Log("Incorrect item placed.");
            isCorrectItemPlaced = false;
        }
    }
}
