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
        GetComponent<Muni��o>().Solido = false; //Altera na muni��o para outras intera��es
    }
    private void OnTriggerEnter2D(Collider2D collision) //Se comporta como trigger para poder atravessar os inimigos
    {
        if(collision.gameObject.tag=="Inimigo"&& GetComponent<Muni��o>().Solido == false)
        {
            GetComponent<Muni��o>().AoDano(collision);               
        }

    }
    
   


}
