using UnityEngine;
using UnityEngine.UI;


public class CartadeHabilidades : MonoBehaviour
{
    [SerializeField] Image Icone;
    [SerializeField] Text Nome;
    [SerializeField] Text Descri��o;

    [SerializeField] Image[] IconedeHabilidade; //Mostra a progress�o da habilidade

    [SerializeField] CadaHabilidade habilidade; //A habiliadade dessa carta
    [SerializeField] int nivel;

    public CadaHabilidade Habilidade { get => habilidade; set => habilidade = value; }
    public int Nivel { get => nivel; set => nivel = value; }

    void Start()
    {
        Icone.sprite = habilidade.Sprites[nivel];
        Nome.text = habilidade.Nome;
        Descri��o.text = habilidade.Descri��es[nivel];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
