using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTilePrefab;
    public int initialTiles = 5;
    public float tileLength = 50f;

    private Vector3 spawnPosition = Vector3.zero;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform player;

    void Start()
    {
        for (int i = 0; i < initialTiles; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        // Si el jugador está cerca del final del camino, genera una nueva losa
        if (player.position.z - 60 > spawnPosition.z - (initialTiles * tileLength))
        {
            SpawnTile();
            RemoveOldTile();
        }
    }

    void SpawnTile()
    {
        GameObject tile = Instantiate(groundTilePrefab, spawnPosition, Quaternion.identity);
        activeTiles.Add(tile);
        spawnPosition.z += tileLength;
    }

    void RemoveOldTile()
    {
        if (activeTiles.Count == 0) return;

        GameObject firstTile = activeTiles[0];

        // Solo elimina si el jugador está suficientemente lejos del tile
        if (player.position.z - firstTile.transform.position.z > tileLength + 10f)
        {
            Destroy(firstTile);
            activeTiles.RemoveAt(0);
        }
    }
}
