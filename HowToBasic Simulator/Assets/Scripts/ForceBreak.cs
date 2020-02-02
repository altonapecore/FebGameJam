using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBreak : MonoBehaviour
{
    public float velThresh;
    public AudioSource breaking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Break()
    {
        //Editing child screen parts
        GameObject screen1 = transform.GetChild(0).gameObject;
        screen1.transform.parent = null;
        screen1.GetComponent<BoxCollider>().enabled = true;
        screen1.GetComponent<Rigidbody>().isKinematic = false;
        GameObject screen2 = transform.GetChild(0).gameObject;
        screen2.transform.parent = null;
        screen2.GetComponent<BoxCollider>().enabled = true;
        screen2.GetComponent<Rigidbody>().isKinematic = false;


        //Editing parent screen
        Destroy(GetComponent<Rigidbody>());
        GetComponent<BoxCollider>().enabled = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "hammer" && collision.rigidbody.velocity.magnitude >= velThresh && !GetComponent<Rigidbody>().isKinematic)
        {
            Break();
            breaking.Play();
        }
    }
}
