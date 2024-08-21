using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colecionaveis : MonoBehaviour
{
    public int scoreValue;
    public int scoreValue2;
    public int scoreValue3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AudioObserver.OnPlaySfxEvent("coletavel");
            GameController.instance.UpdateScore(scoreValue);
            GameController.instance.UpdateScore2(scoreValue2);
            GameController.instance.UpdateScore3(scoreValue3);
            Destroy(gameObject);
        }
    }
}
