using UnityEngine;

public class CadaHabilidade : MonoBehaviour
{
    [SerializeField] protected string nome;

    [SerializeField] Sprite[] sprites;

    [SerializeField] protected int nivel;
    public int Nivel { get => nivel; set => nivel = value; }
    public Sprite[] Sprites { get => sprites; set => sprites = value; }

    public virtual void UsarHabilidade(JogadorHabilidades jog)
    {
        
    }
    
}
