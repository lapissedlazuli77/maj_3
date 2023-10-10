using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruments : MonoBehaviour
{
    SpriteRenderer srend;

    BasicMovement player;
    public GameObject fire1;
    public GameObject fire2;
    string instrum = "Violin";

    public Sprite violinweapon;
    public Sprite clarinetweapon;
    public Sprite tubaweapon;

    public Note vionote;
    public Note clarinote;
    public Note tunote;

    public AudioSource playsound;

    public AudioClip vioplay;
    public AudioClip clariplay;
    public AudioClip tuplay;

    // Start is called before the first frame update
    void Start()
    {
        srend = GetComponent<SpriteRenderer>();
        player = GetComponent<BasicMovement>();
        playsound.clip = vioplay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            srend.sprite = violinweapon;
            instrum = "Violin";
            playsound.clip = vioplay;
        }
        if (Input.GetKey("2"))
        {
            srend.sprite = clarinetweapon;
            instrum = "Clarinet";
            playsound.clip = clariplay;
        }
        if (Input.GetKey("3"))
        {
            srend.sprite = tubaweapon;
            instrum = "Tuba";
            playsound.clip = tuplay;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (player.direct == "right")
            {
                Fire(fire1);
            }
            if (player.direct == "left")
            {
                Fire(fire2);
            }
        }
    }
    public void Fire(GameObject shooter)
    {
        Vector3 position = shooter.transform.position;
        if (instrum == "Violin")
        {
            for (int v = 0; v < 5; v++)
            {
                float speedeffect = Random.Range(0.01f, 0.02f);
                Note vio = (Note)Instantiate(vionote, position, Quaternion.identity);
                vio.GetComponent<Rigidbody2D>().AddForce(shooter.transform.up * speedeffect);
            }
        }
        if (instrum == "Clarinet")
        {
            for (int v = 0; v < 3; v++)
            {
                position.y += Random.Range(-0.2f, 0.2f);
                float speedeffect = Random.Range(0.011f, 0.013f);
                Note clar = (Note)Instantiate(clarinote, position, Quaternion.identity);
                clar.GetComponent<Rigidbody2D>().AddForce(shooter.transform.up * speedeffect);
            }
        }
        if (instrum == "Tuba")
        {
            Note tub = (Note)Instantiate(tunote, position, Quaternion.identity);
            tub.GetComponent<Rigidbody2D>().AddForce(shooter.transform.up * 0.004f);
        }
        playsound.Play();
    }
}
