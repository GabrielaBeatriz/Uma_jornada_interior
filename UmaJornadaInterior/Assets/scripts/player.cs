using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    public float Speed;
    public float jumpForce;

    public bool isJumping;

    public Animator anim;

    private Rigidbody2D rig;

    public int nPulos;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Jump();
    }

    

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        float inputAxis = Input.GetAxis("Horizontal");

        if (inputAxis > 0)
        {
            anim.SetInteger("transition", 1);
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        
        if (inputAxis < 0)
        {
            anim.SetInteger("transition", 1);
            transform.eulerAngles = new Vector2(0f, 180f);
        }

        if (inputAxis == 0 && !isJumping)
        {
            anim.SetInteger("transition", 0);
        }
    }

    void Jump()
    {
        
        if (Input.GetButtonDown("Jump") )
        {
            anim.SetInteger("transition", 2);
            if(nPulos > 0)
            {
                nPulos--;
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }
}
