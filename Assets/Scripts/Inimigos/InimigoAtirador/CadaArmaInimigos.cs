using UnityEngine;
[CreateAssetMenu(fileName = "cadaArma", menuName = "Inimigos/Armas")]
public class CadaArmaInimigos : CadaInimigo

{
    [Header("Usados somente pelos inimigos atiradores")]
   
    public Sprite SpriteDaArma; //Sprite da arma
    public Color CorDaArma; //Cor da arma
    public float distanciaDaArma;
    [Space()]
    [Header("Usados para os inimigos e para as armas de chefe")]
    public GameObject Muni��o; //Contem o prefab da muni��o
    public float Cadencia; 
    public float Alcance;
    public int Velocidade;
    public float Precis�o;
    public float Dano;
    public int Muni��esPorDisparo;
    
}
