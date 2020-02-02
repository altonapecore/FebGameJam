using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTime : MonoBehaviour
{
    public List<AudioSource> sounds;
    public GameObject music;

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
        GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>().Stop();
    }
}
