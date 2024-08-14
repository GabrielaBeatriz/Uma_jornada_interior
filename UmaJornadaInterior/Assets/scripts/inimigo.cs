using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public float speed;
    public float walkTime;
    public bool walkRight = true;
    private float timer;

    public int damage = 1;
    
    

    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        flipInimigo();
    }

    // Update is called once per frame
    private void flipInimigo()
    {
        timer += Time.deltaTime;

        if (timer >= walkTime)
        {
            walkRight = !walkRight;
            timer = 0f;
        }

        if (walkRight)
        {
            transform.eulerAngles = new Vector2(0, 180);
             rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.left * speed;

        }
       
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col != null && !col.collider.CompareTag("Player") && !col.collider.CompareTag("chão") )
        {
            walkRight = !walkRight;
        }
        
        
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<player>().Damage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("fogo"))
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
    
}
