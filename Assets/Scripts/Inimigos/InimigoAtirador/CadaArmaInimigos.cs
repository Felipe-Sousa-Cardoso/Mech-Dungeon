using UnityEngine;
[CreateAssetMenu(fileName = "cadaArma", menuName = "Inimigos/Armas")]
public class CadaArmaInimigos : CadaInimigo

{
    public GameObject Muni��o; //Contem o prefab da muni��o
    public Sprite SpriteDaArma; //Sprite da arma
    public Color CorDaArma; //Cor da arma
    public float Cadencia; 
    public float Alcance;
    public int Velocidade;
    public float Precis�o;
    public float Dano;
    public int Muni��esPorDisparo;
    public float distanciaDaArma;
}
