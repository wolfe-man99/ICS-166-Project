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
    public bool CanJump = true;

    Rigidbody player;

    public GameObject gameOverText;
    public GameObject gameOverMusic;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && CanJump)
        {
            player.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
            GetComponent<AudioSource>().Play();
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
            //GameObject.Find("Game Over Text").SetActive(true);
            gameOverText.SetActive(true);
            gameOverMusic.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<AI>().GameOver();
        }
    }

    private void FixedUpdate()
    {
        player.AddForce(Vector3.down * gravity * player.mass);
    }
}
