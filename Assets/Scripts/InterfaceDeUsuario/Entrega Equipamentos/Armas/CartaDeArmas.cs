using UnityEngine;
using UnityEngine.UI;

public class CartaDeArmas : MonoBehaviour
{
    [SerializeField] Image Icone;
    [SerializeField] Image CartaToda;
    [SerializeField] Image borda;
    [SerializeField] Sprite[] bordas; //Conjunto dos sprites das bordas
    [SerializeField] Text Nome;
    [SerializeField] Text Descrição;

    [SerializeField] Sprite[] atributoSprites; //Conjunto dos sprites dos atributos

    [SerializeField] Image IconedeAtributo1; //Perseguir ou perfurar
    [SerializeField] Image IconedeAtributo2; //Efeitos
    [SerializeField] Image IconedeAtributo3;

    [SerializeField] JogadorArma jog;
    [SerializeField] CadaArma carta;
    [SerializeField] UsoArma arma;
    [SerializeField] int qualidade;
    [SerializeField] Vector2Int[] atributos; //O primeiro valor é o atributo o segundo é o nível
    #region Metodos de Acesso
    public JogadorArma Jog
    {
        get { return jog; }
        set { jog = value; }
    }
    public CadaArma Carta { get => carta; set => carta = value; }
    public UsoArma Arma { get => arma; set => arma = value; }
    public int Qualidade { get => qualidade; set => qualidade = value; }
    public Vector2Int[] Atributos { get => atributos; set => atributos = value; }
    #endregion
    private void OnEnable()
    {
        Icone.sprite = carta.sprite;
        Nome.text = carta.Nome;
        Descrição.text = carta.Descricao;

        Borda();
        AtributosD();
    }
    void AtributosD() //Usa os atributos da cartas instanciada para definir quais icones serão mostrados
    {
        switch (atributos[0].x)
        {
            case 0: IconedeAtributo1.color = new Vector4(1,1,1,0); break;
            case 1: IconedeAtributo1.sprite = atributoSprites[0]; break;
            case 2: IconedeAtributo1.sprite = atributoSprites[1]; break;
        }
        switch (atributos[1].x)
        {
            case 0: IconedeAtributo2.color = new Vector4(1, 1, 1, 0); break;
            case 3: IconedeAtributo2.sprite = atributoSprites[2]; break;
            case 4: IconedeAtributo2.sprite = atributoSprites[3]; break;
            case 5: IconedeAtributo2.sprite = atributoSprites[4]; break;
        }
    }
    void Borda() //Modifica a borda conforme a qualidade de manufatura
    {
        switch (qualidade)
        {
            case 0: borda.color = new Vector4(1, 1, 1, 0); break;
            case 1: borda.sprite = bordas[0]; break;
            case 2: borda.sprite = bordas[1]; break;
            case 3: borda.sprite = bordas[2]; break;
        }
    }
    public void DarAArma() //Acessado pelo botão
    {
        bool igual = false;
        for (int i = 0; i < jog.ArmaAtual.Length; i++) //Verifica se o jogador contem alguma arma do mesmo módulo que a que ele escolheu
        {
            if (jog.ArmaAtual[i].Valores.Modulo == arma.Valores.Modulo)
            {
                updateArma();
                jog.ArmaAtual[i] = arma;              
                igual = true;
            }
        }
        if (!igual)
        {
            updateArma();
            jog.ArmaAtual[jog.ArmaCount] = arma; //acessa a arma atual do jogador e altera para a dessa carta
        }
        
        jog.UpdateArma(); //Roda o método que atualiza a arma

        GerenciadorDeCartas.instancia.Destruir(1); //Destroi as cartas de arma
    }

    void updateArma() //Altera cada valor da arma para ser igual a qualidade
    {
        arma.Valores.QualidadeDeManufatura = qualidade;
        arma.Valores.Cadencia = qualidade + 1;
        arma.Valores.Alcance = qualidade + 1;
        arma.Valores.Velocidade = qualidade + 1;
        arma.Valores.Precisão = qualidade + 1;
        arma.Valores.Pente = qualidade + 1;
        arma.Valores.Recarga = qualidade + 1;
        arma.Valores.Dano = qualidade + 1;
        arma.Valores.MuniçõesPorDisparo = qualidade+1;
        arma.Valores.Modificações[0].x = atributos[0].x;
        arma.Valores.Modificações[1].x = atributos[1].x;
    }
}
