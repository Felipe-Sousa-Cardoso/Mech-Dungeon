using UnityEngine;

public class Choque : CadaMod //instancia um prefab no local da colis�o e passa pra ele o alvo da colis�o
{
    [SerializeField] GameObject prefab; //� o prefab que realiza todo o efeito de choque
    GameObject choqueInstanciado;
    public void choque(GameObject obj)
    {
        if (prefab != null)
        {
            choqueInstanciado = Instantiate(prefab,obj.transform.position,Quaternion.identity); //cria o prefab na posi��o da colis�o
            choqueInstanciado.GetComponent<ChoqueInstanciado>().Alvo1 = obj.transform; //passa o alvo da colis�o
        }       
    }   
}
