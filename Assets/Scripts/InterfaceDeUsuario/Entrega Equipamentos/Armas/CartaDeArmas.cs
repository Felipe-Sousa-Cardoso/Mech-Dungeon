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

    JogadorArma jog;
    [SerializeField] CadaArma carta;
    UsoArma arma;
    int qualidade;
    [SerializeField] Vector2[] atributos; //P primeiro valor é o atributo o segundo
                                                                                                       //é o nível
    public JogadorArma Jog
    {
        get { return jog; }
        set { jog = value; }
    }

    public CadaArma Carta { get => carta; set => carta = value; }
    public UsoArma Arma { get => arma; set => arma = value; }
    public int Qualidade { get => qualidade; set => qualidade = value; }
    public Vector2[] Atributos { get => atributos; set => atributos = value; }

    private void OnEnable()
    {
        Icone.sprite = carta.sprite;
        Nome.text = carta.Nome;
        Descrição.text = carta.Descricao;

        Borda();
        AtributosD();
    }
    void AtributosD()
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
}
