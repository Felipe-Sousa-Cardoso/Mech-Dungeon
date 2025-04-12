using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Danificavel;

public class BaseInimigos : MonoBehaviour, IDanificavel
{
    [SerializeField] protected float vida = 10;
    public virtual void Danificar(float Quanto)
    {
        vida -= Quanto;
        if (vida <= 0)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.simulated = false;
            if (GetComponentInChildren<AcidoInstanciado>() != null)
            {
                GetComponentInChildren<AcidoInstanciado>().transform.parent = null;
            }
            Destroy(gameObject,0.3f);
        }
    }   
}
