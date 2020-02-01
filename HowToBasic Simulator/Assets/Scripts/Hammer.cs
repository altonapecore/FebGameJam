using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    // Fields
    public GameObject hammer;
    public bool active;

    private bool moving;
    private bool moveBack;
    private float rotation;
    private int counter;

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
            if (counter != 3)
            {
                // Begin to rotate the milk jug
                if (moving && rotation > -130.0f)
                {
                    hammer.transform.Rotate(0, 0, -210 * Time.deltaTime);
                    rotation -= 210 * Time.deltaTime;
                }

                // If it's in pouring position then pour
                if (rotation <= -130.0f)
                {
                    moving = false;
                    moveBack = true;
                }

                // Move milk jug back to original position
                if (moveBack && rotation < -80.0f)
                {
                    hammer.transform.Rotate(0, 0, 210 * Time.deltaTime);
                    rotation += 210 * Time.deltaTime;
                }

                // If it's back at it's original position then set everything back to beginning shit
                if (moveBack && rotation >= -80.0f)
                {
                    moveBack = false;
                    moving = true;
                    counter++;
                }
            }
            else
            {
                active = false;

                if(rotation < 0.0f)
                {
                    hammer.transform.Rotate(0, 0, 210 * Time.deltaTime);
                    rotation += 210 * Time.deltaTime;
                }
            }
        }
    }
}
