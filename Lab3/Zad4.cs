using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Zad4 : MonoBehaviour
{
    public float speed = 2.0f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mh = Input.GetAxis("Horizontal");
        float mv = Input.GetAxis("Vertical");
        Vector3 v = new Vector3(mh, 0, mv);
        v = v.normalized*speed*Time.deltaTime;
        rb.MovePosition(transform.position + v);
    }
}
