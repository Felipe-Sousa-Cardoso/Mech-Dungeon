using UnityEngine;

public class EntregaHabilidades : MonoBehaviour
{
    [SerializeField] int nivel; //Define se a habilidade � uma habilidade b�sica ou se vai evoluir a habilidade
    [SerializeField] CadaHabilidade[] listaDeHabilidades;
    bool ativo = false;
    void Start()
    {
        listaDeHabilidades = Resources.LoadAll<CadaHabilidade>("Habilidades"); //carrega todas as habilidades da pasta Resorces para o array    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Jogador")
        {
            collision.GetComponent<JogadorAtributos>().ArmaAtiva = false;//Altera a possibilidade do jogador atirar
            if (!ativo) //Se � a primeira vez que o jogador entra na colis�o instancia as cartas
            {
                GerenciadorDeCartas.instancia.CriarCarta(collision.GetComponent<JogadorHabilidades>(), nivel, listaDeHabilidades);

                ativo = true;
            }
            else //Se n�o for a primeira vez reaparece as cartas
            {
                GerenciadorDeCartas.instancia.Aparecer(2);
            }          
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //Quando o jogador sai da colis�o executa o codigo para desaparecer as cartas
    {
        if (collision.tag == "Jogador")
        {
            collision.GetComponent<JogadorAtributos>().ArmaAtiva = true;  //Altera a possibilidade do jogador atirar
            GerenciadorDeCartas.instancia.Sumir(2);
        }
    }
}
