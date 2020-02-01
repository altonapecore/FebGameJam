using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBreak : MonoBehaviour
{
    public GameObject eggYolk;
    bool broken = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BreakEgg()
    {
        Destroy(GetComponent<CapsuleCollider>()); //gets rid of eggs collider
        Destroy(GetComponent<Rigidbody>()); //gets rid of eggs rb
        Destroy(transform.GetChild(0).gameObject);     //deleting deletemebits
        for(int i = 0; i < transform.childCount; i++)   //giving rb's to individual egg shells
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.AddComponent<Rigidbody>();
            child.AddComponent<MeshCollider>();
            child.GetComponent<MeshCollider>().convex = true;
        }
        //Setting up yolk
        GameObject newYolk = Instantiate(eggYolk, transform.position, Quaternion.identity);       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!broken)
        {
            BreakEgg();
            broken = true;
        }
    }
}
