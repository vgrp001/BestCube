using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameArrangement : MonoBehaviour
{
    // this script starts the game process
    public GameObject Buttons, MainCube, SpawnBlocks, Coins;
    public GameObject[] AllCubes;
    public Text PlayText, GameText , StudyText, RecordText;
    public Animation CubesAnimations, BlockAnimations;
    private bool Clicked;
    private void OnMouseDown()
    {
        if (!Clicked)
        {
            Clicked = true;
            StartCoroutine(DeleteCubes());
            PlayText.gameObject.SetActive(false);
            StudyText.gameObject.SetActive(true);
            RecordText.gameObject.SetActive(true);
            Coins.gameObject.SetActive(true);
            GameText.text = "0";
            Buttons.GetComponent<ScrollObject>().SpeedScrolling = -20f;
            Buttons.GetComponent<ScrollObject>().CheckPosition = -160f;
            transform.position = new Vector3(0, 0, -8);
            transform.localScale = new Vector3(10, 12, 2);
            StartCoroutine(СubeToBlock());
            MainCube.GetComponent<Animation>().Play("StartMainCube");
            CubesAnimations.Play();
        } else if(Clicked && StudyText.gameObject.activeSelf)
            StudyText.gameObject.SetActive(false);
    }
    IEnumerator DeleteCubes()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.3f);
            AllCubes[i].GetComponent<DestroyCubeInStartGame>().enabled = true;
        }
        SpawnBlocks.GetComponent<SpawnBlocks>().enabled = true;
        GetComponent<CubeJump>().enabled = true;
    }
    IEnumerator СubeToBlock()
    {
        yield return new WaitForSeconds(MainCube.GetComponent<Animation>().clip.length -0.5f);
        BlockAnimations.Play();
        MainCube.AddComponent<Rigidbody>();
    }
}
