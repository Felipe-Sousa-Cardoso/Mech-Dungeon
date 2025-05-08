using Unity.VisualScripting;
using UnityEngine;

public class InimigoCaC : BaseInimigos
{
    CadaInimigoCaC dadosDoinimigo;

    protected override void Start()
    {
        base.Start();
        dadosDoinimigo = dados as CadaInimigoCaC; //Converte o scriptable object do pai para poder ser usado
        //Como no objeto pai o objeto já é desse tipo não apresenta problema

        danoDeContato = dadosDoinimigo.DanodeContato;
        velocidade = dadosDoinimigo.Velocidade;

        MovimentoAleatorio();


    }
    protected override void Update()
    {
        if (Jogador)
        {
            rb.linearVelocity = (Jogador.transform.position - transform.position).normalized *velocidade*modificadorDeVelocidade ;
            //define a velocidade do inimgo como o vetor dado pela diferença entre o jogador e ele normalizado multiplicado pela velocidade
        }
        else
        {
            Move();
        }
        
    }
}
