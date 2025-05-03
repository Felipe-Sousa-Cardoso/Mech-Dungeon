using System.Collections.Generic;
using UnityEngine;

public class Buff : CadaHabilidade
{
    [SerializeField] Transform Jogador; //Jogador onde será instanciado o buff
    [SerializeField] JogadorArma arma; //A variável usada para aplicar os buffs
    float atributo1; //Usado temporiarimente quando buffar
    float atributo2; //Usado temporiarimente quando buffar

    [SerializeField] GameObject[] buffs; //Representa todas as versões de buffs

    [SerializeField] GameObject buffInst; //Obj que armazena o objeto que vai ser instanciado, responsavel aqui pelo sistema de particulas

    ParticleSystem ps;

    private void Awake()
    {
        index = 2;
    }
    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    public override void UsarHabilidade(JogadorHabilidades jog)
    {
        arma = jog.gameObject.GetComponent<JogadorArma>(); //Acessa o componente JogadorArma no gameobject que a habilidade está
        Jogador = jog.transform;
        daHabilidade.recarregando = true; //Marca que a habilidade está recarregando

        if (arma != null)
        {
            switch (nivel)
            {
                case 0: arma.ModificarDano = buffar(arma.ModificarDano, 0); break;
                case 1: arma.ModificarPrecisão = buffar(arma.ModificarPrecisão, 0); arma.ModificarDano = buffar(arma.ModificarDano, 1); break;
                case 2: arma.ModificarCadencia = buffar(arma.ModificarCadencia, 0); arma.ModificarDano = buffar(arma.ModificarDano, 1); break;
            }// Faz a alteração de estatisticas pela duração
            arma.UpdateArma(); //Atualiza a arma para aplicar as modificações
        }
        if (nivel < buffs.Length)//Verifica se o nível é valido
        {
            if (buffs[nivel] != null && buffInst == null) //Verifica se o escudo para aquele nível e o buff existem
            {
                buffInst = Instantiate(buffs[nivel]); //Instancia o buff e mantem uma referencia para ele
            }
        }
        


    }
    void Update()
    {
        if (Jogador != null&& buffInst) //VErifica se o jogador não é nulo e define a posição como a mesma do jogador
        {
            buffInst.transform.position = Jogador.position;
        } 
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
            if (daHabilidade.TimerRecarga >= 3) //Vefifica se o timer for maior que a duração
            {
                if (arma != null)
                {
                    switch (nivel) //Faz a alteração de estatisticas pela duração
                    {
                        case 0: arma.ModificarDano = debuffar(arma.ModificarDano, 0); break;
                        case 1: arma.ModificarPrecisão = debuffar(arma.ModificarPrecisão, 0); arma.ModificarDano = debuffar(arma.ModificarDano, 1); break;
                        case 2: arma.ModificarCadencia = debuffar(arma.ModificarCadencia, 0); arma.ModificarDano = debuffar(arma.ModificarDano, 1); break;
                    }
                    if (buffInst) //Verifica se o buffInst existe e depois o destroi no final da duração
                    {
                        Destroy(buffInst);
                    }
                    arma.UpdateArma();
                }
                
            }
        }
    }

    float buffar(float buff, int atributo) //Dobra o atributo e salva o valor anterior em uma variável
    {
        if (atributo == 0)
        {
            atributo1 = buff;
        }
        else
        {
            atributo2 = buff;
        }
        
        return buff * 2;
    }
    float debuffar(float buff, int atributo) //Retorna o atributo para o valor anterior
    {
        if (atributo == 0) 
        {
            return atributo1;
        }
        else
        {
            return atributo2;
        }
        
    }
    
}
