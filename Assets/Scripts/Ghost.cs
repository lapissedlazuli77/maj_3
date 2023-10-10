using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float maxMoveSpeed;
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

    string typing;

    // Start is called before the first frame update
    void Start()
    {
        srend = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player Performer");

        headingfor = player.transform.position;
        maxMoveSpeed = Random.Range(0.06f, 0.6f);
        targetTime = Random.Range(2.0f, 6.0f);

        DetermineType();
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

        if (health <= 0) { Destroy(gameObject); }
    }

    void DetermineType()
    {
        int typechoice = Random.Range(1, 7);
        if (typechoice < 4)
        {
            srend.sprite = baseghost;
            typing = "Base";
            health = 1;
        }
        else
        {
            health = 4;
            if (typechoice == 4)
            {
                srend.sprite = violinghost;
                typing = "Violin";
            }
            if (typechoice == 5)
            {
                srend.sprite = clarinetghost;
                typing = "Clarinet";
            }
            if (typechoice == 6)
            {
                srend.sprite = tubaghost;
                typing = "Tuba";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            string notetype = collision.gameObject.GetComponent<Note>().typing;
            Destroy(collision.gameObject);
            health--;
            if (notetype == typing) { health -= 3; }
        }
    }
}
