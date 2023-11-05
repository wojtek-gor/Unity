using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad6 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cel;
    float wygladzanie = 0.1f;
    float predkosc = 0.1f;

    // Update is called once per frame
    void Update()
    {
        float noway = Mathf.SmoothDamp(transform.position.y, cel.position.y, ref predkosc, wygladzanie);
        float nowax = Mathf.SmoothDamp(transform.position.x, cel.position.x, ref predkosc, wygladzanie);
        float nowaz = Mathf.SmoothDamp(transform.position.z, cel.position.z, ref predkosc, wygladzanie);
        transform.position = new Vector3(nowax, noway, nowaz);

    }
}
