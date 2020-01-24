using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    // this script generates new platforms and puts them in position
    public GameObject NewBlock, AllCubes, NewCoin;
    private GameObject BlockInstance, CoinInstance;
    private Vector3 BlockPositions, CoinPositions;
    private float SpeedMovement = 20f;
    private bool CheckPosition;
    private void Start()
    {
        Spawn();
    }
    private void Update()
    {
        if (BlockInstance.transform.position != BlockPositions && !CheckPosition)
        {
            BlockInstance.transform.position = Vector3.MoveTowards(BlockInstance.transform.position, BlockPositions, Time.deltaTime * SpeedMovement);
            if (CoinInstance)
                CoinInstance.transform.position = Vector3.MoveTowards(CoinInstance.transform.position, CoinPositions, Time.deltaTime * SpeedMovement);
        }
        else if (BlockInstance.transform.position == BlockPositions)
        {
            CheckPosition = true;
        }
        if (CubeJump.Jump && CubeJump.NextBlock)
        {
            Spawn();
            CheckPosition = false;
        }
    }
    void Spawn()
    {
        BlockPositions = new Vector3(Random.Range(0.7f, 1.7f), Random.Range(-3f, -2f), -0.5f);
        BlockInstance = Instantiate(NewBlock, new Vector3(5f, -6f, -0.5f), Quaternion.identity);
        BlockInstance.transform.localScale = new Vector3(RandScale(), BlockInstance.transform.localScale.y, BlockInstance.transform.localScale.z);
        BlockInstance.transform.parent = AllCubes.transform;
        if (CubeJump.CountBlocks % 7 == 0 && CubeJump.CountBlocks != 0)
        {
            CoinPositions = new Vector3(BlockPositions.x, BlockPositions.y + 0.5f, BlockPositions.z);
            CoinInstance = Instantiate(NewCoin, new Vector3(5f, -6f, -0.5f), Quaternion.Euler(Camera.main.transform.eulerAngles));
            CoinInstance.transform.parent = AllCubes.transform;
            CoinInstance.transform.localRotation = new Quaternion(CoinInstance.transform.localRotation.x, 0f, CoinInstance.transform.localRotation.z, CoinInstance.transform.localRotation.z);
        }
    }
    float RandScale()
    {
        float rand;
        if (Random.Range(0, 100) > 70)
        {
            rand = Random.Range(1.6f, 2.4f);
        }
        else
        {
            rand = Random.Range(1.6f, 2f);
        }
        return rand;
    }

}
