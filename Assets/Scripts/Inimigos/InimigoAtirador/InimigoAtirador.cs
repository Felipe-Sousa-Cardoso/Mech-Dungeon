using UnityEditor;
using UnityEngine;

public class InimigoAtirador : BaseInimigos
{
    [SerializeField] Transform Arma; //Arma, usada para controlar a posiçao e intanciar as munições
    [SerializeField] Transform Jogador;
    [SerializeField] CadaArmaInimigos dadosDaArma;

    float indexCadencia; //Usado para controlar a cadencia;
    float tempoEntreDisparos;

    Vector3 direção; //A direção que o jogador está

    protected override void Start()
    {
        base.Start();
        Arma.GetComponent<BaseArmaInimigos>().DadosDaArma = dadosDaArma;
        if (dadosDaArma)
        {
            tempoEntreDisparos = 1 / dadosDaArma.Cadencia; //calcula o tempo entre os disparos incial
        }
        
    }

    private void Update()
    {
        if (Arma&&dadosDaArma)
        {
            if (Jogador)
            {
                direção = Jogador.position - transform.position; //Define o vetor direção, como o final menos o inicial

                Arma.transform.localPosition = direção.normalized * 0.3f; //Normaliza o Vetor direção e posiciona a arma à uma distancia de 0.3

                Arma.transform.right = direção; //Aponta a arma para o jogador

                if (indexCadencia < tempoEntreDisparos*modificadorDeVelocidade) //Usa tanto a cadencia como o efeito de gelo para modificar a habilidade
                {
                    indexCadencia += Time.deltaTime;
                }
                else
                {
                    indexCadencia = 0;
                    Atirar();
                }

            }
            else
            {
                Arma.transform.localPosition = new Vector3(0.3f, 0); //Posiciona a arma um pouco a frente do Inimigo
                Arma.transform.right = Vector3.right; //Aponta a arma para frente
            }
        }
    }

    protected virtual void Atirar()
    {
        GameObject obj;
        if (dadosDaArma)
        {
            print("sim");
            obj = Instantiate(dadosDaArma.Munição, Arma.transform.position,Quaternion.FromToRotation(Vector2.right,direção));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//Quando um jogador entra na colisão define a variável 
    {
        if (collision.CompareTag("Jogador")) 
        {
            Jogador = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)//Quando um jogador sai da colisão redefine a variável
    {
        if (collision.CompareTag("Jogador"))
        {
            Jogador = null;
        }
    }
}
