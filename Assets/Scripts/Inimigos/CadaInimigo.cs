using UnityEngine;

[CreateAssetMenu(fileName = "CadaInimigo", menuName = "Inimigos/CadaInimigo")]
public class CadaInimigo : ScriptableObject
{
    [Header("Usados por todos os inimigos")]
    public Sprite SpriteInimigo;
    public string NomedoInimigo;
    public int vidaMax;
}
