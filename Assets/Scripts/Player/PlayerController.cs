using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    //components etc.
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    //mouvement stuff
    public float speed;
    public float jumpForce;

    //Attack Stuff
    
    
    //grounc checking
    public bool isGrounded;
    public Transform GroundCheck;
    public LayerMask isgGroundLayer;
    public float GroundCheckRadius;

    public PlayerController()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        if (speed <= 0)
        {
            speed = 6.0f;
        }

        if (jumpForce <= 0)
        {
            jumpForce = 300;
        }

        if (!GroundCheck)
        {
            GroundCheck = GameObject.FindGameObjectWithTag("Groundcheck").transform;
        }

        if (GroundCheckRadius <= 0)
        {
            GroundCheckRadius = 0.2f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo [] curPlayingClip = anim.GetCurrentAnimatorClipInfo(0);
        float hInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, isgGroundLayer);

        if (curPlayingClip.Length > 0)
        {
            if (Input.GetButtonDown("Fire1") && curPlayingClip[0].clip.name != "Fire")
            anim.SetTrigger("Fire");
            else if (curPlayingClip[0].clip.name == "Fire")
                rb.velocity = Vector2.zero;
            else
            {
                Vector2 moveDirection = new Vector2(hInput * speed, rb.velocity.y);
                rb.velocity = moveDirection; 
            }
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (!isGrounded && Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("JumpAttack");
        }
        
        anim.SetFloat("hInput", Mathf.Abs(hInput));
        anim.SetBool("isGrounded", isGrounded);

        //flip stuff
        if (hInput != 0)
            sr.flipX = (hInput < 0);
    }   
}
