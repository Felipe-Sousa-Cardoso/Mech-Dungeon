using UnityEngine;

public class Escudos : CadaHabilidade
{
    public override void UsarHabilidade(JogadorHabilidades jog)
    {
        print("Voc� usou um escudo chamado " + nome);
    }
}
