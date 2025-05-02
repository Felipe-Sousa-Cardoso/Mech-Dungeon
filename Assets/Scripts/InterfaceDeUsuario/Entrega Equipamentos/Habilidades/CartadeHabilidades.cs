using UnityEngine;
using UnityEngine.UI;


public class CartadeHabilidades : MonoBehaviour
{
    [SerializeField] Image Icone;
    [SerializeField] Text Nome;
    [SerializeField] Text Descrição;

    [SerializeField] Image[] IconedeHabilidade; //Mostra a progressão da habilidade

    [SerializeField] CadaHabilidade habilidade; //A habiliadade dessa carta
    [SerializeField] int nivel;

    public CadaHabilidade Habilidade { get => habilidade; set => habilidade = value; }
    public int Nivel { get => nivel; set => nivel = value; }

    void Start()
    {
        Icone.sprite = habilidade.Sprites[nivel];
        Nome.text = habilidade.Nome;
        Descrição.text = habilidade.Descrições[nivel];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
