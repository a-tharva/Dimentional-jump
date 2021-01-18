using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int gems = 0;
    [SerializeField] private Text gemstext;


    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10);
        }

        /*OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Collectable")
            {
                Destroy(collection.gameObject);
                gems += 1;
            }
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision) //Trigger for Collectables
    {
        if(collision.tag == "Collectable")
        {
            Destroy(collision.gameObject); //Cherry destroy
            gems += 1;
            gemstext.text = gems.ToString();
        }
    }
}

/*
public class PlayerController : MonoBehaviour
{   
    //Start() variables
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    public int cherries = 0;
    
    //FSM
    private enum State {idle, running, jumping, falling}
    private State state = State.idle;

    //Inspector variables
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }
    private void Update()
    {
        Movement();
        AnimationState();
        anim.SetInteger("state", (int)state); //sets animation based on Enumerator state
    }
    private void OnTriggerEnter2D(Collider2D collision) //Trigger for Collectables
    {
        if(collision.tag == "Collectable")
        {
            Destroy(collision.gameObject); //Cherry destroy
            cherries += 1;
        }
    }
    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        //Moving left
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        //Moving right
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        //Jumping
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jumping;
        }
    }
    private void AnimationState()
    {
        if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
       else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        
        else if(Mathf.Abs (rb.velocity.x) > 2f)
        {
            //Moving
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }
}*/