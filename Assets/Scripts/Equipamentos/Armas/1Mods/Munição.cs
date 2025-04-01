using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Danificavel;

public class Munição : MonoBehaviour
{
    float dano;
    bool solido;
    [SerializeField] PolygonCollider2D pc;
    #region Metodos de Acesso
    public float Dano
    {
        get { return dano; }
        set { dano = value; }
    }

    public bool Solido { get => solido; set => solido = value; }
    #endregion

    private void Start()
    {
        pc = GetComponent<PolygonCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Sim");
        IDanificavel objeto = collision.gameObject.GetComponent<IDanificavel>(); //Checa se o objeto atingido implementa a interface IDanificavel
        if (objeto != null&&collision.otherCollider==pc)
        {
            objeto.Danificar(dano);               
        }
        Destroy(gameObject);
    }   
}
