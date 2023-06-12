using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public int index;
    public int num;
    public BagUI bagUI;
    public Item item;
    RectTransform rectTransform;
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("start drag");
        this.GetComponent<Image>().raycastTarget = false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
        Debug.Log("drag");
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        this.GetComponent<Image>().raycastTarget = true;
        bagUI.PosItems();
    }

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        Debug.Log("slot on drop");
        GameObject item = eventData.pointerDrag;
        if (item) {
            bagUI.SwitchPlace(item.GetComponent<ItemUI>().index, index);
        }
        
    }

}
