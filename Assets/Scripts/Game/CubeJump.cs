using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour
{
    // this script describes the logic of the jump
    public static bool Jump, NextBlock;
    public static bool CheckSequenceClicks;
    public static int CountBlocks;
    public GameObject MainCube, Buttons, LoseButtons;
    private bool Animated, Lose;
    private float scratchSreed = 0.8f, startTime, yPosCube;
    private void Start()
    {
        StartCoroutine(CanJump());
        CheckSequenceClicks = false;
        NextBlock = false;
        Animated = false;
        Jump = false;
    }
    private void FixedUpdate()
    {
        if (Animated && MainCube.transform.localScale.y > 0.8f)
        {
            PressCube(-scratchSreed);
        }
        else if (!Animated && MainCube != null)
        {
            if (MainCube.transform.localScale.y < 1.5f)
            {
                PressCube(3f * scratchSreed);
            }
            else if (MainCube.transform.localScale.y != 1.5f)
            {
                MainCube.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
        }
        if (MainCube != null)
        {
            if (MainCube.transform.position.y < -20f)
            {
                Destroy(MainCube, 0.5f);
                Lose = true;
            }
        }
        if (Lose)
        {
            PlayerLose();
        }
    }
    void PlayerLose()
    {
        Buttons.GetComponent<ScrollObject>().SpeedScrolling = 20f;
        Buttons.GetComponent<ScrollObject>().CheckPosition = 0f;
        if (!LoseButtons.activeSelf)
            LoseButtons.SetActive(true);
        LoseButtons.GetComponent<ScrollObject>().SpeedScrolling = 20f;
        LoseButtons.GetComponent<ScrollObject>().CheckPosition = 140f;
    }
    private void OnMouseDown()
    {
        if (NextBlock && MainCube.GetComponent<Rigidbody>())
        {
            Animated = true;
            CheckSequenceClicks = true;
            startTime = Time.time;
            yPosCube = ((int)(MainCube.transform.position.y * 100)) / 100;
        }
    }
    private void OnMouseUp()
    {
        if (NextBlock && MainCube.GetComponent<Rigidbody>() && CheckSequenceClicks)
        {
            Animated = false;
            CheckSequenceClicks = false;
            Jump = true;
            float force, diff;
            diff = Time.time - startTime;
            if (diff < 3f)
                force = 190 * diff;
            else
                force = 300;
            if (force < 60)
                force = 60;
            MainCube.GetComponent<Rigidbody>().AddRelativeForce(MainCube.transform.up * force);
            MainCube.GetComponent<Rigidbody>().AddRelativeForce(MainCube.transform.right * -force);
            StartCoroutine(CheckCubePos());
            NextBlock = false;
        }
    }
    private void PressCube(float forse)
    {
        MainCube.transform.localPosition += new Vector3(0f, forse * Time.deltaTime, 0f);
        MainCube.transform.localScale += new Vector3(0f, forse * Time.deltaTime, 0f);
    }
    IEnumerator CheckCubePos()
    {
        yield return new WaitForSeconds(1.5f);
        if (MainCube != null)
        {
            if (yPosCube == ((int)(MainCube.transform.position.y * 100)) / 100)
            {
                Lose = true;
            }
            else
            {
                while (!MainCube.GetComponent<Rigidbody>().IsSleeping())
                {
                    yield return new WaitForSeconds(0.05f);
                    if (MainCube == null) break;
                }
                if (!Lose)
                {
                    CountBlocks++;
                    NextBlock = true;
                    MainCube.transform.localPosition = new Vector3(-1f, MainCube.transform.localPosition.y, MainCube.transform.localPosition.z);
                    MainCube.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);

                    MainCube.transform.eulerAngles = new Vector3(0f, MainCube.transform.eulerAngles.y, 0f);
                }
            }
        }
        else
            Lose = true;
    }
    IEnumerator CanJump()
    {
        while (!MainCube.GetComponent<Rigidbody>())
        {
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(1f);
        NextBlock = true;
    }
}
