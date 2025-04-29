using UnityEngine;

public class JogadorHabilidades : MonoBehaviour
{
    JogadorAtributos jogadorAtributos; //Script que controla atributos gerais do jogador

    [SerializeField] Transform OrganizarHabilidades; //O transform onde deve ser instanciado cada habilidade

    [SerializeField] DadosDaHabilidade ddHabilidades; //Faz a comuncação com a inteface atraves de m objeto escriptavel

    [SerializeField] CadaHabilidade habilidadeQ; //Armazena o prefab que controla cada habilidade,
                                                 //para funcionar corretamente precisa ser instanciado
    [SerializeField] CadaHabilidade InstanciaHabilidadeQ;


    public DadosDaHabilidade DdHabilidades { get => ddHabilidades; set => ddHabilidades = value; }

    private void Awake()
    {
        jogadorAtributos = GetComponent<JogadorAtributos>();
        UpdateHabilidades();
    }
    void Start()
    {
        
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            UpdateHabilidades();
        }
       
    }
    void UpdateHabilidades()
    {
        ddHabilidades.troca = true; //Avisa que ocorreu de troca do icone da habilidade

       
        if (InstanciaHabilidadeQ == null)
        {
            InstanciaHabilidadeQ = Instantiate(habilidadeQ, OrganizarHabilidades);//intancia o objeto responsável pela habilidade atual e guarda em uma referencia
        }
        

        ddHabilidades.CDrecarga = 5; //Seta os valores da Recarga
        ddHabilidades.TimerRecarga = 0;

        if (InstanciaHabilidadeQ.Sprites != null&& InstanciaHabilidadeQ.Nivel< InstanciaHabilidadeQ.Sprites.Length) 
            //Verifica se a habilidade tem sprites e se o nível é valido
        {
            ddHabilidades.sprite = InstanciaHabilidadeQ.Sprites[InstanciaHabilidadeQ.Nivel]; //Define a sprite para a sprite do nível atual
        }
        
    }
}
