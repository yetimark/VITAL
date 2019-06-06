using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : MonoBehaviour
{
    public ParticleSystem waterStream;
    public void WaterActivate()
    {
        if (waterStream.isStopped) // If the waterstream isn't currently spawning particles, start spawning them
        {
            waterStream.Play();
        }
        else  // Likewise, when the waterstream is going, this will cause it to stop spawning particles
        {
            waterStream.Stop();
        }
    }
}
