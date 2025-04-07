using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "cadaArma", menuName = "Equipamentos/Armas")]
public class CadaArma : CadaCarta
{
    public Vector2Int[] Modifica��es = new Vector2Int[5]; //o x representa qual modifica��o e y o n�vel da modifica��o
    public int Modulo;
    public float Cadencia;
    public float Alcance;
    public int Velocidade;
    public float Precis�o;
    public int Pente;
    public float Recarga;
    public float Dano;
    public int muni��oAtual;
    public int Muni��esPorDisparo;
}
