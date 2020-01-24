using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountCoins : MonoBehaviour
{
    private Text CountText;
    void Start()
    {
        CountText = GetComponent<Text>();
        CountText.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
