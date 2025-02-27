using UnityEngine;

public class Projétil : MonoBehaviour
{
    public float velocidade = 10f;

    void Update()
    {
        // Mover o projétil para frente
        transform.Translate(Vector3.up * velocidade * Time.deltaTime);
    }

    // Detectar colisão (opcional, pode ser útil mais tarde)
    private void OnCollisionEnter2D(Collision2D colisao)
    {
        // Aqui você pode adicionar código para destruir o projétil ou lidar com a colisão
        Destroy(gameObject);
    }
}