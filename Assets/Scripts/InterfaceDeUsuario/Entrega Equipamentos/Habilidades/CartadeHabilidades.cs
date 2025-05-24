using UnityEngine;
using UnityEngine.UI;


public class CartadeHabilidades : MonoBehaviour
{
    [SerializeField] Image Icone;
    [SerializeField] Text Nome;
    [SerializeField] Text Descrição;

    [SerializeField] Image[] IconedeHabilidade; //Mostra a progressão da habilidade

    [SerializeField] CadaHabilidade habilidade; //A habiliadade dessa carta

    JogadorHabilidades jog;
    [SerializeField] int nivel;

    public CadaHabilidade Habilidade { get => habilidade; set => habilidade = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public JogadorHabilidades Jog { get => jog; set => jog = value; }

    void Start()
    {
        if (habilidade)
        {
            Icone.sprite = habilidade.Sprites[nivel];
            Nome.text = habilidade.Nome;
            Descrição.text = habilidade.Descrições[nivel];
            for (int i = 0; i < IconedeHabilidade.Length; i++) //atribui os sprites da progressão da habilidade
            {
                if (IconedeHabilidade[i] && habilidade.Sprites[i]) //Verifica se ambos o sprite e a imagem exitem
                {
                    IconedeHabilidade[i].sprite = habilidade.Sprites[i];
                }
                if (i != nivel)
                {
                    IconedeHabilidade[i].color = new Color(1, 1, 1, 0.4f);
                }
                else
                {
                    IconedeHabilidade[i].rectTransform.localScale = new Vector3(1.2f, 1.2f, 1);
                }

            }
        }
    }

    public void DarAHabilidade() //Acessado pelo botão
    {
        if (nivel == 0)
        {
            if (jog.Nivel < 2)
            {
                jog.Nivel++;
            }          
            jog.HabilidadeQ = habilidade; //Se o nivel for incial troca o prefab que é usado para instanciar a habilidade
        }
        if (jog.InstanciaHabilidadeQ) //Verifica se a instancia existe
        {
            jog.InstanciaHabilidadeQ.Nivel = nivel;
        }
        
        GerenciadorDeCartas.instancia.Destruir(2); //Destroi as cartas
        jog.UpdateHabilidades(); //Roda o metodo que atualiza as habilidades
    }
}
