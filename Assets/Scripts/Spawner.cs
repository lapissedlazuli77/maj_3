using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Ghost ghost;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;
    public GameObject spawn7;
    public GameObject spawn8;

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
            targetTime = Random.Range(2.0f, 8.0f);
            int spawncount = Random.Range(1, 9);
            Startspawn(spawncount);
        }
    }
    void Startspawn(int numspawn)
    {
        for (int i = 0; i < numspawn; i++)
        {
            int spawnerchoice = Random.Range(0, 8);
            if (spawnerchoice == 0) { GameObject tospawn = spawn1;
                SpawnIn(spawn1);
            }
            if (spawnerchoice == 1) { GameObject tospawn = spawn2;
                SpawnIn(spawn2);
            }
            if (spawnerchoice == 2) {
                GameObject tospawn = spawn3;
                SpawnIn(spawn3);
            }
            if (spawnerchoice == 3) {
                GameObject tospawn = spawn4;
                SpawnIn(spawn4);
            }
            if (spawnerchoice == 4) { GameObject tospawn = spawn5;
                SpawnIn(spawn5);
            }
            if (spawnerchoice == 5) {
                GameObject tospawn = spawn6;
                SpawnIn(spawn6);
            }
            if (spawnerchoice == 6) {
                GameObject tospawn = spawn7;
                SpawnIn(spawn7);
            }
            if (spawnerchoice == 7) { GameObject tospawn = spawn8;
                SpawnIn(spawn8);
            }
        }
    }
    void SpawnIn(GameObject spawnin)
    {
        Debug.Log("Spawning at " + spawnin.name + " located at " + spawnin.transform.position);
        Instantiate(ghost, spawnin.transform.position, Quaternion.identity);
    }
}
