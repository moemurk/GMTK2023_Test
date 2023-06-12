using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float threshold = 0.05f;
    public LayerMask blockingLayer;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null) {
            target = new GameObject().transform;
            target.SetParent(null);
            target.position = this.transform.position;
            target.name = "moving target";
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        if (Mathf.Abs(Vector3.Distance(target.position, this.transform.position)) > threshold) {
            return;
        }
        Vector3 nextPos = target.position;
        float horiziontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(horiziontal) > .7f) {
            nextPos += Vector3.right * (horiziontal > 0 ? 1 : -1);
        } else if (Mathf.Abs(vertical) > .7f) {
            nextPos += Vector3.up * (vertical > 0 ? 1 : -1);
        }
        if (!Physics2D.OverlapCircle(nextPos, .2f, blockingLayer)) {
            target.position = nextPos;
        }
    }
}
