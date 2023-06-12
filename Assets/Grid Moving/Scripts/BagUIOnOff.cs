using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUIOnOff : MonoBehaviour
{
    public GameObject InventoryUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory")){
            Debug.Log("pressed");
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }
}
