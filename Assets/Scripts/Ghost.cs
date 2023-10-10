using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float maxMoveSpeed = 10f;
    Vector3 headingfor;

    public GameObject player;
    public SpriteRenderer srend;

    public Sprite baseghost;
    public Sprite violinghost;
    public Sprite clarinetghost;
    public Sprite tubaghost;

    public int health;

    float currenttime = 0;
    float targetTime;

    // Start is called before the first frame update
    void Start()
    {
        srend = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player Performer");

        headingfor = player.transform.position;
        targetTime = Random.Range(2.0f, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        currenttime += Time.deltaTime;
        if (currenttime > targetTime)
        {
            currenttime = 0;
            player = GameObject.Find("Player Performer");
            headingfor = player.transform.position;
            targetTime = Random.Range(0.03f, 0.8f);
        }
        var step = maxMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, headingfor, step);
    }
}
