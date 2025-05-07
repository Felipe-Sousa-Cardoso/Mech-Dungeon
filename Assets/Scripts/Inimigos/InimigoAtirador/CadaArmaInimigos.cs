using UnityEngine;
[CreateAssetMenu(fileName = "cadaArma", menuName = "Inimigos/Armas")]
public class CadaArmaInimigos : ScriptableObject

{
    public GameObject Munição; //Contem o prefab da munição
    public Sprite Sprite; //Sprite da arma
    public Color Cor; //Cor da arma
    public float Cadencia; 
    public float Alcance;
    public int Velocidade;
    public float Precisão;
    public float Dano;
    public int MuniçõesPorDisparo;
}
