using UnityEngine;

public class Projeteis : CadaHabilidade
{
    public override void UsarHabilidade(JogadorHabilidades jog)
    {
        print("Voc� usou um proj�til chamado " + nome);
    }
}
