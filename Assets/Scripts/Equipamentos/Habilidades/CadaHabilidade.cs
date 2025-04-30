using UnityEngine;

public class CadaHabilidade : MonoBehaviour
{
    [SerializeField] protected string nome;

    [SerializeField] Sprite[] sprites;

    [SerializeField] protected DadosDaHabilidade daHabilidade;

    [SerializeField] protected int nivel; //Nivel atual da habilidade

    [SerializeField] protected int index; //Define se é um escudo, um buff ou um projétil
    public int Nivel { get => nivel; set => nivel = value; }
    public Sprite[] Sprites { get => sprites; set => sprites = value; }
    public int Index { get => index; set => index = value; }

    public virtual void UsarHabilidade(JogadorHabilidades jog)
    {
        
    }
    
}
