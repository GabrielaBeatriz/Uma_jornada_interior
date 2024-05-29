using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theo : MonoBehaviour
{
    
    public float Speed;
    public float StoopingDistance;
    private Transform Target; 
    
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Target.position) > StoopingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        }
    }

}
