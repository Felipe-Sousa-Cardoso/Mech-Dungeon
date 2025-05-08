using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BaseInimigos : MonoBehaviour, IDanificavel
{
    Animator anim;
    [SerializeField] SpriteRenderer sr; //Sprite do inimigo

    [SerializeField] protected BoxCollider2D colisor; //Faz o dano de contato
    [SerializeField] protected CircleCollider2D detector;

    [SerializeField] protected CadaInimigo dados;

    [SerializeField] protected Transform Jogador; //Usado para salvar a posi��o do jogador
    [SerializeField] protected float modificadorDeVelocidade; //Utilizado para controlar a velociade que se movimenta e atira

    //Dados basicos de cada inimigo, definidos no editor
    [SerializeField] protected float vida; 
    [SerializeField] protected float danoDeContato;
    [SerializeField] protected float velocidade;

    //Usados para a moviment���o
    float timerMovimento = 0; 
    Vector3 dire�ao;
    protected Rigidbody2D rb;
    public float ModificadorDeVelocidade
    {
        get { return modificadorDeVelocidade; }
        set { modificadorDeVelocidade = value; }
    }
    protected virtual void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        modificadorDeVelocidade = 1;

        colisor.size = dados.SpriteInimigo.bounds.size;
        colisor.offset = sr.sprite.bounds.center;
        sr.sprite = dados.SpriteInimigo; //Define o sprite de cada inimigo

        MovimentoAleatorio();
    }

    protected virtual void Update() {}
    
           
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

        timerMovimento += Time.deltaTime;
        if (timerMovimento >= 1)
        {
            timerMovimento = 0;
            MovimentoAleatorio();
        }
             
    }

   protected void MovimentoAleatorio()
    {
        dire�ao = Random.insideUnitCircle.normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dire�ao, 2.5f , 11);
        if (hit.collider)
        {
            dire�ao = - dire�ao;
        } 
        rb.linearVelocity = dire�ao*velocidade*modificadorDeVelocidade;
    }

    private void OnCollisionStay2D(Collision2D collision) //Verifica o contato contra o jogador
    {
        IDanificavel hit = collision.gameObject.GetComponent<IDanificavel>();
        if (hit!= null&&collision.gameObject.CompareTag("Jogador"))
        {
            hit.Danificar(danoDeContato);
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
