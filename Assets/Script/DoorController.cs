using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Yilong Tang

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor;

    private void OnTriggerEnter(Collider other) // When AI rigidbody hits the box collider, the animation for door will be played.
    {
        myDoor.Play("Door", 0, 0.0f);
    }
}