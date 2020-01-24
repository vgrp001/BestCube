using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    // this script makes the text flicker
    private Text text;
    private Outline outline;
    void Start()
    {
        text = GetComponent<Text>();
        outline = GetComponent<Outline>();
    }
    void Update()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.PingPong(Time.time / 2.5f, 1f));
        outline.effectColor = new Color(outline.effectColor.r, outline.effectColor.g, outline.effectColor.b, text.color.a - 0.3f);
    }
}
