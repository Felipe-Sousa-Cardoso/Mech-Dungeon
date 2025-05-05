using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Munição : MonoBehaviour
{
    float dano;
    bool solido = true;
    #region Metodos de Acesso
    public float Dano
    {
        get { return dano; }
        set { dano = value; }
    }

    public bool Solido { get => solido; set => solido = value; }
    #endregion 


    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            AoDano(collision);
        }
        
    }
    #region AoDano
    public void AoDano(Collision2D col)
    {
        IDanificavel objeto = col.gameObject.GetComponent<IDanificavel>(); //Checa se o objeto atingido implementa a interface IDanificavel
        if (objeto != null)
        {
            
            if (OnEfeito != null)
            {
                OnEfeito(col.gameObject, dano);
            }
            objeto.Danificar(dano);

        }
        Destroy(gameObject);
    }
    public void AoDano(Collider2D col)
    {
        IDanificavel objeto = col.gameObject.GetComponent<IDanificavel>(); //Checa se o objeto atingido implementa a interfave Danificavel
        if (objeto != null)
        {
            
            if (OnEfeito != null)
            {
                OnEfeito(col.gameObject, dano);
            }
            objeto.Danificar(dano);
        }
    }
    #endregion
    public delegate void efeito(GameObject ogj, float dano);
    public static event efeito OnEfeito;

    public void LimparEfeito()
    {
        OnEfeito = null;
    }
    

}
