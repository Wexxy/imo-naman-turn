using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] int minHeight, maxHeight;
    [SerializeField] GameObject ground;

    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Generate()
    {
        for (int x = 0; x < width; x++)
        {
            int minHeight = height - 1;
            int maxHeight = height + 2;

            height = Random.Range(minHeight, maxHeight);

            for (int y = 0; y < height; y++)
            {
                spawnObj(ground,x,y);
            }

            spawnObj(ground,x,height);
        }
    }

    void spawnObj(GameObject obj, int width, int height)
    {
        obj = Instantiate(obj, new Vector3(width, height), Quaternion.identity);
        obj.transform.parent = transform;
    }
}
