using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5Zad4 : MonoBehaviour
{
    private CharacterController gracz = null;
    private bool skok = false;
    private Vector3 wysokosc;
    private int iterator = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gracz != null) 
        {
            
            if (skok)
            {
                wysokosc.y += Mathf.Sqrt( -9.0f * -9.81f);
                skok = false;
            }
            gracz.Move(wysokosc * Time.deltaTime);
            iterator++;
            if (iterator > 1000)
            {
                gracz = null;
                iterator = 0;
                wysokosc.y = 0;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Skok");
            gracz = other.gameObject.GetComponent<CharacterController>();
            skok = true;
        }
    }
}
