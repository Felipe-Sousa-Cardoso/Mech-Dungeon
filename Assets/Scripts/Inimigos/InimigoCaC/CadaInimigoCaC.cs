using UnityEngine;

[CreateAssetMenu(fileName = "CadaInimigoCaC", menuName = "Inimigos/CaC")]
public class CadaInimigoCaC : CadaInimigo
{
    [Header("Usados somente pelos inimigos CaC")]
    public float Velocidade;
    public float DanodeContato;
}
