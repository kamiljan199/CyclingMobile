using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostParticle : MonoBehaviour
{
    public ParticleSystem[] particles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartParticles()
    {
        foreach (ParticleSystem particle in particles)
        {
            particle.Play();
        }
    }

    public void StopParticles()
    {
        foreach (ParticleSystem particle in particles)
        {
            particle.Stop();
        }
    }
}
