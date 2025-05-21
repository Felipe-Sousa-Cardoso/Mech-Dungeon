using UnityEngine;

public class Porta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jogador"))
        {
            Destroy(gameObject);
        }
    }
}
