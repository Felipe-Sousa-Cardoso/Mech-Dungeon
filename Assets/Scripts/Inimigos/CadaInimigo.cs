using UnityEngine;

[CreateAssetMenu(fileName = "CadaInimigo", menuName = "Inimigos/CadaInimigo")]
public class CadaInimigo : ScriptableObject
{
    public Sprite SpriteInimigo;
    public string NomedoInimigo;
    public int vidaMax;
}
