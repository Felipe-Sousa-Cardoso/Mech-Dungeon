using UnityEngine;
using UnityEngine.UI;

public class CartaDeArmas : MonoBehaviour
{
    [SerializeField] Image Icone;
    [SerializeField] Image CartaToda;
    [SerializeField] Image borda;
    [SerializeField] Sprite[] bordas;
    [SerializeField] Text Nome;
    [SerializeField] Text Descrição;
    [SerializeField] Sprite[] Atributos;
    [SerializeField] Transform Atributo;

    JogadorArma jog;
    [SerializeField] CadaArma carta;
    UsoArma arma;
    int qualidade;
    public JogadorArma Jog
    {
        get { return jog; }
        set { jog = value; }
    }

    public CadaArma Carta { get => carta; set => carta = value; }
    public UsoArma Arma { get => arma; set => arma = value; }
    public int Qualidade { get => qualidade; set => qualidade = value; }

    private void OnEnable()
    {
        Icone.sprite = carta.sprite;
        Nome.text = carta.Nome;
        Descrição.text = carta.Descricao;
    }
}
