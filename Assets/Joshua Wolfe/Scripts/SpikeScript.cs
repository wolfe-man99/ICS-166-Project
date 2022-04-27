using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikeScript : MonoBehaviour
{
    public SpikeGenerator spikeGenerator;

    public Text score;

    private void Awake()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * spikeGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NextLine"))
        {
            spikeGenerator.GenerateSpikeWithGap();
        }

        if (other.gameObject.CompareTag("finish"))
        {
            score.text = (int.Parse(score.text) + 1).ToString();
            GameObject.Find("Ding").GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            spikeGenerator.currentSpeed = 0;
            Destroy(spikeGenerator);
        }
    }
}