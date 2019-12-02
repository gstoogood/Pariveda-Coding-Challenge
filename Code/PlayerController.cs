using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpPower;
    private float moveInput;

    private Rigidbody2D rb;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private bool facingRight = true;
    private bool facingUp= true;
    private bool isGrounded;
    public Collider2D[] whatIsGround;
    public Collider2D whatIsCharacter;

    private int extraJumps;
    public int extraJumpsValue;

    // Use this for initialization
    void Start()
    {
        extraJumps = extraJumpsValue;
        //Get and store a reference to the Rigidbody2D component so that we can access it
        rb = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate.
    //physics code here.
    void FixedUpdate()
    {
        //Sees if the char is touching any of the set Ground pieces, if not set isGrounded to false
        //used for extra jumps
        int count = 0;
        for(int i = 0; i < whatIsGround.Length; i++)
        {
            if (whatIsGround[i].IsTouching(whatIsCharacter))
            {
                isGrounded = whatIsGround[i].IsTouching(whatIsCharacter);
            }
            else
            {
                count++;
            }
        }
        Debug.Log(count);
        if(count == whatIsGround.Length)
        {
            isGrounded = false;
        }
        
        Debug.Log(isGrounded);
        moveInput = Input.GetAxis("Horizontal");
        //Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    public void Update()
    {
        //if the character has touched the ground, they gain their extra jumps back.
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            //Debug.Log(extraJumps);
        }
        //physics code for jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpPower;
            extraJumps--;
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpPower;
        }
        //escape to main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LevelControlScript.instance.LoadMainMenu();
        }
    }
    void Flip()
    {
        //transforms the scale of the sprite to the negative values, effectively flipping the sprite
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}