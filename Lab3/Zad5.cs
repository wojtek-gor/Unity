using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad5 : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3[] tab = new Vector3[10];
    void Start()
    {
        for(int i = 0; i<10; i++)
        {
            tab[i] = new Vector3 (Random.Range(-5, 5), 1, Random.Range(-5, 5));
        }
        for(int i = 0; i<10;i++)
        {
            for(int j = 0;j<i;j++)
            {
                if (tab[i] == tab[j])
                {
                    tab[i] = new Vector3(Random.Range(-5, 5), 1, Random.Range(-5, 5));
                    break;
                }
            }
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = tab[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
