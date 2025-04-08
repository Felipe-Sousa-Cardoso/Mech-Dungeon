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
            if(collision.transform!=alvo1&&alvo2==null) //escolhe o primeiro alvo como inimigo
            {
                alvo2 = collision.transform;
            }
            if (collision.transform != alvo1 && //continua verificando se a colisão não é o primeiro alvo
                Vector2.Distance(alvo1.position,alvo2.position) //calcula a distancia entre o primeiro alvo e o alvo atual
                >Vector2.Distance(alvo1.position,collision.transform.position)) //se essa distancia for maior que a nova colisão substitue o alvo atual,
                                                                                //focando assim o mais proximo
            {
                alvo2 = collision.transform;
            }
        }
    }
}
