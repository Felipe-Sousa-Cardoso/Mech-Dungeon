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

        Move();
    }
}
