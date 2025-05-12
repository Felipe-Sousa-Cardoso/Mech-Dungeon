using UnityEngine;

public class AtivarHabilidadeChefe : MonoBehaviour
{
    protected float modCadencia = 1;
    private float modDano = 1;

    public float ModCadencia { get => modCadencia; set => modCadencia = value; }
    public float ModDano { get => modDano; set => modDano = value; }

    public virtual void Ativar()
    {

    }
}
