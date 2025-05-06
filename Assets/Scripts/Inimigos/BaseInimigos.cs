using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInimigos : MonoBehaviour, IDanificavel
{
    Animator anim;
    [SerializeField] protected Transform Jogador; //Usado para salvar a posi��o do jogador
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
    public virtual void Danificar(float Quanto) //Fun��o que � chamada para realizar a mecanica de dano
    {
        anim.SetTrigger("Hit");
        vida -= Quanto;
        if (vida <= 0)
        {
            anim.SetTrigger("Dead");
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.simulated = false; //Desliga a simula��o de fisica quando a vida chega a 0, e est� finalizando a destrui��o do objeto

            if (GetComponentInChildren<AcidoInstanciado>() != null) //se o alvo possui um componente de �cido faz com que ele n�o seja mais
                                                                    //filho desse objeto, evitando assim sua destrui��o quando esse objeto for destruido
            {
                GetComponentInChildren<AcidoInstanciado>().transform.parent = null;
            }
            Destroy(gameObject,0.3f); //Demora 0.3 segundos para destruir o objeto para concluir os efeitos
        }
    }   

    protected virtual void Move()
    {
        if (Jogador)
        {
            transform.position = Vector3.MoveTowards(transform.position, Jogador.position, 2 * Time.deltaTime * modificadorDeVelocidade);
        }
        else
        {

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)//Quando um jogador entra na colis�o define a vari�vel 
    {
        if (collision.CompareTag("Jogador"))
        {
            Jogador = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)//Quando um jogador sai da colis�o redefine a vari�vel
    {
        if (collision.CompareTag("Jogador"))
        {
            Jogador = null;
        }
    }
}
