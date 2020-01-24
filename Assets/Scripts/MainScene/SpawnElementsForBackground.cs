using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElementsForBackground : MonoBehaviour
{
    // this script randomly generates the position of 3 elements
    // in the amount of 15 objects and adds them to the screen
    public GameObject Star;
    public GameObject Heart;
    public GameObject Flower;
    void Start()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector3 VectorForStar = new Vector3(3 * Random.Range(-Screen.width, Screen.width), 3 * Random.Range(-Screen.height, Screen.height), Camera.main.farClipPlane / 2);
                Vector3 VectorForHeart = new Vector3(3 * Random.Range(-Screen.width, Screen.width), 3 * Random.Range(-Screen.height, Screen.height), Camera.main.farClipPlane / 2);
                Vector3 VectorForFlower = new Vector3(3 * Random.Range(-Screen.width, Screen.width), 3 * Random.Range(-Screen.height, Screen.height), Camera.main.farClipPlane / 2);
                Vector3 PositionStar = Camera.main.ScreenToViewportPoint(VectorForStar);
                Vector3 PositionHeart = Camera.main.ScreenToViewportPoint(VectorForHeart);
                Vector3 PositionFlower = Camera.main.ScreenToViewportPoint(VectorForFlower);
                Instantiate(Star, PositionStar, Quaternion.identity);
                Instantiate(Heart, PositionHeart, Quaternion.identity);
                Instantiate(Flower, PositionFlower, Quaternion.identity);
            }
            yield return new WaitForSeconds(5.001f);
        }
    }
}
