using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Linq;

public class ScreenMovement : MonoBehaviour
{
    //hello
    private bool up = true;
    private bool screenChange = false;
    //private HashSet<KeyCode> Keys;

    private void Awake()
    {
        //Keys = new HashSet<KeyCode>((KeyCode[])Enum.GetValues(typeof(KeyCode)));
    }
    /*
    public void PLaySong()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
    */

    public bool Get_up()
    {
        return up;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("hey");
        if (Input.GetKeyDown(KeyCode.Mouse1) && !screenChange)
        {
            screenChange = true;
            //Debug.Log("hey");
            if (up)
            {
                //transform.position = Vector3.Lerp(transform.position, transform.position - new Vector3(0, 1, 0), 1f);
                StartCoroutine(moveDown(.25f));
                
            }
            else
            {
                //transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 1, 0), 1f);
                StartCoroutine(moveUp(.25f));
                
            }
        }
    }

    IEnumerator moveUp(float t)
    {
        Vector3 target = transform.position + new Vector3(0, 1, 0);
        //Debug.Log((target - transform.position).y);
        while ((target-transform.position).y>=0)
        {
            //Debug.Log("here");
            transform.position += new Vector3(0, Time.deltaTime/t, 0);
            yield return null;
        }
        transform.position = target;
        screenChange = false;

        up = true;
        gameObject.GetComponent<AudioSource>().volume = .2f;
    }

    IEnumerator moveDown(float t)
    {
        Vector3 target = transform.position - new Vector3(0, 1, 0);
        while ((target - transform.position).y<=0)
        {
            transform.position -= new Vector3(0, Time.deltaTime / t, 0);
            yield return null;
        }
        transform.position = target;
        screenChange = false;

        up = false;
        gameObject.GetComponent<AudioSource>().volume = .05f;
    }
}
