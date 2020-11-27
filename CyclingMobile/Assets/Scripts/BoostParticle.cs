using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostParticle : MonoBehaviour
{
    public ParticleSystem[] particles;

    void Start()
    {
        
    }

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
