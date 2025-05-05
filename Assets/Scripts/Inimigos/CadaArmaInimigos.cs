using UnityEngine;
[CreateAssetMenu(fileName = "cadaArma", menuName = "Inimigos/Armas")]
public class CadaArmaInimigos : ScriptableObject

{
    public GameObject Muni��o; //Contem o prefab da muni��o
    public Sprite Sprite; //Sprite da arma
    public Color Cor; //Cor da arma
    public float Cadencia; 
    public float Alcance;
    public int Velocidade;
    public float Precis�o;
    public float Dano;
    public int Muni��esPorDisparo;
}
