using UnityEngine;

public class EntregaArmas : Entrega
{
    [SerializeField] UsoArma[] ListaDeArmas;
    [SerializeField] bool Ativo;
    void Start()
    {
        ListaDeArmas = Resources.LoadAll<UsoArma>("Armas"); //carrega todas as armas da pasta para a lista     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Ativo) //A primeira vez que o jogar se encontra com o objeto aleatoriza a lista de dashs
        {
            EmbaralharArray(ListaDeArmas);
            if (collision.tag == "Jogador")
            {
                GerenciadorDeCartas.instancia.CriarCarta(collision.GetComponent<JogadorArma>(), ListaDeArmas[0], ListaDeArmas[1]);
                //Como na função CriarCarta o array cartas é declarado como params, pode receber tanto um array quanto um conjunto de componentes

                collision.GetComponent<JogadorAtributos>().ArmaAtiva = false; //Altera a possibilidade do jogador atirar
                Ativo = true;
            }

        }
        else
        {
            if (collision.tag == "Jogador")
            {
                collision.GetComponent<JogadorAtributos>().ArmaAtiva = false;  //Altera a possibilidade do jogador atirar
                GerenciadorDeCartas.instancia.Aparecer();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Jogador")
        {
            collision.GetComponent<JogadorAtributos>().ArmaAtiva = true;  //Altera a possibilidade do jogador atirar
            GerenciadorDeCartas.instancia.Sumir();
        }
    }

}
