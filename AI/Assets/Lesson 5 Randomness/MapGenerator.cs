using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    public int width = 32;
    public int depth = 32;
    public int heightMultiplier = 10;
    public float noiseScale = 0.1f;
    public GameObject blockPrefab;

    private float offsetX;
    private float offsetZ;

    void Start()
    {
        offsetX = Random.Range(0f, 9999f);
        offsetZ = Random.Range(0f, 9999f);
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                float noise = Mathf.PerlinNoise(
                    (x + offsetX) * noiseScale,
                    (z + offsetZ) * noiseScale
                );
                int terrainHeight = Mathf.FloorToInt(noise * heightMultiplier);
                for (int y = 0; y <= terrainHeight; y++)
                {
                    Instantiate(blockPrefab, new Vector3(x, y, z), Quaternion.identity);
                }
            }
        }
    }

}
