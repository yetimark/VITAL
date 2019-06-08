using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : MonoBehaviour
{
    public ParticleSystem waterStream;
    public GameObject handWashChecker;
    
    public void WaterActivate()
    {
        if (waterStream.isStopped) // If the waterstream isn't currently spawning particles, start spawning them. Then enables the checker to see if the student's hands have been stuck under the sink.
        {
            waterStream.Play();
            this.handWashChecker.SetActive(true);
        }
        else  // Likewise, when the waterstream is going, it will disable the checker and particles
        {
            waterStream.Stop();
            this.handWashChecker.SetActive(false);
        }
    }
}
