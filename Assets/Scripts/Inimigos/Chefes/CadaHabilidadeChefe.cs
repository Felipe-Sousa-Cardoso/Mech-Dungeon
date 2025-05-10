using Unity.Burst.Intrinsics;
using UnityEngine;

public class CadaHabilidadeChefe : MonoBehaviour, IDanificavel
{
    [SerializeField] int posição; //Cada uma das 5 possiveis posições da arma
    [SerializeField] Transform jogador;
    [SerializeField] Transform arma; //Trasform que contem o objeto da arma
    [SerializeField] float vida;
    [SerializeField] CadaArmaInimigos dadosDaArma; //contem os dados da arma principal da habilidade
    [SerializeField] AtivarHabilidadeChefe habilidade; //contem os dados da habildade dessa arma
    float indexHabilidade;

    Vector3 direção;

    float indexCadencia; //Usado para controlar a cadencia;
    float tempoEntreDisparos;

    public Transform Jogador { get => jogador; set => jogador = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (posição)
        {
            case 0: transform.localPosition = new Vector2(0.6f,0.6f); break;
            case 1: transform.localPosition = new Vector2(0.6f, -0.6f); break;
            case 2: transform.localPosition = new Vector2(-0.6f, -0.6f); break;
            case 3: transform.localPosition = new Vector2(-0.6f, 0.6f); break;
        }
        if (dadosDaArma)
        {
            tempoEntreDisparos = 1 / dadosDaArma.Cadencia; //calcula o tempo entre os disparos incial
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Jogador)
        {
            direção = (Jogador.position - arma.transform.position).normalized; //Define e normaliza o vetor direção, como o final menos o inicial
            arma.transform.right = new Vector3( direção.x,direção.y,0); //Aponta a arma para o jogador

            if (indexCadencia < tempoEntreDisparos) //Usa a cadencia para modificar o tempo entre os disparos
            {
                indexCadencia += Time.deltaTime*habilidade.Mod;
            }
            else
            {
                indexCadencia = 0;
                Atirar();
            }
            if (indexHabilidade < 5)
            {
                indexHabilidade += Time.deltaTime;
            }
            else
            {
                indexHabilidade = 0;
                habilidade.Ativar();
            }

        }
        else
        {
            arma.transform.right = Vector3.right; 
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
                obj = Instantiate(dadosDaArma.Munição, transform.position, Quaternion.FromToRotation(Vector2.right, direçãoFinal));
                //Instancia o projétil, na posição da arma e com a rotação da arma alterda pela posição
                obj.GetComponent<Rigidbody2D>().linearVelocity = direçãoFinal * dadosDaArma.Velocidade;
                //Adiciona uma velocidade para o projétil

                obj.GetComponent<MuniçãoInimigos>().Dano = dadosDaArma.Dano;

                Destroy(obj, (dadosDaArma.Alcance - dadosDaArma.distanciaDaArma) / dadosDaArma.Velocidade);
                //Calcula o tempo de vida do projétil como a divsão do alcance pela velociade, se caso o obj já tiver sido destruido essa
                //linha não retorna erro nem executa nenhuma ação
            }
        }
    }
    public void Danificar(float Quanto)
    {
        vida -= Quanto;
        if (vida <= 0)
        {
            Destroy(gameObject, 0.3f);
        }
    }
}
