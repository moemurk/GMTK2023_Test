using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public Item item;
    void OnTriggerEnter2D(Collider2D player)
    {
        Bag bag = player.gameObject.GetComponent<Bag>();
        if (bag) {
            if (bag.AddItem(item) != 0) {
                return;
            }
            Destroy(this.gameObject);
        }
    }
}
