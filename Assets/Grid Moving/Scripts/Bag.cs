using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{

    [Range(0, 50)]
    public int maxItemNumber;
    public BagUI ui;
    public PocketUI pocketUI;
    [SerializeField]
    private Item[] _items;
    [SerializeField]
    private int[] _itemNums;

    void Start()
    {
        _items = new Item[maxItemNumber];
        _itemNums = new int[maxItemNumber];
        if (ui)
        {
            ui.Initialize(maxItemNumber);
        }
    }

    private int FindPlace()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

    public int AddItem(Item item)
    {
        if (FindItemIndex(item.itemName) != -1)
        {
            // item already in bag
            _itemNums[FindItemIndex(item.itemName)]++;
        }
        else
        {
            if (FindPlace() != -1)
            {
                // add new item
                int index = FindPlace();
                _items[index] = item;
                _itemNums[index] = 1;
            }
            else
            {
                // no enough room for new item
                return -1;
            }
        }
        ui.UpdateItems(_items, _itemNums);
        pocketUI.FindItems();
        return 0;
    }

    public int FindItemIndex(string itemName)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if ((_items[i] != null) && _items[i].itemName == itemName)
            {
                return i;
            }
        }
        return -1;
    }

    public void Switch(int old, int now)
    {
        Item oldItem = _items[old];
        int oldNum = _itemNums[old];
        Item nowItem = _items[now];
        int nowNum = _itemNums[now];
        _items[old] = nowItem;
        _itemNums[old] = nowNum;
        _items[now] = oldItem;
        _itemNums[now] = oldNum;
        ui.UpdateItems(_items, _itemNums);
        pocketUI.FindItems();
    }

    public int FindItemFrom(int startIdx)
    {
        if (startIdx >= maxItemNumber) {
            startIdx = startIdx - maxItemNumber;
        }
        if (startIdx < 0) {
            startIdx = maxItemNumber - startIdx;
        }
        if (startIdx >= maxItemNumber || startIdx < 0) {
            return -1;
        }
        for (int i = startIdx; i < maxItemNumber; i++) {
            if (_items[i] != null) {
                return i;
            }
        }
        for (int i = 0; i < startIdx; i++) {
            if (_items[i] != null) {
                return i;
            }
        }
        return -1;
    }

    public int FindItemFromReverse(int startIdx)
    {
        if (startIdx >= maxItemNumber) {
            startIdx = startIdx - maxItemNumber;
        }
        if (startIdx < 0) {
            startIdx = maxItemNumber + startIdx;
        }
        if (startIdx >= maxItemNumber || startIdx < 0) {
            return -1;
        }
        for (int i = startIdx; i >= 0; i--) {
            if (_items[i] != null) {
                return i;
            }
        }
        for (int i = maxItemNumber - 1; i > startIdx; i--) {
            if (_items[i] != null) {
                return i;
            }
        }
        return -1;
    }

    public Item GetItem(int index)
    {
        if (index >= maxItemNumber) {
            return null;
        }
        return _items[index];
    }
}
