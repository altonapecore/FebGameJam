using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTime : MonoBehaviour
{
    public List<AudioSource> sounds;
    //private Random rng;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        int soundIndex = (int)(Random.value * 20);
        sounds[soundIndex].Play();
    }
}
