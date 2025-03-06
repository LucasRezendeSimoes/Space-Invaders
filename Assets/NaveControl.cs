using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private float x;
    private float speed = 10.0f;
    private float qtd = 14f;
    private GameObject[] tiros;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  
        x = transform.position.x;

        var vel = rb2d.velocity;
        vel.x = speed/qtd;
        vel.y = -0.05f;
        rb2d.velocity = vel;

        tiros = GameObject.FindGameObjectsWithTag("Tiro");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] bots = GameObject.FindGameObjectsWithTag("Bot");
        timer += Time.deltaTime*2/qtd;
        if (timer >= waitTime){
            qtd = bots.Length;
            ChangeState();
            timer = 0.0f;
        }

        foreach(GameObject t in tiros)
        {
            if(t.transform.position.y < -5)
            {
                if(Random.Range(0,2) == 0)
                {
                    t.transform.position = bots[Random.Range(0,bots.Length)].transform.position;
                }
            }
        }
    }
    void ChangeState(){
        var vel = rb2d.velocity;
        speed *= -1;
        vel.x = speed/qtd;
        rb2d.velocity = vel;
    }
}
