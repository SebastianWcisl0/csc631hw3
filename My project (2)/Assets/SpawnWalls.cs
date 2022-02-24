using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab = null;
    Camera cam;
    public Transform player;
    public Vector3 offset;

    private void start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        SpawnAheadOfPlayer();
    }



    private void SpawnAheadOfPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(cubePrefab, (player.position + offset), Quaternion.identity);
        }
    }
}
//transform.position = player.position + offset