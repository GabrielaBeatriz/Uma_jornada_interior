using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject fogoProjetil; // fogo
    public Transform arma; // posiçao de onde sai o tiro
    private bool tiro;
    public float forcaDoTiro; //velocidade do tiro
    private bool flipX = false; 
    
    public int health = 3;
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
        
        GameController.instance.UpdateLives(health);
    }

    private void Update()
    {
        tiro = Input.GetKeyDown(KeyCode.Z);

        Atirar();
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
            if (!isJumping)
            {
                anim.SetInteger("transition", 1);
            }

            transform.eulerAngles = new Vector2(0f, 0f);
        }
        
        else if (inputAxis < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 1);
            }
            transform.eulerAngles = new Vector2(0f, 180f);
        }

        else if (inputAxis == 0 && !isJumping)
        {
            anim.SetInteger("transition", 0);
        }
    }

    void Jump()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            
            if(nPulos > 0)
            {
                nPulos--;
                anim.SetInteger("transition", 2);
                isJumping = true;
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    public void Damage (int dmg)
    {
        health -= dmg;

        if (health <=0)
        {
            //chamar game over
            
            
        }
    }

    private void Atirar()
    {
        if (tiro == true)
        {
            GameObject temp = Instantiate(fogoProjetil);
            temp.transform.position = arma.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaDoTiro, 0);
            Destroy(temp.gameObject, 3f);
        }
    }

}
