using UnityEngine;

public class Acido : CadaMod
{
    [SerializeField] GameObject prefab; //É o prefab que realiza todo o efeito de acido
    GameObject AcidoInstanciado;
    public void acido(GameObject obj, float dano)
    {
        if (prefab != null)
        {
            if (obj.GetComponentInChildren<AcidoInstanciado>() == null) //caso não exista ainda cria o prefab como filho do obejto atingido
            {
                Instantiate(prefab, obj.transform); 
            }
            AcidoInstanciado inst = obj.GetComponentInChildren<AcidoInstanciado>(); //busca o componente AcidoInstanciado no alvo do disparo
            

           if (inst.Stacks < 6) //Verifica o máximo de cargas de ácido
           {
                inst.Alvo = obj.transform; //Passa o alvo da colisão
                inst.Dano += dano; //Passa o dano do disparo
                inst.Stacks++;               
           }           
        }
    }
}
