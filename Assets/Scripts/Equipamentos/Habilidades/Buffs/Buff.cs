using UnityEngine;

public class Buff : CadaHabilidade
{
    public override void UsarHabilidade(JogadorHabilidades jog)
    {
        print("Voc� usou um buff chamado " + nome);
    }
}
