using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCubeInStartGame : MonoBehaviour
{
    // this script destroys the cubes at the start of the game
    void Start()
    {
        Destroy(gameObject, 0.4f);
    }
    void Update()
    {
        transform.position += new Vector3(0, 0.2f, 0);
    }
}
