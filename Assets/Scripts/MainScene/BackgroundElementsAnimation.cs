using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundElementsAnimation : MonoBehaviour
{
    // this script describes
    // what will be the animation of the elements in the background,
    // in our case, flicker
    private SpriteRenderer Item;
    void Start()
    {
        Item = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        if (Item != null)
            Item.color = new Color(Item.color.r, Item.color.g, Item.color.b, Mathf.PingPong(Time.time / 2.5f, 1.0f));
    }
}
