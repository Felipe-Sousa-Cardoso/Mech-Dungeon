using UnityEngine;

public class ChoqueInstanciado : MonoBehaviour
{
    [SerializeField] Transform alvo1;
    [SerializeField] Transform alvo2;

    public Transform Alvo1
    {
        get { return alvo1; }
        set { alvo1 = value; }
    }//Metodo de acesso usado para registrar o primeiro alvo da colisão
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Inimigo")
        {       
            if(collision.transform!=alvo1&&alvo2==null) //escolhe um unico inimigo como alvo
            {
                print("sim");
                alvo2 = collision.transform;
            }
        }
    }
}
