using UnityEngine;

public class AtivarHabilidadeChefe : MonoBehaviour
{
    [SerializeField] protected float modCadencia = 1;
    [SerializeField] protected float modDano = 1;

    protected Color cor;

    public float ModCadencia { get => modCadencia; set => modCadencia = value; }
    public float ModDano { get => modDano; set => modDano = value; }
    public Color Cor { get => cor; set => cor = value; }

    public virtual void Ativar()
    {

    }
}
