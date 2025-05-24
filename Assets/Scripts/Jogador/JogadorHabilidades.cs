using UnityEngine;

public class JogadorHabilidades : MonoBehaviour
{
    JogadorAtributos jogadorAtributos; //Script que controla atributos gerais do jogador

    [SerializeField] Transform OrganizarHabilidades; //O transform onde deve ser instanciado cada habilidade

    [SerializeField] DadosDaHabilidade ddHabilidades; //Faz a comuncação com a inteface atraves de m objeto escriptavel

    [SerializeField] CadaHabilidade habilidadeQ; //Armazena o prefab que controla cada habilidade,
                                                 //para funcionar corretamente precisa ser instanciado
    [SerializeField] CadaHabilidade instanciaHabilidadeQ;

    int nivel; //O nivel atual da habilidade


    public DadosDaHabilidade DdHabilidades { get => ddHabilidades; set => ddHabilidades = value; }
    public CadaHabilidade HabilidadeQ { get => habilidadeQ; set => habilidadeQ = value; }
    public CadaHabilidade InstanciaHabilidadeQ { get => instanciaHabilidadeQ; set => instanciaHabilidadeQ = value; }
    public int Nivel { get => nivel; set => nivel = value; }

    private void Awake()
    {
        jogadorAtributos = GetComponent<JogadorAtributos>();
        
    }

    void Start()
    {
        UpdateHabilidades();
    }

    // Update is called once per frame
    void Update()
    {
        if (jogadorAtributos != null)
        {
            if (jogadorAtributos.ArmaAtiva)
            {
                if (ControladorDeInput.GetHabilidadeQInput())
                {
                    if (InstanciaHabilidadeQ != null&&!ddHabilidades.recarregando) //Verifica se o jogador tem algum habilidade equipada e que ela não esteja recarregando                                                                        
                    {
                        InstanciaHabilidadeQ.UsarHabilidade(this);
                    }                   
                }                
            }
        } 
    }
    public void UpdateHabilidades()
    {
        ddHabilidades.troca = true; //Avisa que ocorreu de troca do icone da habilidade

        
        if (InstanciaHabilidadeQ == null&&HabilidadeQ)//Verifica se o prefab não foi instanciado e se ele está armazenado nesse objeto
        {
            InstanciaHabilidadeQ = Instantiate(HabilidadeQ, OrganizarHabilidades);//intancia o objeto responsável pela habilidade atual e guarda em uma referencia
            ddHabilidades.habilidade = InstanciaHabilidadeQ.GetComponent<CadaHabilidade>().Index;
        }
        

        ddHabilidades.CDrecarga = 5; //Seta os valores da Recarga
        ddHabilidades.TimerRecarga = 0;

        if (InstanciaHabilidadeQ) //Verifica se a instancia já foi atualizada
        {
            if (InstanciaHabilidadeQ.Sprites != null && InstanciaHabilidadeQ.Nivel < InstanciaHabilidadeQ.Sprites.Length)
            //Verifica se a habilidade tem sprites e se o nível é valido
            {
                ddHabilidades.sprite = InstanciaHabilidadeQ.Sprites[InstanciaHabilidadeQ.Nivel]; //Define a sprite para a sprite do nível atual
            }
        }
        
        
    }
}
