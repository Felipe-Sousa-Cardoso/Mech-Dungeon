using UnityEngine;

public class CadaHabilidade : MonoBehaviour
{
    [SerializeField] protected string nome;

    [SerializeField] Sprite[] sprites; //Sprites de cada habilidade e das modifica��es

    [SerializeField] string[] descri��es; //Descri��o de cada habilidade e das modifica��es

    [SerializeField] protected DadosDaHabilidade daHabilidade; //Faz a comunca��o com a interface

    [SerializeField] protected int nivel; //Nivel atual da habilidade

    [SerializeField] protected int index; //Define se � um escudo ou um buff 
    public int Nivel { get => nivel; set => nivel = value; }
    public Sprite[] Sprites { get => sprites; set => sprites = value; }
    public int Index { get => index; set => index = value; }
    public string[] Descri��es { get => descri��es; set => descri��es = value; }

    public virtual void UsarHabilidade(JogadorHabilidades jog)
    {
        
    }
    
}
