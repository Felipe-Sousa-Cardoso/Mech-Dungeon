using UnityEngine;

public class Choque : CadaMod //instancia um prefab no local da colis�o e passa pra ele o alvo da colis�o
{
    [SerializeField] GameObject prefab; //� o prefab que realiza todo o efeito de choque
    GameObject choqueInstanciado;
    public void choque(GameObject obj, float dano)
    {
        if (prefab != null)
        {
            choqueInstanciado = Instantiate(prefab,obj.transform.position,Quaternion.identity); //cria o prefab na posi��o da colis�o
            ChoqueInstanciado inst = choqueInstanciado.GetComponent<ChoqueInstanciado>(); //busca no objeto instanciado o componente choqueestanciado
                                                                                          //(serve para evitar buscar mais de uma vez)
            inst.Alvo1 = obj.transform; //passa o alvo da colis�o
            inst.dano = dano; //Passa o dano do disparo
        }       
    }   
}
