using System;
using Unity.VisualScripting;
using UnityEngine;

public class Perseguir : CadaMod
{
    [SerializeField] Collider2D cb;
    Rigidbody2D rb;
    [SerializeField] Transform target;
    [SerializeField] float speed;
    private void Start()
    {
        
        cb.enabled = true;
        rb = GetComponent<Rigidbody2D>();
        speed = rb.linearVelocity.magnitude;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.transform.position);
        target = collision.transform;             
    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direção = (target.position - transform.position).normalized; //cria o vetor que liga a munição com o alvo e normaliza para ter apenas o angulo
            
            rb.linearVelocity = speed * Vector2.Lerp(transform.right,direção,0.1f); //faz com que a curva seja suave

            float angle = Mathf.Atan2(rb.linearVelocityY, rb.linearVelocityX) * Mathf.Rad2Deg; //Usa a direção liner do corpo para calcular o angulo que ele deve estar

            transform.rotation = Quaternion.Euler(0, 0, angle); //Rotaciona o objeto para o angulo correspondente
        }
    }

}
