using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab4zad4 : MonoBehaviour
{
    // ruch wok� osi Y b�dzie wykonywany na obiekcie gracza, wi�c
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;
    public float sensitivity = 200f;
    float rotacja = 0f;
    void Start()
    {
        // zablokowanie kursora na �rodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy warto�ci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        // wykonujemy rotacj� wok� osi Y
        player.Rotate(Vector3.up * mouseXMove);

        // a dla osi X obracamy kamer� dla lokalnych koordynat�w
        // -mouseYMove aby unikn�� ofektu mouse inverse
        rotacja = rotacja - mouseYMove;
        rotacja = Mathf.Clamp(rotacja, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotacja,0f,0f);
       
    }
}