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
    public float paralysisDuration = 2f; // Duração da paralisação em segundos
    public bool isParalyzed = false;
    
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
        if (isParalyzed)
        {
            return;
        }
        tiro = Input.GetKeyDown(KeyCode.Z);

        Atirar();
        Move(); 
        Jump();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isParalyzed)
        {
            return;
        }
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
                AudioObserver.OnPlaySfxEvent("pulo");
                ParticleObserver.OnParticleSpawnEvent(transform.position);
            }
        }
    }

    public void Damage (int dmg)
    {
        health -= dmg;
       // GameController.instance.UpdateLives(health);
       UiObserver.OnAtualizarVidaEvent(health);

        if (transform.rotation.y == 0)
        {
            //transform.position += new Vector3(-2, 0, 0);
            rig.AddForce(new Vector2(-2,2),ForceMode2D.Impulse);
        }

        if (transform.rotation.y == 180)
        {
            //transform.position += new Vector3(2, 0, 0);
            rig.AddForce(new Vector2(2,2),ForceMode2D.Impulse);

        }
        
        if (health <=0)
        {
            //chamar game 
            GameController.instance.GameOver();
        }
    }

    public void IncreaseLife(int value)
    {
        health += value;
        GameController.instance.UpdateLives(health);
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
    
    public void ApplyParalysis()
    {
        if (!isParalyzed)
        {
            StartCoroutine(ParalysisCoroutine());
        }
    }

    private IEnumerator ParalysisCoroutine()
    {
        isParalyzed = true;
        anim.SetInteger("transition", 0);
        yield return new WaitForSeconds(paralysisDuration);
        isParalyzed = false;
        StopCoroutine(ParalysisCoroutine());
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 10) // Altere para a camada da bola do inimigo
        {
            ApplyParalysis(); // Aplica paralisia ao jogador
            Destroy(coll.gameObject); // Destroi a bola do inimigo após a colisão (se necessário)
        }
        else if (coll.gameObject.layer == 9)
        {
            GameController.instance.GameOver();

        }
    }
}

