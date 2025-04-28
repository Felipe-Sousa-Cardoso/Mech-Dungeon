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
       
    }
    void UpdateHabilidades()
    {
        InstanciaHabilidadeQ = Instantiate(habilidadeQ, OrganizarHabilidades);
        ddHabilidades.CDrecarga = 4;
    }
}
