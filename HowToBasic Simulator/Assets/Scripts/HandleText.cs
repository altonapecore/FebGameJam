using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleText : MonoBehaviour
{
    private int step;
    public List<string> textSteps;
    public string text;
    private int eggCount;

    [Header("Transition Triggers")]
    public Rigidbody screenRigid;
    public Rigidbody boardRigid;

    //public GameObject screen;

    // Start is called before the first frame update
    void Start()
    {
        step = 0;

        textSteps.Add("Step 1: Unscrew Screen");
        textSteps.Add("Step 2: Remove Screen");
        textSteps.Add("Step 3: Remove Battery");
        textSteps.Add("Step 4: Unscrew Logic Board");
        textSteps.Add("Step 5: Mix");
        textSteps.Add("Step 6: Add 1 egg");
        textSteps.Add("Step 6: Add 2 eggs");
        textSteps.Add("Step 6: Add 3 eggs");
        textSteps.Add("Step 7: Mix more");
        textSteps.Add("Step 8: Add milk");
        textSteps.Add("Step 9: Add 1 more egg");
        textSteps.Add("Step 10: Add 1 final egg");
        textSteps.Add("Perfect!");
    }

    // Update is called once per frame
    void Update()
    {
        // testing
        //Debug.Log(!screen.IsSleeping());

        if (step == 0)
        {
            text = textSteps[step];
            step++;
        }
        else if (step == 1 && !screenRigid.isKinematic)
        {
            text = textSteps[step];
        }
        else if (step == 2)
        {
            text = textSteps[step];
        }
        else if (step == 3)
        {
            text = textSteps[step];
            step++;
        }
        else if (step == 4 && !boardRigid.isKinematic)
        {
            text = textSteps[step];
        }
        else if (step == 5)
        {
            text = textSteps[step];
        }
        else if (step == 6)
        {
            text = textSteps[step];
        }
        else if (step == 7)
        {
            text = textSteps[step];
        }
        else if (step == 8)
        {
            text = textSteps[step];
        }
        else if (step == 9)
        {
            text = textSteps[step];
        }
        else if (step == 10)
        {
            text = textSteps[step];
        }
        else if (step == 11)
        {
            text = textSteps[step];
        }
        else if (step == 12)
        {
            text = textSteps[step];
        }

        this.GetComponent<Text>().text = text;
    }

    public void Step2Done()
    {
        if (step == 1)
        {
            step++;
        }
    }

    public void Step3Done()
    {
        if (step == 2)
        {
            step++;
        }
    }

    public void NextClick()
    {
        if (step <= 11)
        {
            step++;
        }
    }
}
