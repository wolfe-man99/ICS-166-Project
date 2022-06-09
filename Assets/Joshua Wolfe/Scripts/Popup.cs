using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField]
    private GameObject popUp;
    private bool popUp_UP = false;
    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Random.Range(1, 501) == 1 && !popUp_UP)
        {
            popUp.SetActive(true);
            popUp_UP = true;
            player.GetComponent<PlayerScript>().CanJump = false;
            GetComponent<AudioSource>().Play();
        }

        if (Input.GetKey(KeyCode.Q) && popUp_UP)
        {
            popUp.SetActive(false);
            popUp_UP = false;
            player.GetComponent<PlayerScript>().CanJump = true;
        }
    }

    public void Click()
    {
        popUp.SetActive(false);
        popUp_UP = false;
        player.GetComponent<PlayerScript>().CanJump = true;
    }
}
