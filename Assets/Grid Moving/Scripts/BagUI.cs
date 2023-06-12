using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUI : MonoBehaviour
{
    public Bag bag;
    public GameObject _grid;
    public int _capacity;
    public int _size;
    public GameObject[] _slots;
    public GameObject[] _items;


    public void Initialize(int maxItemNum)
    {
        _capacity = maxItemNum;
        _size = 0;
        _items = new GameObject[_capacity];
        _slots = new GameObject[_capacity];
        for (int i = 0; i < maxItemNum; i++) {
            GameObject slot = new GameObject();
            slot.AddComponent<Image>();
            slot.AddComponent<SlotUI>().index = i;
            slot.GetComponent<SlotUI>().bagUI = this;
            slot.name = "slot" + i.ToString();
            slot.transform.SetParent(_grid.transform);
            slot.transform.localScale = new Vector3(1, 1, 1);
            _slots[i] = slot;
        }
    }

    public void SwitchPlace(int old, int now)
    {
        bag.Switch(old, now);
    }

    public void PosItems()
    {
        for (int i = 0; i < _capacity; i++) {
            if (_items[i]) {
                _items[i].transform.SetParent(_slots[i].transform);
                _items[i].GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                _items[i].transform.SetParent(this.transform);
            }
        }
    }

    public void ClearItems()
    {
        for (int i = 0; i < _items.Length; i++) {
            if (_items[i] != null) {
                Destroy(_items[i]);
                _items[i] = null;
            }
        }
    }

    public void UpdateItems(Item[] items, int[] itemNums)
    {
        for (int i = 0; i < items.Length; i++) {
            if (items[i] != null) {
                if (_items[i] == null) {
                    // null in ui
                    // we should new ui object
                    GameObject itemElem = new GameObject();
                    itemElem.AddComponent<Image>().sprite = items[i].itemImg;
                    itemElem.AddComponent<ItemUI>().index = i;
                    itemElem.GetComponent<ItemUI>().bagUI = this;
                    itemElem.GetComponent<ItemUI>().item = items[i];
                    itemElem.GetComponent<ItemUI>().num = itemNums[i];
                    _items[i] = itemElem;
                } else {
                    // not null & not null
                    // update item, num, index...
                    GameObject itemElem = _items[i];
                    itemElem.AddComponent<Image>().sprite = items[i].itemImg;
                    itemElem.AddComponent<ItemUI>().index = i;
                    itemElem.GetComponent<ItemUI>().bagUI = this;
                    itemElem.GetComponent<ItemUI>().item = items[i];
                    itemElem.GetComponent<ItemUI>().num = itemNums[i];
                }
            } else {
                if (_items[i] == null) {
                    // null & null
                    // do nothing
                } else {
                    // null in bag but not null in ui
                    Destroy(_items[i]);
                    _items[i] = null;
                }
            }
        }
        PosItems();
    }

}
