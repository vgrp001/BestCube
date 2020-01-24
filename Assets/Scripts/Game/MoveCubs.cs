using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubs : MonoBehaviour
{
    // this script moves all the cubes after jumping to the platform
    private bool Moved;
    private Vector3 Target;
    void Start()
    {
        Target = new Vector3(-3, 5, 0);
        Moved = true;
    }
    void Update()
    {
        if (CubeJump.NextBlock)
        {
            if (transform.position != Target && !CubeJump.CheckSequenceClicks)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target, Time.deltaTime * 20f);
            }
            else if (transform.position == Target && !Moved)
            {
                Target = new Vector3(transform.position.x - 3.2f, transform.position.y + 3.2f, transform.position.z);
                CubeJump.Jump = false;
                Moved = true;
            }
            if (CubeJump.Jump)
                Moved = false;
        }
    }
}
