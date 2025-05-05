using UnityEditor;
using UnityEngine;

public class InimigoAtirador : BaseInimigos
{
    [SerializeField] Transform Arma; //Arma, usada para controlar a posi�ao e intanciar as muni��es
    [SerializeField] Transform Jogador;
    [SerializeField] CadaArmaInimigos dadosDaArma;

    float indexCadencia; //Usado para controlar a cadencia;
    float tempoEntreDisparos;

    Vector3 dire��o; //A dire��o que o jogador est�

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
                dire��o = Jogador.position - transform.position; //Define o vetor dire��o, como o final menos o inicial

                Arma.transform.localPosition = dire��o.normalized * 0.3f; //Normaliza o Vetor dire��o e posiciona a arma � uma distancia de 0.3

                Arma.transform.right = dire��o; //Aponta a arma para o jogador

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
            obj = Instantiate(dadosDaArma.Muni��o, Arma.transform.position,Quaternion.FromToRotation(Vector2.right,dire��o));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//Quando um jogador entra na colis�o define a vari�vel 
    {
        if (collision.CompareTag("Jogador")) 
        {
            Jogador = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)//Quando um jogador sai da colis�o redefine a vari�vel
    {
        if (collision.CompareTag("Jogador"))
        {
            Jogador = null;
        }
    }
}
