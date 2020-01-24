using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCubeOffScreen : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // this script removes cubes that are off-screen
        if (other.tag == "Cube")
        {
            Destroy(other.gameObject);
        }
    }
}
