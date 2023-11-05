using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed = 1f;
    // Update is called once per frame
    void Update()
    {
        switch((transform.eulerAngles.y/90)%4)
        {
            case 0:
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(10f, 0f, 0f), speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, new Vector3(10f, 0f, 0f)) < 0.01f)
                    transform.eulerAngles = new Vector3(0f, 90f, 0f);
                break;
            case 1:
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(10f, 0f, -10f), speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, new Vector3(10f, 0f, -10f)) < 0.01f)
                    transform.eulerAngles = new Vector3(0f,180f, 0f);
                break;
            case 2:
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0f, -10f), speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, new Vector3(0f, 0f, -10f)) < 0.01f)
                    transform.eulerAngles = new Vector3(0f, 270f, 0f);
                break;
            case 3:
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0f, 0f), speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, new Vector3(0f, 0f, 0f)) < 0.01f)
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                break;
        }
    }
}
