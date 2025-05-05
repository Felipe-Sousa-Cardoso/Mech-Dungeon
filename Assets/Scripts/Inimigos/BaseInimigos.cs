using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Danificavel;

public class BaseInimigos : MonoBehaviour, IDanificavel
{
    Animator anim;
    [SerializeField] protected float modificadorDeVelocidade; //Utilizado para controlar a velociade que se movimenta e atira

    [SerializeField] protected float vida = 10;

    public float ModificadorDeVelocidade
    {
        get { return modificadorDeVelocidade; }
        set { modificadorDeVelocidade = value; }
    }
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        modificadorDeVelocidade = 1;
    }
    public virtual void Danificar(float Quanto) //Função que é chamada para realizar a mecanica de dano
    {
        anim.SetTrigger("Hit");
        vida -= Quanto;
        if (vida <= 0)
        {
            anim.SetTrigger("Dead");
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.simulated = false; //Desliga a simulação de fisica quando a vida chega a 0, e está finalizando a destruição do objeto

            if (GetComponentInChildren<AcidoInstanciado>() != null) //se o alvo possui um componente de ácido faz com que ele não seja mais
                                                                    //filho desse objeto, evitando assim sua destruição quando esse objeto for destruido
            {
                GetComponentInChildren<AcidoInstanciado>().transform.parent = null;
            }
            Destroy(gameObject,0.3f); //Demora 0.3 segundos para destruir o objeto para concluir os efeitos
        }
    }   
}
