using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Danificavel;

public class BaseInimigos : MonoBehaviour, IDanificavel
{
    protected float vida = 10;
    public virtual void Danificar(float Quanto)
    {
        vida -= Quanto;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }   
}
