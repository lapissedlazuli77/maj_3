using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ghost;

    public List<GameObject> spawnpoints = new List<GameObject>();

    float currenttime = 0;
    float targetTime = 4.0f;

    public Sprite baseghost;
    public Sprite violinghost;
    public Sprite clarinetghost;
    public Sprite tubaghost;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currenttime += Time.deltaTime;
        if (currenttime > targetTime)
        {
            currenttime = 0;
            targetTime = Random.Range(6.0f, 8.0f);
            int spawncount = Random.Range(1, 9);
            Startspawn(spawncount);
        }
    }
    void Startspawn(int numspawn)
    {
        for (int i = 0; i < numspawn; i++)
        {
            int spawnerchoice = Random.Range(0, 6);
            GameObject tospawn = spawnpoints[spawnerchoice];
            SpawnIn(tospawn);
        }
    }
    void SpawnIn(GameObject spawnin)
    {
        Debug.Log("Spawning at " + spawnin.name + " located at " + spawnin.transform.position);
        Instantiate(ghost, spawnin.transform);
    }
}
