using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotUI : MonoBehaviour, IDropHandler
{
    public int index;
    public BagUI bagUI;
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        Debug.Log("slot on drop");
        GameObject item = eventData.pointerDrag;
        if (item) {
            bagUI.SwitchPlace(item.GetComponent<ItemUI>().index, index);
        }
        
    }
}
