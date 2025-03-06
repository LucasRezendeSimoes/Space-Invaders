using UnityEngine;

public class Projétil : MonoBehaviour
{
    public float velocidade = 7f;
    public bool player = false;

    void Start()
    {
        if(gameObject.name == "T1")
        {
            player = true;
        }
    }

    void Update()
    {
        if(player)
        {
            if(transform.position.y < 6)
            {
                transform.Translate(Vector3.up * velocidade * Time.deltaTime);
            }
        }
        else
        {
            if(transform.position.y > -6)
            {
                transform.Translate(Vector3.down * velocidade/2 * Time.deltaTime);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Bot" && player)
        {
            Destroy(coll.gameObject);
            transform.position = new Vector2(0f, 6f);
        }
        else if(coll.gameObject.name == "Mae" && player)
        {
            Destroy(coll.gameObject);
            transform.position = new Vector2(0f, 6f);
        }
    }
}