using UnityEngine;

public class Acido : CadaMod
{
    [SerializeField] GameObject prefab; //� o prefab que realiza todo o efeito de acido
    GameObject AcidoInstanciado;
    public void acido(GameObject obj, float dano)
    {
        if (prefab != null)
        {
            AcidoInstanciado = Instantiate(prefab, obj.transform.position, Quaternion.identity); //cria o prefab na posi��o da colis�o
            AcidoInstanciado inst = AcidoInstanciado.GetComponent<AcidoInstanciado>(); //busca no objeto instanciado o componente AcidoInstanciado
                                                                                          //(serve para evitar buscar mais de uma vez)
            inst.Alvo = obj.transform; //passa o alvo da colis�o
            inst.dano = dano; //Passa o dano do disparo
        }
    }
}
