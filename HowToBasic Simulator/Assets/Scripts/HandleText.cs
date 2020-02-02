using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleText : MonoBehaviour
{
    private int step;
    private List<string> textSteps;
    private Text text;
    private int eggCount;

    public GameObject screen;

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
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
        if (step == 0)
        {
            text.text = textSteps[step];
            step++;
        }
        else if (step == 1)
        {
            text.text = textSteps[step];
            step++;
        }
        else if (step == 2)
        {
            text.text = textSteps[step];
            step++;
        }
        else if (step == 3)
        {
            text.text = textSteps[step];
            step++;
        }
        else if (step == 4)
        {
            text.text = textSteps[step];
            step++;
        }
        else if (step == 5)
        {
            text.text = textSteps[step];
            step++;
        }
        else if (step == 6)
        {
            text.text = textSteps[step];
            step++;
        }
        else if (step == 7)
        {
            text.text = textSteps[step];
            step++;
        }
        else if (step == 8)
        {
            text.text = textSteps[step];
            step++;
        }
        else if (step == 9)
        {
            text.text = textSteps[step];
            step++;
        }
        else if (step == 10)
        {
            text.text = textSteps[step];
            step++;
        }
        else if (step == 11)
        {
            text.text = textSteps[step];
            step++;
        }
    }
}
