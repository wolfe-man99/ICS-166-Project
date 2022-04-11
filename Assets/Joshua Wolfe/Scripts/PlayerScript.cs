using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float gravity;

    bool isGrounded = false;

    Rigidbody player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            if (!isGrounded)
            {
                isGrounded = true;
            }
        }
        if (collision.gameObject.CompareTag("spike"))
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        player.AddForce(Vector3.down * gravity * player.mass);
    }
}