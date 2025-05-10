using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class InimigoAtirador : BaseInimigos
{
    [SerializeField] Transform Arma; //Arma, usada para controlar a posiçao e intanciar as munições
    
    CadaArmaInimigos dadosDaArma;

    float indexCadencia; //Usado para controlar a cadencia;
    float tempoEntreDisparos;

    Vector3 direção; //A direção que o jogador está

    protected override void Start()
    {
        base.Start();

        dadosDaArma = dados as CadaArmaInimigos;
        detector.radius = dadosDaArma.Alcance;

        Arma.GetComponent<BaseArmaInimigos>().DadosDaArma = dadosDaArma;
        Arma.GetComponent<BaseArmaInimigos>().UpdateFoto();
        if (dadosDaArma)
        {
            tempoEntreDisparos = 1 / dadosDaArma.Cadencia; //calcula o tempo entre os disparos incial
        }
        
    }

    protected override void Update()
    {      
        Move();   
        if (Arma&&dadosDaArma)
        {
            if (Jogador)
            {
                direção = (Jogador.position - transform.position).normalized; //Define e normaliza o vetor direção, como o final menos o inicial

                Arma.transform.localPosition = direção * dadosDaArma.distanciaDaArma; //Posiciona a arma à uma distancia de 0.3

                Arma.transform.right = new Vector3(direção.x, direção.y, 0); ; //Aponta a arma para o jogador

                if (indexCadencia < tempoEntreDisparos/modificadorDeVelocidade) //Usa tanto a cadencia como o efeito de gelo para modificar o tempo
                                                                                //entre os disparos 

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
                Arma.transform.localPosition = new Vector3(dadosDaArma.distanciaDaArma, 0); //Posiciona a arma um pouco a frente do Inimigo
                Arma.transform.right = Vector3.right; //Aponta a arma para frente
            }
        }
    }

    protected virtual void Atirar()
    {
        GameObject obj;
        if (dadosDaArma)
        {
            
            for (int i = 0; i < dadosDaArma.MuniçõesPorDisparo; i++) //Repete para cada munição da arma
            {
                Vector3 direçãoFinal = Quaternion.Euler(0, 0, Random.Range(-dadosDaArma.Precisão, dadosDaArma.Precisão)) * direção;
                //Cria um vector 3 direção final que o o produto da direção da arma com um valor que depende da precisão de cada arma, a multiplicação de um
                //Vector 3 por um quarternion representa uma mudança apenas de direção, sem alterar o modulo
                obj = Instantiate(dadosDaArma.Munição, Arma.transform.position, Quaternion.FromToRotation(Vector2.right, direçãoFinal));
                //Instancia o projétil, na posição da arma e com a rotação da arma alterda pela posição
                obj.GetComponent<Rigidbody2D>().linearVelocity = direçãoFinal * dadosDaArma.Velocidade;
                //Adiciona uma velocidade para o projétil

                obj.GetComponent<MuniçãoInimigos>().Dano = dadosDaArma.Dano;
                Destroy(obj, (dadosDaArma.Alcance - dadosDaArma.distanciaDaArma) / dadosDaArma.Velocidade );
                //Calcula o tempo de vida do projétil como a divsão do alcance pela velociade, se caso o obj já tiver sido destruido essa
                //linha não retorna erro nem executa nenhuma ação
            }
        }
    }

   
    
}
