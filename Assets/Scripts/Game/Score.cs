using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    // this script displays the record
    public Text Record;
    private Text AccountAtMoment;
    private bool GameStart;
    void Start()
    {
        Record.text = "Record :" + PlayerPrefs.GetInt("Record").ToString();
        AccountAtMoment = GetComponent<Text>();
        CubeJump.CountBlocks = 0;
    }

    void Update()
    {
        if (AccountAtMoment.text == "0")
            GameStart = true;
        if (GameStart)
        {
            AccountAtMoment.text = CubeJump.CountBlocks.ToString();
            if(PlayerPrefs.GetInt("Record")< CubeJump.CountBlocks)
            {
                PlayerPrefs.SetInt("Record", CubeJump.CountBlocks);
                Record.text = "Record :" + PlayerPrefs.GetInt("Record").ToString();
            }
        }

    }
}
