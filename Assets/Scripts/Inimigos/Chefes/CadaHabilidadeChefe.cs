using Unity.Burst.Intrinsics;
using UnityEngine;

public class CadaHabilidadeChefe : MonoBehaviour
{
    [SerializeField] Transform jogador;
    Vector3 direção;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jogador)
        {
            direção = (jogador.position - transform.position).normalized; //Define e normaliza o vetor direção, como o final menos o inicial
            transform.right = direção; //Aponta a arma para o jogador
        }
        else
        {
            transform.right = Vector3.right;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)//Quando um jogador entra na colisão define a variável 
    {
        if (collision.CompareTag("Jogador"))
        {
            jogador = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)//Quando um jogador sai da colisão redefine a variável
    {
        if (collision.CompareTag("Jogador"))
        {
            jogador = null;
        }
    }
}
