using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5Zad5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Œciana"))
        {
            UnityEngine.Debug.Log("Zderzenie");
        }
    }
}
