using UnityEngine;

public class MuniçãoInimigos : MonoBehaviour
{
   [SerializeField] float dano;
    public float Dano { get => dano; set => dano = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDanificavel obj = collision.GetComponent<IDanificavel>();

        if (collision.CompareTag("Escudos")|| collision.CompareTag("Jogador") && obj!=null)
        {
            obj.Danificar(dano);//Executa o dano

            Destroy(gameObject); //Destroi a munição quando ela atinge o jogador
        }
        if (collision.CompareTag("Paredes"))
        {
            Destroy(gameObject);
        }
    }
}
