using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Written by Yilong Tang

public class AI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent; // AI
    [SerializeField] private Transform player;
    [SerializeField] private Transform walkPoint1;
    [SerializeField] private Transform walkPoint2;
    [SerializeField] private Transform walkPoint3;
    [SerializeField] private float StartTime;
    private bool UsingScreen; // Check if player is using the screen
    private bool GameOver = false; // Check if the fail state is met
    private bool walkPoint1_Arrived = false;
    private bool walkPoint3_Arrived = false;
    private bool reset = false;
    GameObject screen; // Game object for the in game screen

    private void Awake()
    {
        screen = GameObject.Find("Plane"); // Bind the screen to game object to get the bool value of screen
    }

    public bool Get_GameOver()
    {
        return GameOver;
    }

    private void CheckPlayerArrival() // Set stages for AI
    {
        if(Vector3.Distance(agent.transform.position,walkPoint3.position) < 1 && !walkPoint1_Arrived)
        {
            walkPoint3_Arrived = true;
        }
        if(Vector3.Distance(agent.transform.position,walkPoint1.position) < 1 && walkPoint3_Arrived)
        {
            //Debug.Log("arrived 1");
            walkPoint1_Arrived = true;
            walkPoint3_Arrived = false;
        }
        if (Vector3.Distance(agent.transform.position, walkPoint3.position) < 1 && walkPoint1_Arrived)
        {
            //Debug.Log("arrived 3");
            walkPoint3_Arrived = true;
        }
        if (walkPoint3_Arrived && walkPoint1_Arrived)
        {
            //Debug.Log("reset");
            walkPoint1_Arrived = false;
            walkPoint3_Arrived = false;
        }
    }

    void CheckPlayer1()
    {
        agent.SetDestination(walkPoint1.position);
    }

    IEnumerator CheckPlayer2()
    {
        yield return new WaitForSeconds(2);
        agent.SetDestination(walkPoint3.position);
    }

    void Update()
    {
        UsingScreen = screen.GetComponent<ScreenMovement>().Get_up();
        CheckPlayerArrival();

        if (UsingScreen)
        {
            if(!walkPoint1_Arrived && walkPoint3_Arrived)
            {
                CheckPlayer1();
            }
            if (walkPoint1_Arrived && !walkPoint3_Arrived)
            {
                StartCoroutine(CheckPlayer2());
            }
            if(Vector3.Distance(agent.transform.position, player.position) < 9)
            {
                Debug.Log("GameOver");
                GameOver = true;
            }
        }

        if (!UsingScreen)
        {
            if (walkPoint1_Arrived && !walkPoint3_Arrived)
            {
                StartCoroutine(CheckPlayer2());
            }
        }    
    }
}
