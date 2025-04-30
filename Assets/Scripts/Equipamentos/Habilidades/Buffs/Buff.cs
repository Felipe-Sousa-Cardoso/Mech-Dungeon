using System.Collections.Generic;
using UnityEngine;

public class Buff : CadaHabilidade
{
    [SerializeField] JogadorArma arma; //A variável usada para aplicar os buffs
    float atributo; //Usado temporiarimente quando buffar

    private void Awake()
    {
        index = 1;
    }
    public override void UsarHabilidade(JogadorHabilidades jog)
    {
        arma = jog.gameObject.GetComponent<JogadorArma>(); //Acessa o componente JogadorArma no gameobject que a habilidade está

        daHabilidade.recarregando = true; //Marca que a habilidade está recarregando

        switch (nivel) //Faz a alteração de estatisticas pela duração
        {
            case 0: arma.ModificarDano = buffar(arma.ModificarDano); break;
            case 1: arma.ModificarPrecisão = buffar(arma.ModificarPrecisão); arma.ModificarDano = buffar(arma.ModificarDano); break;
            case 2: arma.ModificarCadencia = buffar(arma.ModificarCadencia); arma.ModificarDano = buffar(arma.ModificarDano); break;
        }
    }
    void Update()
    {
        if (daHabilidade != null) //Verifica se o objeto scripatvel existe
        {
            if (daHabilidade.recarregando) //Verifica se a habilidade está recarregando
            {
                daHabilidade.TimerRecarga += Time.deltaTime; //Aumenta o Timer
            }
            if (daHabilidade.TimerRecarga >= daHabilidade.CDrecarga) //Vefifica se o timer for maior que o CD
            {
                daHabilidade.recarregando = false; // libera utilizar novamente a habilidade
                daHabilidade.TimerRecarga = 0;
            }
        }
    }

 

    float buffar(float buff)
    {
        atributo = buff;
        return buff * 2;
    }

    float debuffar(float buff)
    {
        return atributo;
    }
}
