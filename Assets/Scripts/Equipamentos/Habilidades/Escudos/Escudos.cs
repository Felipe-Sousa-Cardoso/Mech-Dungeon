using UnityEngine;

public class Escudos : CadaHabilidade
{
    [SerializeField] Transform Jogador;
    public override void UsarHabilidade(JogadorHabilidades jog)
    {
        print("Voc� usou um escudo chamado " + nome);
        Jogador = jog.gameObject.transform;
    }
}
