using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Danificavel;

public class Perfurar : CadaMod
{
    PolygonCollider2D col;
    void Start()
    {
        col = GetComponent<PolygonCollider2D>();
        col.isTrigger = true;
        GetComponent<Munição>().Solido = false; //Altera na munição para outras interações
    }
    private void OnTriggerEnter2D(Collider2D collision) //Se comporta como trigger para poder atravessar os inimigos
    {
        float DanoT = GetComponent<Munição>().Dano;
        IDanificavel objeto = collision.gameObject.GetComponent<IDanificavel>(); //Checa se o objeto atingido implementa a interfave Danificavel
        if (objeto != null)
        {
            objeto.Danificar(DanoT);
        }
    }
   


}
