using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    Rigidbody2D rbody;
    SpriteRenderer srend;
    float horizMove;
    public float speedmodify;
    public string direct = "right";

    public bool grounded = false;
    public float castDist = 0.2f;

    public float jumpLimit = 2f;
    public float gravityScale = 5f;
    public float gravityFall = 40f;
    bool jump = false;

    public AudioSource stepsound;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        srend = GetComponent<SpriteRenderer>();
        stepsound.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizMove = Input.GetAxis("Horizontal");
        if (horizMove > -0.2f && horizMove < 0.2f)
        {
            stepsound.volume = 0;
        } else
        {
            stepsound.volume = 0.5f;
            if (horizMove < -0.2f)
            {
                srend.flipX = true;
                direct = "left";
            } else if (horizMove > 0.2f)
            {
                srend.flipX = false;
                direct = "right";
            }
        }
        if (Input.GetKey("space") && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        HorizontalMove(horizMove);
        if (jump)
        {
            rbody.AddForce(Vector2.up * jumpLimit, ForceMode2D.Impulse);
            jump = false;
        }
        if (rbody.velocity.y >= 0)
        {
            rbody.gravityScale = gravityScale;
        }
        else if (rbody.velocity.y < 0)
        {
            rbody.gravityScale = gravityFall;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);
        Debug.DrawRay(transform.position, Vector2.down * castDist, new Color(255, 0, 0));
        if (hit.collider != null && hit.transform.name == "Platform")
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
    void HorizontalMove(float toMove)
    {
        float moveX = toMove * speedmodify * Time.fixedDeltaTime;
        rbody.velocity = new Vector3(moveX, rbody.velocity.y);
    }
}
