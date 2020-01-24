using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DetectClicksOnButtons : MonoBehaviour
{
    // defines switch for buttons
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Restart":
                {
                    SceneManager.LoadScene("SampleScene");
                    break;
                }
            case "Settings":
                {
                    break;
                }
            case "Achievements":
                {
                    break;
                }
            case "Shop":
                {
                    break;
                }
            default:
                break;
        }
    }
}
