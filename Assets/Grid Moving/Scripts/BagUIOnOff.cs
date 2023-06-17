using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUIOnOff : MonoBehaviour
{
    public GameObject InventoryUI;
    public PocketUI pocketUI;

    void Start()
    {
        InventoryUI.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory")){
            Debug.Log("pressed");
            InventoryUI.GetComponent<Canvas>().enabled = !InventoryUI.GetComponent<Canvas>().enabled;
        }
        if (Input.GetButtonUp("PocketLeft")) {
            pocketUI.TurnLeft();
        }
        if (Input.GetButtonUp("PocketRight")) {
            pocketUI.TurnRight();
        }
    }
}
