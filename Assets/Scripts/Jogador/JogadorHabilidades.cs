using UnityEngine;

public class JogadorHabilidades : MonoBehaviour
{
    JogadorAtributos jogadorAtributos; //Script que controla atributos gerais do jogador
    [SerializeField] CadaHabilidade habilidadeQ;
    [SerializeField] CadaHabilidade habilidadeE;
    private void Awake()
    {
        jogadorAtributos = GetComponent<JogadorAtributos>();
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
                    if (habilidadeQ != null)
                    {
                        habilidadeQ.UsarHabilidade(this);
                    }                   
                }
                if (ControladorDeInput.GetHabilidadeEInput())
                {
                    if (habilidadeE != null)
                    {
                        habilidadeE.UsarHabilidade(this);
                    }                   
                }
            }
        }
       
    }
}
