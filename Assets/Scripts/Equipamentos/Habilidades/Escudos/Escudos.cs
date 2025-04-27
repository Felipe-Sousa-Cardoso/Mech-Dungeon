using UnityEngine;

public class Escudos : CadaHabilidade
{
    public override void UsarHabilidade(JogadorHabilidades jog)
    {
        print("Você usou um escudo chamado " + nome);
    }
}
