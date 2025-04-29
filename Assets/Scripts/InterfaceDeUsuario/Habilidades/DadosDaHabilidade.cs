using UnityEngine;

[CreateAssetMenu(fileName = "Dadoshabilidade", menuName = "Interface/Habilidade")]

public class DadosDaHabilidade : ScriptableObject
{
    public Sprite sprite; //Sprite da habilidade

    public float TimerRecarga; //Timer da recarga, para controlar o fillAmount da cobertura e demais métodos

    public float CDrecarga; //Cd da habilidade, para controlar o fillAmount da cobertura

    public bool recarregando; //Verifica se a habilida pode ser usada ou se esta recarregando

    public bool troca; //Verifica quando a arma é trocada;

    public int habilidade; //0 é um escudo, 1 é um projétil e 2 é um buff 
}
    

