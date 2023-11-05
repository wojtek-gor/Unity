using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int kierunek = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime*kierunek);
        if(transform.position.x > 5 || transform.position.x<-5)
        {
            kierunek = kierunek * -1;
        }
    }
}
