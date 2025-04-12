using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Danificavel;

public class BaseInimigos : MonoBehaviour, IDanificavel
{
    Animator anim;
    [SerializeField] protected float vida = 10;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public virtual void Danificar(float Quanto) //Função que é chamada para realizar a mecanica de dano
    {
        anim.SetTrigger("Hit");
        vida -= Quanto;
        if (vida <= 0)
        {
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
