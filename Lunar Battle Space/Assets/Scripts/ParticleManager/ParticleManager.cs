using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField]
    ParticleSystem[] particleSystems;

    [SerializeField]
    float valuePositionZ = -2;

    int currentParticle;

    public void CallParticle(Vector2 position)
    {
        particleSystems[currentParticle].transform.position = new Vector3(position.x, position.y, valuePositionZ);
        particleSystems[currentParticle].Play();
        if (currentParticle < particleSystems.Length - 1)
            currentParticle++;
        else
            currentParticle = 0;
    }
}
