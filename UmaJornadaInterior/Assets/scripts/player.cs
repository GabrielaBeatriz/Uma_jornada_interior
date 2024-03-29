using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float Speed;
    public float jumpForce;

    public bool isJumping;

    private Rigidbody2D rig;

    private int nPulos = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        CheckInput();
    }

    void CheckInput()
    {
        if (gameObject.layer == 8)
        {
            nPulos = 2; 
        }

        if (Input.GetKeyDown(KeyCode.Space) && nPulos > 0)
        {
            Jump();
        }
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        float inputAxis = Input.GetAxis("Horizontal");

        if (inputAxis > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        
        if (inputAxis < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }

    void Jump()
    {
        
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
