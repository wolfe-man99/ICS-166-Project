using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Yilong Tang

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor;
    [SerializeField] private AudioSource myDoor_Sound;

    private void OnTriggerEnter(Collider other) // When AI rigidbody hits the box collider, the sound and animation for door will be played.
    {
        myDoor.Play("Door", 0, 0.0f);
        myDoor_Sound.Play();
    }
}