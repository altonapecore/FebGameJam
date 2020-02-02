using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHandler : MonoBehaviour
{
    public AudioSource thumbsGrunt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            thumbsGrunt.Play();
            this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 9);
        }
    }

    
    public void ThumbsUp()
    {
        thumbsGrunt.Play();
        this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 9);
    }
}
