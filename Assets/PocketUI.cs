using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocketUI : MonoBehaviour
{
    public Bag bag;
    public Image leftImg;
    public Image middleImg;
    public Image rightImg;
    private Item left;
    private Item middle;
    private Item right;
    [SerializeField]
    private int leftIdx;
    [SerializeField]
    private int middleIdx;
    [SerializeField]
    private int rightIdx;
    // Start is called before the first frame update
    void Start()
    {
        left = null;
        middle = null;
        right = null;
        leftIdx = -1;
        middleIdx = -1;
        rightIdx = -1;
        if (bag) {
            FindItems();
        }
    }

    public void FindItems()
    {
        if (middleIdx != -1) {
            middleIdx = bag.FindItemFrom(middleIdx);
        } else {
            middleIdx = bag.FindItemFrom(0);
        }
        if (middleIdx == -1) {
            return;
        }
        rightIdx = bag.FindItemFrom(middleIdx + 1);
        if (rightIdx == middleIdx) {
            rightIdx = -1;
        }
        leftIdx = bag.FindItemFromReverse(middleIdx - 1);
        if (leftIdx == middleIdx || leftIdx == rightIdx) {
            leftIdx = -1;
        }
        UpdateItemAndDisplay();
    }

    public void TurnRight()
    {
        rightIdx = middleIdx;
        middleIdx = leftIdx;
        leftIdx = bag.FindItemFromReverse(leftIdx - 1);
        if (leftIdx == rightIdx) {
            leftIdx = -1;
        }
        UpdateItemAndDisplay();
    }

    public void TurnLeft()
    {
        leftIdx = middleIdx;
        middleIdx = rightIdx;
        rightIdx = bag.FindItemFrom(rightIdx + 1);
        if (rightIdx == leftIdx) {
            rightIdx = -1;
        }
        UpdateItemAndDisplay();
    }

    public void UpdateItemAndDisplay()
    {
        if (leftIdx != -1) {
            left = bag.GetItem(leftIdx);
            leftImg.sprite = left.itemImg;
        } else {
            leftImg.sprite = null;
        }

        if (middleIdx != -1) {
            middle = bag.GetItem(middleIdx);
            middleImg.sprite = middle.itemImg;
        } else {
            middleImg.sprite = null;
        }

        if (rightIdx != -1) {
            right = bag.GetItem(rightIdx);
            rightImg.sprite = right.itemImg;
        } else {
            rightImg.sprite = null;
        }

    }
}
