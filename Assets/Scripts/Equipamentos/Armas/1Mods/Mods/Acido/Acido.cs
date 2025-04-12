using UnityEngine;

public class Acido : CadaMod
{
    [SerializeField] GameObject prefab; //� o prefab que realiza todo o efeito de acido
    GameObject AcidoInstanciado;
    public void acido(GameObject obj, float dano)
    {
        if (prefab != null)
        {
            if (obj.GetComponentInChildren<AcidoInstanciado>() == null) //caso n�o exista ainda cria o prefab como filho do obejto atingido
            {
                Instantiate(prefab, obj.transform); 
            }
            AcidoInstanciado inst = obj.GetComponentInChildren<AcidoInstanciado>(); //busca o componente AcidoInstanciado no alvo do disparo
            

           if (inst.Stacks < 6) //Verifica o m�ximo de cargas de �cido
           {
                inst.Alvo = obj.transform; //Passa o alvo da colis�o
                inst.Dano += dano; //Passa o dano do disparo
                inst.Stacks++;               
           }           
        }
    }
}
