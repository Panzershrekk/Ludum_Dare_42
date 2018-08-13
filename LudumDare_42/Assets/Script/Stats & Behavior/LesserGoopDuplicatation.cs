using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LesserGoopDuplicatation : MonoBehaviour {

    private List<DataTile> dataInfo;
    public DataTile personnalInfo;
    public List<DataTile> neigboorTile;
    public GameObject thingToSpawn;

    public SpwanStats stats;
    public float nextSpawnAllowed;
    // Use this for initialization
    void Start()
    {
        dataInfo = GameObject.FindGameObjectWithTag("MapGen").GetComponent<LevelGenerator>().mapInfo;
        nextSpawnAllowed = Time.time + stats.spwanFrequency + Random.Range(0.0f, 0.5f);
        neigboorTile = new List<DataTile>();
        GetNeiboor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnAllowed)
        {
            nextSpawnAllowed = Time.time + stats.spwanFrequency;
            SpawnGoop();
        }
    }

    void SpawnGoop()
    {
            int random = Random.Range(0, neigboorTile.Count);

            if (neigboorTile[random].isGoop == false && neigboorTile[random].obj.tag == "Ground")
            {
                Vector3 pos = neigboorTile[random].obj.transform.position + new Vector3(0, 0, -0.2f);
                Quaternion rotation = neigboorTile[random].obj.transform.rotation;
                GameObject obj = Instantiate(thingToSpawn, pos, rotation);
                /*GameObject obj = Instantiate(thingToSpawn,
                    neigboorTile[random].obj.transform.position + new Vector3(0, 0, -0.2f),
                    Quaternion.identity, transform);
                obj.transform.parent = gameObject.transform;
                */
                neigboorTile[random].obj = obj;
                neigboorTile[random].isGoop = true;
                LesserGoopDuplicatation duplicate = obj.GetComponent<LesserGoopDuplicatation>();
                duplicate.personnalInfo = neigboorTile[random];
        }
    }

    void GetNeiboor()
    {
        foreach (var tile in dataInfo)
        {
            if (tile.x - 1 == personnalInfo.x && tile.y == personnalInfo.y)
            {
                neigboorTile.Add(tile);
            }

            if (tile.x + 1 == personnalInfo.x && tile.y == personnalInfo.y)
            {
                neigboorTile.Add(tile);

            }

            if (tile.y - 1 == personnalInfo.y && tile.x == personnalInfo.x)
            {
                neigboorTile.Add(tile);

            }

            if (tile.y + 1 == personnalInfo.y && tile.x == personnalInfo.x)
            {
                neigboorTile.Add(tile);

            }

        }
    }
}
