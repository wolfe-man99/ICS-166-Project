using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;
    public float speedMultiplier;
    private void Awake()
    {
        currentSpeed = minSpeed;
        generateSpike();
    }

    void generateSpike()
    {
        GameObject SpikeIn = Instantiate(spike, transform.position, transform.rotation);

        SpikeIn.GetComponent<SpikeScript>().spikeGenerator = this;
    }

    public void GenerateSpikeWithGap()
    {
        float randomint = Random.Range(.5f, 5f);
        Invoke("generateSpike", randomint);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += speedMultiplier;
        }

    }
}
