using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5Zad3 : MonoBehaviour
{
    public List<Vector3> punkty = new List<Vector3>();
    public float predkosc = 2.0f;
    private bool ruch = false;
    private bool powrot = false;
    private Vector3 start;
    private int iterator = 0;
    private CharacterController gracz = null;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(ruch)
        {
            if (powrot && iterator < 0)
            {
                Vector3 move = Vector3.MoveTowards(transform.position, start, predkosc * Time.deltaTime);
                var odl = move - transform.position;
                transform.position = move;
                gracz.Move(odl);
                if(Vector3.Distance(transform.position, start)<0.01f)
                {
                    powrot = false;
                    ruch = false;
                    iterator = 0;
                }
                
            }
            else
            {
                Vector3 move = Vector3.MoveTowards(transform.position, punkty[iterator], predkosc * Time.deltaTime);
                var odl = move - transform.position;
                transform.position = move;
                gracz.Move(odl);
            }
            if(iterator>=0)
            {
                if (Vector3.Distance(transform.position, punkty[iterator]) < 0.01f && powrot == false)
                {
                    UnityEngine.Debug.Log("Dodaje " + iterator);
                    iterator++;
                }
                else if (Vector3.Distance(transform.position, punkty[iterator]) < 0.01f)
                {
                    iterator--;
                    UnityEngine.Debug.Log("Minus " + iterator);
                }
            }
        }
        if(iterator==punkty.Count)
        {
            powrot = true;
            iterator--;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Wejœcie");
            gracz = other.gameObject.GetComponent<CharacterController>();
            ruch = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Zejœcie");
            ruch = false;
        }
    }
}
