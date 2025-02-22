using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Danificavel;

public class Munição : MonoBehaviour
{
    float dano;
    bool solido;
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
        IDanificavel objeto = collision.gameObject.GetComponent<IDanificavel>(); //Checa se o objeto atingido implementa a interface IDanificavel
        if (objeto != null)
        {
            objeto.Danificar(dano);               
        }
        Destroy(gameObject);
    }   
}
