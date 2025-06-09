using UnityEngine;

public class EntregaArmas : Entrega
{
    [SerializeField] UsoArma[] ListaDeArmas;
    [SerializeField] bool Ativo;
    [SerializeField] GerenciadorDeCartas cartas;
    void Start()
    {
        cartas = FindAnyObjectByType<GerenciadorDeCartas>();
        ListaDeArmas = Resources.LoadAll<UsoArma>("Armas"); //carrega todas as armas da pasta para o array
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Ativo) //A primeira vez que o jogar se encontra com o objeto aleatoriza a lista de armas e instancia as cartas
        {
            EmbaralharArray(ListaDeArmas);
            if (collision.tag == "Jogador")
            {
                cartas.CriarCarta(collision.GetComponent<JogadorArma>(), ListaDeArmas[0], ListaDeArmas[1]);
                //Como na função CriarCarta o array cartas é declarado como params, pode receber tanto um array quanto um conjunto de componentes

                collision.GetComponent<JogadorAtributos>().ArmaAtiva = false; //Altera a possibilidade do jogador atirar
                Ativo = true;
            }

        }
        else
        {
            if (collision.tag == "Jogador") //Quando o jogador entra na colisão depois da primeira vez apenas reaparece as cartas em vez
                                            //de criar novas
            {
                collision.GetComponent<JogadorAtributos>().ArmaAtiva = false;  //Altera a possibilidade do jogador atirar
                cartas.Aparecer(1);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //Quando o jogador sai da colisão executa o codigo para desaparecer as cartas
    {
        if (collision.tag == "Jogador") 
        {
            collision.GetComponent<JogadorAtributos>().ArmaAtiva = true;  //Altera a possibilidade do jogador atirar
            cartas.Sumir(1);
        }
    }

}
