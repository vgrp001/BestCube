using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarderAndEasier : MonoBehaviour
{
    // this script complicates the game every 7 scores
    public GameObject DeteckClicks;
    private bool hard;
    void Update()
    {
        if (CubeJump.CountBlocks > 0)
        {
            if (CubeJump.CountBlocks % 7 == 0 && !hard)
            {
                hard = true;
                Camera.main.GetComponent<Animation>().Play("Harder");
                DeteckClicks.transform.position = new Vector3(12f, 2f, -6f);
                DeteckClicks.transform.eulerAngles = new Vector3(10f, -60f, 0f);
            }
            else if ((CubeJump.CountBlocks % 7) - 1 == 0 && hard)
            {
                hard = false;
                DeteckClicks.transform.position = new Vector3(0f, 0f, -8f);
                DeteckClicks.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                Camera.main.GetComponent<Animation>().Play("Easier");
            }
        }
    }
}
