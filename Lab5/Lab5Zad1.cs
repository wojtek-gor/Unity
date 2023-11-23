using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab5Zad1 : MonoBehaviour
{
public float elevatorSpeed = 2f;
private bool isRunning = false;
public float distance = 6.6f;
private bool isRunningUp = true;
private bool isRunningDown = false;
private float downPosition;
private float upPosition;
public CharacterController gracz = null;

void Start()
{
    upPosition = transform.position.x + distance;
    downPosition = transform.position.x;
}

void Update()
{
    if (isRunningUp && transform.position.x >= upPosition)
    {
        isRunningUp = false;
        isRunningDown = true;
        elevatorSpeed = -elevatorSpeed;
    }
    else if (isRunningDown && transform.position.x <= downPosition)
    {
        isRunning = false;
    }

    if (isRunning)
    {
        Vector3 move = transform.right * elevatorSpeed * Time.deltaTime;
        transform.Translate(move);
        gracz.Move(transform.right*elevatorSpeed*Time.deltaTime);
    }
}

private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        Debug.Log("Player wszed³ na windê.");
        gracz = other.gameObject.GetComponent<CharacterController>();
        if (transform.position.x <= downPosition)
        {
            isRunningUp = true;
            isRunningDown = false;
            elevatorSpeed = Mathf.Abs(elevatorSpeed);
        }
        isRunning = true;
    }
}

private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isRunning = true;
            UnityEngine.Debug.Log("Kontynuj");
        }
    }
private void OnTriggerExit(Collider other)
{
    if (other.gameObject.CompareTag("Player"))
    {
            //isRunningDown = true;
            //isRunningUp = false;
            //elevatorSpeed = -elevatorSpeed;
            //isRunning = true;
            Debug.Log("Player zszed³ z windy.");
            gracz = null;
    }
}
}
