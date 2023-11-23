using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5Zad2 : MonoBehaviour
{
    public float distance = 2.6f;
    private bool open = false;
    public float speed = 2.0f;
    private float openPosition;
    private float closePosition;
    // Start is called before the first frame update
    void Start()
    {
        closePosition = transform.position.x;
        openPosition = transform.position.x + distance;
    }

    // Update is called once per frame
    void Update()
    {
        if(open && transform.position.x <= openPosition)
        {
            Vector3 move = transform.right * speed * Time.deltaTime;
            transform.Translate(move);
        }
        else if (transform.position.x >= closePosition && open == false)
        {
            Vector3 move = -transform.right * speed * Time.deltaTime;
            transform.Translate(move);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Otwieram");
            open = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Zamykam");
            open = false;
        }
    }
}
