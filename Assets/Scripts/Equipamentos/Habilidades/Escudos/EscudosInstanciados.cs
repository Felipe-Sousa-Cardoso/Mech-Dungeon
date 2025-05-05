using UnityEngine;

public class EscudosInstanciados : MonoBehaviour, IDanificavel
{
    [SerializeField] float forcaDoEscudo;
    public float ForcaDoEscudo { get => forcaDoEscudo; set => forcaDoEscudo = value; }

    public void Danificar(float Quanto)
    {
        forcaDoEscudo -= Quanto;
        if (forcaDoEscudo <= 0)
        {
            Destroy(gameObject);
        }
    }
}
