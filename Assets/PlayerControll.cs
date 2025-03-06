using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimentação
    private Rigidbody2D rb2d; // Referência para o Rigidbody2D
    private SpriteRenderer sprite;
    private Vector2 moveDirection; // Direção do movimento
    private GameObject tiro;
    public int vidas = 3;
    private int inv = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tiro = GameObject.Find("T1");
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimentação da nave
        float moveX = Input.GetAxisRaw("Horizontal"); // Movimento na horizontal (A/D ou setas)
        moveDirection = new Vector2(moveX, 0);

        if (Input.GetKeyDown(KeyCode.Space) && tiro.transform.position.y >= 5)
        {
            tiro.transform.position = rb2d.transform.position;
        }

        if(inv > 0)
        {
            inv-=1;
            if(inv%5 == 0)
            {
                sprite.enabled = !sprite.enabled;
            }
        }
        else
        {
            sprite.enabled = true;
        }

    }

    // FixedUpdate é chamado de forma mais consistente para física
    void FixedUpdate()
    {
        // Movimentação do Rigidbody2D
        Vector2 newPos = rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

        // Limitar a posição dentro dos valores especificados
        newPos.x = Mathf.Clamp(newPos.x, -5, 5);  // Limitar o movimento na horizontal

        rb2d.MovePosition(newPos);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name != "T1" && inv == 0 && vidas>0)
        {
            vidas -= 1;
            inv = 1000;
        }
    }
}