using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHandler : MonoBehaviour
{
    public AudioSource thumbsGrunt;
    public bool doTheThing;

    // Start is called before the first frame update
    void Start()
    {
        doTheThing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (doTheThing)
        {
            doTheThing = false;
            thumbsGrunt.Play();
            this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 9);
        }
    }
}
