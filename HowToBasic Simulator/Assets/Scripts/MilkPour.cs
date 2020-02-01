using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkPour : MonoBehaviour
{
    // Fields
    public GameObject milkJug;
    public ParticleSystem milk;
    public bool active;

    private bool moving;
    private bool moveBack;
    private float rotation;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        milk.Pause();
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            // Begin to rotate the milk jug
            if(moving && rotation > -130.0f )
            {
                milkJug.transform.Rotate(-35 * Time.deltaTime, 0, 0);
                rotation -= 35 * Time.deltaTime;
            }

            // If it's in pouring position then pour
            if(rotation <= -130.0f)
            {
                moving = false;
                milk.Play();
                // Start a timer
                timer += Time.deltaTime;
            }

            if(timer >= 1.5)
            {
                milk.Stop();
                moveBack = true;
            }

            // Move milk jug back to original position
            if(moveBack && rotation < 0.0f)
            {
                milkJug.transform.Rotate(35 * Time.deltaTime, 0, 0);
                rotation += 35 * Time.deltaTime;
            }

            // If it's back at it's original position then set everything back to beginning shit
            if(rotation >= 0.0f)
            {
                moveBack = false;
                active = false;
                timer = 0.0f;
            }
        }
    }
}
