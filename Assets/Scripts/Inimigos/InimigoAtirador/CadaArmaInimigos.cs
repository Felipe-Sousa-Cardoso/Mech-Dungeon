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
    public GameObject Munição; //Contem o prefab da munição
    public float Cadencia; 
    public float Alcance;
    public int Velocidade;
    public float Precisão;
    public float Dano;
    public int MuniçõesPorDisparo;
    
}
