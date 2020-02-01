using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MakeDecal : MonoBehaviour
{
    public GameObject decal;

    public float maxX;
    public float minX;
    public float maxZ;
    public float minZ;
    public int maxDecals;

    private int numDecals;
    private ParticleSystem PSystem;
    private ParticleSystem.Particle[] particles;
    private ParticleCollisionEvent[] CollisionEvents;

    void Start()
    {
        PSystem = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[PSystem.maxParticles];
        CollisionEvents = new ParticleCollisionEvent[5];
    }

    

    void OnParticleTrigger()
    {
        
        ParticleSystem ps = GetComponent<ParticleSystem>();

        // particles
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

        // get
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        Debug.Log(numEnter);

        // iterate
        for (int i = 0; i < numEnter; i++)
        {
            Debug.Log("beans");

            ParticleSystem.Particle p = enter[i];
            if (numDecals <= maxDecals)
            {
                Instantiate(decal);
                float tempX = Random.Range(minX, maxX);
                float tempZ = Random.Range(minZ, maxZ);
                decal.transform.position = new Vector3(tempX, 17.6f, tempZ);
                numDecals++;
            }
            p.position = new Vector3(1000, 0, 1000);
            enter[i] = p;
        }

        // set
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }
}
