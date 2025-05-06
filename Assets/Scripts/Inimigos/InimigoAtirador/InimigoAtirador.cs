using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

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
                dire��o = (Jogador.position - transform.position).normalized; //Define e normaliza o vetor dire��o, como o final menos o inicial

                Arma.transform.localPosition = dire��o * 0.3f; //Posiciona a arma � uma distancia de 0.3

                Arma.transform.right = dire��o; //Aponta a arma para o jogador

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
            
            for (int i = 0; i < dadosDaArma.Muni��esPorDisparo; i++) //Repete para cada muni��o da arma
            {
                Vector3 dire��oFinal = Quaternion.Euler(0, 0, Random.Range(-dadosDaArma.Precis�o, dadosDaArma.Precis�o)) * dire��o;
                //Cria um vector 3 dire��o final que o o produto da dire��o da arma com um valor que depende da precis�o de cada arma, a multiplica��o de um
                //Vector 3 por um quarternion representa uma mudan�a apenas de dire��o, sem alterar o modulo
                obj = Instantiate(dadosDaArma.Muni��o, Arma.transform.position, Quaternion.FromToRotation(Vector2.right, dire��oFinal));
                //Instancia o proj�til, na posi��o da arma e com a rota��o da arma alterda pela posi��o
                obj.GetComponent<Rigidbody2D>().linearVelocity = dire��oFinal * dadosDaArma.Velocidade;
                //Adiciona uma velocidade para o proj�til

                obj.GetComponent<Muni��oInimigos>().Dano = dadosDaArma.Dano;
                Destroy(obj, (dadosDaArma.Alcance-0.3f) / dadosDaArma.Velocidade );
                //Calcula o tempo de vida do proj�til como a divs�o do alcance pela velociade, se caso o obj j� tiver sido destruido essa
                //linha n�o retorna erro nem executa nenhuma a��o
            }
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
