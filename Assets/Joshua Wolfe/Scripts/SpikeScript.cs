using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public SpikeGenerator spikeGenerator;

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
            Destroy(gameObject);
        }
    }
}