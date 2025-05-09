using Unity.Burst.Intrinsics;
using UnityEngine;

public class CadaHabilidadeChefe : MonoBehaviour
{
    [SerializeField] Transform jogador;
    Vector3 dire��o;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jogador)
        {
            dire��o = (jogador.position - transform.position).normalized; //Define e normaliza o vetor dire��o, como o final menos o inicial
            transform.right = dire��o; //Aponta a arma para o jogador
        }
        else
        {
            transform.right = Vector3.right;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)//Quando um jogador entra na colis�o define a vari�vel 
    {
        if (collision.CompareTag("Jogador"))
        {
            jogador = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)//Quando um jogador sai da colis�o redefine a vari�vel
    {
        if (collision.CompareTag("Jogador"))
        {
            jogador = null;
        }
    }
}
