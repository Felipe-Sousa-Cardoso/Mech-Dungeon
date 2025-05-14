using Unity.Burst.Intrinsics;
using UnityEngine;

public class CadaHabilidadeChefe : MonoBehaviour, IDanificavel
{
    ParticleSystem ps;

    [SerializeField] int posi��o; //Cada uma das 4 possiveis posi��es da arma
    [SerializeField] Transform jogador;
    [SerializeField] Transform arma; //Trasform que contem o objeto da arma
    [SerializeField] float vida;

    [SerializeField] SpriteRenderer spriteDaHabilidade;

    [SerializeField] CadaArmaInimigos dadosDaArma; //contem os dados da arma principal da habilidade

    [SerializeField] AtivarHabilidadeChefe habilidade; //contem os dados da habildade dessa arma, precisa ser instanciado para funcionar corretamente

    [SerializeField] AtivarHabilidadeChefe habilidadeinstanciada; //vari�vel que armazena o objeto que executa a mecanica da habilidade

    Vector3 dire��o;

    float indexCadencia; //Usado para controlar a cadencia;
    float tempoEntreDisparos;

    public Transform Jogador { get => jogador; set => jogador = value; }
    public AtivarHabilidadeChefe Habilidadeinstanciada { get => habilidadeinstanciada; set => habilidadeinstanciada = value; }
    public int Posi��o { get => posi��o; set => posi��o = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Random.Range(1, 3) == 1)
        {
            habilidade = Resources.Load<AtivarHabilidadeChefe>("Inimigos/HabilidadesChefe/ChefeCadencia");
        }
        else
        {
            habilidade = Resources.Load<AtivarHabilidadeChefe>("Inimigos/HabilidadesChefe/ChefeDano");
        }
        ps = GetComponent<ParticleSystem>(); 


        spriteDaHabilidade.color = dadosDaArma.CorDaArma;

        if (habilidade)
        {
            habilidadeinstanciada = Instantiate(habilidade, transform);//instancia a habilidade para que ela possa funcionar corretamente
        }
        

        switch (Posi��o) //Usa o valor da posi��o para ficar na posi��o correta
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

    void Update()
    {
        if (Jogador && habilidadeinstanciada) // verifica se a habilidade foi instanciada corretamente e se o jogador est� dentro do detector
        {
            dire��o = (Jogador.position - arma.transform.position).normalized; //Define e normaliza o vetor dire��o, como o final menos o inicial
            arma.transform.right = new Vector3( dire��o.x,dire��o.y,0); //Aponta a arma para o jogador

            if (indexCadencia < tempoEntreDisparos) //Usa a cadencia para modificar o tempo entre os disparos
            {
                indexCadencia += Time.deltaTime* habilidadeinstanciada.ModCadencia;
            }
            else
            {
                indexCadencia = 0;
                Atirar();
            }
        }
        else //Para inalizar que o jogador n foi detectado, todas as armas apontam para frente
        {
            arma.transform.right = Vector3.right; 
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
                obj = Instantiate(dadosDaArma.Muni��o, transform.position, Quaternion.FromToRotation(Vector2.right, dire��oFinal));
                //Instancia o proj�til, na posi��o da arma e com a rota��o da arma alterda pela posi��o
                obj.GetComponent<Rigidbody2D>().linearVelocity = dire��oFinal * dadosDaArma.Velocidade;
                //Adiciona uma velocidade para o proj�til

                obj.GetComponent<Muni��oInimigos>().Dano = dadosDaArma.Dano*habilidadeinstanciada.ModDano;

                Destroy(obj, (dadosDaArma.Alcance - dadosDaArma.distanciaDaArma) / dadosDaArma.Velocidade);
                //Calcula o tempo de vida do proj�til como a divs�o do alcance pela velociade, se caso o obj j� tiver sido destruido essa
                //linha n�o retorna erro nem executa nenhuma a��o
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

    [System.Obsolete]
    public void Ativar()
    {
        if (habilidadeinstanciada)
        {
            ps.Play();
            habilidadeinstanciada.Ativar();
            ps.startColor = habilidadeinstanciada.Cor;
        }
    }
        
    private void OnDestroy()
    {
        if (GetComponentInParent<TodasAsHabilidadesChefe>() != null)
        {
            GetComponentInParent<TodasAsHabilidadesChefe>().TodasAsHabilidades.Remove(this); //Se remove da lista que tinha sido adicionado anteriormente
        }
       
    }
}
