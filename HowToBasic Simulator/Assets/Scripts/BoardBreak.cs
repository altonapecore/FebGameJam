using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBreak : MonoBehaviour
{
    public float velThresh;
    public AudioSource breaking;
    public AudioSource clink;

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
        clink.Play();

        if(collision.gameObject.tag == "hammer" && !GetComponent<Rigidbody>().isKinematic && collision.rigidbody.velocity.magnitude >= velThresh)
        {
            Break();
            breaking.Play();
        }
    }

    void Break()
    {
        //Editing child screen parts
        GameObject board1 = transform.GetChild(0).gameObject;
        board1.transform.parent = null;
        board1.GetComponent<BoxCollider>().enabled = true;
        board1.GetComponent<Rigidbody>().isKinematic = false;
        GameObject board2 = transform.GetChild(0).gameObject;
        board2.transform.parent = null;
        board2.GetComponent<BoxCollider>().enabled = true;
        board2.GetComponent<Rigidbody>().isKinematic = false;


        //Editing parent screen
        Destroy(GetComponent<Rigidbody>());
        BoxCollider[] boxColliders = GetComponents<BoxCollider>();
        boxColliders[0].enabled = false;
        boxColliders[1].enabled = false;
    }
}
