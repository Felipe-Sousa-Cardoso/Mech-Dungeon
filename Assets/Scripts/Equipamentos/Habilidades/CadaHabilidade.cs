using UnityEngine;

public class CadaHabilidade : MonoBehaviour
{
    [SerializeField] protected string nome;

    [SerializeField] Sprite[] sprites; //Sprites de cada habilidade e das modificações

    [SerializeField] string[] descrições; //Descrição de cada habilidade e das modificações

    [SerializeField] protected DadosDaHabilidade daHabilidade; //Faz a comuncação com a interface

    [SerializeField] protected int nivel; //Nivel atual da habilidade

    [SerializeField] protected int index; //Define se é um escudo ou um buff 
    public int Nivel { get => nivel; set => nivel = value; }
    public Sprite[] Sprites { get => sprites; set => sprites = value; }
    public int Index { get => index; set => index = value; }
    public string[] Descrições { get => descrições; set => descrições = value; }

    public virtual void UsarHabilidade(JogadorHabilidades jog)
    {
        
    }
    
}
