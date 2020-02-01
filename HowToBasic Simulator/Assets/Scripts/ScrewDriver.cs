using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewDriver : MonoBehaviour
{
    public GameObject screwDriver;
    public bool active;

    private bool moving;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            timer += Time.deltaTime;
            if (moving)
            {
                screwDriver.transform.Rotate(50 * Time.deltaTime, 0, 0);
            }

            if(timer >= 3.5f)
            {
                moving = false;
            }
        }
    }
}
