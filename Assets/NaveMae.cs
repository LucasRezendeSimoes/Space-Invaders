using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMae : MonoBehaviour
{
    // Start is called before the first frame update
    private int timer =  1000;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            if(transform.position.x <= -12)
            {
                rb2d.velocity = new Vector2(5f,0);
            }
            else if(transform.position.x >= 12)
            {
                rb2d.velocity = new Vector2(-5f,0);
            }
            timer = Random.Range(1000, 2000);
        }
        else{
            timer -= 1;
            if(transform.position.x <= -12 || transform.position.x >= 12){
                rb2d.velocity = Vector2.zero;
            }
        }
    }
}
