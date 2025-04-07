using UnityEngine;

public class Choque : CadaMod //instancia um prefab no local da colisão e passa pra ele o alvo da colisão
{
    [SerializeField] GameObject prefab; //É o prefab que realiza todo o efeito de choque
    GameObject choqueInstanciado;
    public void choque(GameObject obj)
    {
        if (prefab != null)
        {
            choqueInstanciado = Instantiate(prefab,obj.transform.position,Quaternion.identity); //cria o prefab na posição da colisão
            choqueInstanciado.GetComponent<ChoqueInstanciado>().Alvo1 = obj.transform; //passa o alvo da colisão
        }       
    }   
}
