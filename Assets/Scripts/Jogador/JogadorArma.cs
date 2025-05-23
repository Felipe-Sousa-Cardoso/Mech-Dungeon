using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorArma : MonoBehaviour
{
    JogadorAtributos jogadorAtributos; //Script que controla atributos gerais do jogador

    [SerializeField] UsoArma[] armaAtual; //Objeto que contem o conjunto dos Scripts das armas atualmente equipadas
    [SerializeField] DadosDaArma interfaceArmas; //ObejtoScriptavel que faz a comunica��o com a interface
    int armaCount = 0; //controla qual arma est� equipada
    [SerializeField] GameObject tiro; //Prefab da Muni��o
    [SerializeField] Transform Arma; //Trasform da arma, local onde � pra ser instanciado o tiro
    bool atirando;

    Coroutine rotinaRecarga;

    int maxmuni��es;
    float recarga;
    float cadencia;
    bool trocaDeArmaCD;

    float modificarDano; //Modificador global de Dano
    float modificarCadencia;//Modificador global de Cadencia
    float modificarPrecis�o; //Modificador global de Precis�o
    #region M�todos de Acesso
    public GameObject Tiro
    {
        get { return tiro; }
        set { tiro = value; }
    }
    public UsoArma[] ArmaAtual
    {
        get { return armaAtual; }
        set { armaAtual = value; }
    }
    public float ModificarDano
    {
        get { return modificarDano;}
        set { modificarDano = value;}
    }
    public int Maxmuni��es
    {
        get { return maxmuni��es; }
        set { maxmuni��es = value; }
    }
    public float Recarga
    {
        get {return recarga;} 
        set { recarga = value; }
    }
    public float Cadencia
    {
        get { return cadencia;}
        set { cadencia = value; }
    }
    public int ArmaCount
    {
        get { return armaCount; }
        set { armaCount = value; }
    }

    public float ModificarCadencia { get => modificarCadencia; set => modificarCadencia = value; }
    public float ModificarPrecis�o { get => modificarPrecis�o; set => modificarPrecis�o = value; }

    #endregion
    private void Awake()
    {
        jogadorAtributos = GetComponent<JogadorAtributos>();
    }
    private void Start()
    {
        GerenciadorDeCartas.instancia.ArmasReset();
        interfaceArmas.recarregando = false;
        modificarDano = 1;
        modificarCadencia = 1;
        modificarPrecis�o = 1;
        UpdateArma();
    }
    private void Update()      
    {
        if (jogadorAtributos.ArmaAtiva) //Verifica se o jogador pode atirar
        {
            if (ControladorDeInput.GetTiroInput() && !atirando && armaAtual[armaCount].Valores.muni��oAtual > 0)
            {
                StartCoroutine(CadaTiro(cadencia*modificarCadencia));
                armaAtual[armaCount].Valores.muni��oAtual--;
                interfaceArmas.Muni��oAtual--;
            }

            if (ControladorDeInput.GetTrocaArmaInput() && !trocaDeArmaCD)
            {
                StartCoroutine(TrocaDeArma());
                if (armaCount < ArmaAtual.Length - 1)
                {
                    armaCount++;
                }
                else
                {
                    armaCount = 0;
                }
                UpdateArma();
                if (rotinaRecarga != null)
                {
                    StopCoroutine(rotinaRecarga);
                }

                interfaceArmas.recarregando = false;
            }

            if (armaAtual[armaCount].Valores.muni��oAtual == 0 && !interfaceArmas.recarregando)
            {
                rotinaRecarga = StartCoroutine(Recaregarold(recarga));
            }
        }
    }
    public void UpdateArma()
    {
        armaAtual[armaCount].Qualidade();
        armaAtual[armaCount].UpdateArma(this);
        interfaceArmas.sprite = armaAtual[armaCount].Valores.sprite;
        if (armaAtual.Length > 1)
        {
            if (armaCount < ArmaAtual.Length - 1)
            {
                interfaceArmas.proxmoSprite = armaAtual[armaCount + 1].Valores.sprite;
            }
            else
            {
                interfaceArmas.proxmoSprite = armaAtual[0].Valores.sprite;
            }
            
        }
        
        interfaceArmas.Muni��oAtual = armaAtual[armaCount].Valores.muni��oAtual;
        interfaceArmas.CDrecarga = recarga;
        Arma.GetComponent<Anima��oArma>().AlterarArma(armaAtual[armaCount].Valores.sprite);
    }
    IEnumerator CadaTiro(float t)
    {
        atirando = true;
        armaAtual[armaCount].atirar(tiro, Arma, modificarPrecis�o);
        yield return new WaitForSeconds(1/t);
        atirando = false;
    }
    IEnumerator Recaregarold(float t)
    {
        interfaceArmas.recarregando = true;
        yield return new WaitForSeconds(t);
        armaAtual[armaCount].Valores.muni��oAtual = interfaceArmas.Muni��oAtual = maxmuni��es;
        interfaceArmas.recarregando = false;
    }
    IEnumerator TrocaDeArma()
    {
        trocaDeArmaCD = true;
        yield return new WaitForSeconds(1); 
        trocaDeArmaCD = false;
    }
}
