using UnityEngine;
[CreateAssetMenu(fileName = "cadaArma", menuName = "Inimigos/Armas")]
public class CadaArmaInimigos : CadaInimigo

{
    public GameObject Munição; //Contem o prefab da munição
    public Sprite SpriteDaArma; //Sprite da arma
    public Color CorDaArma; //Cor da arma
    public float Cadencia; 
    public float Alcance;
    public int Velocidade;
    public float Precisão;
    public float Dano;
    public int MuniçõesPorDisparo;
    public float distanciaDaArma;
}
