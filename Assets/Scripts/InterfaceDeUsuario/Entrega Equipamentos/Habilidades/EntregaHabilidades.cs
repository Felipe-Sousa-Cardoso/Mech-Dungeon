using UnityEngine;

public class EntregaHabilidades : MonoBehaviour
{
    [SerializeField] int nivel; //Define se a habilidade é uma habilidade básica ou se vai evoluir a habilidade
    [SerializeField] CadaHabilidade[] listaDeHabilidades;
    void Start()
    {
        listaDeHabilidades = Resources.LoadAll<CadaHabilidade>("Habilidades"); //carrega todas as habilidades da pasta Resorces para o array    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Jogador")
        {
            GerenciadorDeCartas.instancia.CriarCarta(collision.GetComponent<JogadorHabilidades>(), nivel, listaDeHabilidades);
        }
    }
}
