using UnityEngine;

public class Buff : CadaHabilidade
{
    public override void UsarHabilidade(JogadorHabilidades jog)
    {
        print("Você usou um buff chamado " + nome);
    }
}
