using System;
using Unity.VisualScripting;
using UnityEngine;

public class Perseguir : CadaMod
{
    [SerializeField] Collider2D cb; //Colisor que verifica se existem inimigos nas proximidades
    Rigidbody2D rb; //RigidBody2D da muni��o
    [SerializeField] Transform target; //Alvo que colidir com o colisor acima
    [SerializeField] float speed; //vari�vel que armazena a velocidade intantanea da muni��o
    private void Start()
    {       
        cb.enabled = true;
        rb = GetComponent<Rigidbody2D>();
        speed = rb.linearVelocity.magnitude;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Inimigo"&& target == null)
        {
            target = collision.transform;
        }
                   
    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 dire��o = (target.position - transform.position).normalized; //cria o vetor que liga a muni��o com o alvo e normaliza para ter apenas o angulo
            
            rb.linearVelocity = speed * Vector2.Lerp(transform.right,dire��o,0.1f); //faz com que a curva seja suave

            float angle = Mathf.Atan2(rb.linearVelocityY, rb.linearVelocityX) * Mathf.Rad2Deg; //Usa a dire��o liner do corpo para calcular o angulo que ele deve estar

            transform.rotation = Quaternion.Euler(0, 0, angle); //Rotaciona o objeto para o angulo correspondente
        }
    }

}
