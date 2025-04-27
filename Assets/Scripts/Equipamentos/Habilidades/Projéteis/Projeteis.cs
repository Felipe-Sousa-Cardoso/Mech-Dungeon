using UnityEngine;

public class Projeteis : CadaHabilidade
{
    public override void UsarHabilidade(JogadorHabilidades jog)
    {
        print("Você usou um projétil chamado " + nome);
    }
}
