using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player playerScript = collision.gameObject.GetComponent<player>();
            if (playerScript != null)
            {
                playerScript.ApplyParalysis();
            }
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
