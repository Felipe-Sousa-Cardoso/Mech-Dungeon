using UnityEngine;

public class Acido : CadaMod
{
    [SerializeField] GameObject prefab; //É o prefab que realiza todo o efeito de acido
    GameObject AcidoInstanciado;
    public void acido(GameObject obj, float dano)
    {
        if (prefab != null)
        {
            AcidoInstanciado = Instantiate(prefab, obj.transform.position, Quaternion.identity); //cria o prefab na posição da colisão
            AcidoInstanciado inst = AcidoInstanciado.GetComponent<AcidoInstanciado>(); //busca no objeto instanciado o componente AcidoInstanciado
                                                                                          //(serve para evitar buscar mais de uma vez)
            inst.Alvo = obj.transform; //passa o alvo da colisão
            inst.dano = dano; //Passa o dano do disparo
        }
    }
}
