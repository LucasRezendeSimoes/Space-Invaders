using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private PlayerControll script;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Bot"){
            GameObject refPlayer = GameObject.Find("Nave");
            PlayerControll player = refPlayer.GetComponent<PlayerControll>();
            player.vidas = 0;
        }
    }
}
