using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "cadaArma", menuName = "Equipamentos/Armas")]
public class CadaArma : CadaCarta
{
    public Vector2Int[] Modificações = new Vector2Int[5]; //o x representa qual modificação e y o nível da modificação
    public int Modulo;
    public float Cadencia;
    public float Alcance;
    public int Velocidade;
    public float Precisão;
    public int Pente;
    public float Recarga;
    public float Dano;
    public int muniçãoAtual;
    public int MuniçõesPorDisparo;
}
