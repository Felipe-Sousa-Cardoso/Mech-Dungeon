using UnityEngine;

public class InimigoCaC : BaseInimigos
{
    [SerializeField] CadaInimigoCaC dados;
    protected override void Start()
    {
        base.Start();
        danoDeContato = dados.DanodeContato;
        velocidade = dados.Velocidade;

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
