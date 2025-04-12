using UnityEngine;

public class Acido : CadaMod
{
    [SerializeField] GameObject prefab; //� o prefab que realiza todo o efeito de acido
    public void acido(GameObject obj, float dano) //Metodo que � chamado depois do disparo atingir
    {
        if (prefab != null)
        {
            if (obj.GetComponentInChildren<AcidoInstanciado>() == null) //caso n�o exista ainda cria o prefab como filho do obejto atingido
            {
                Instantiate(prefab, obj.transform); //Instancia o objet que controla o dano de �cido
            }
            AcidoInstanciado inst = obj.GetComponentInChildren<AcidoInstanciado>(); //busca o componente AcidoInstanciado no alvo do disparo
            

           if (inst.Stacks < 6) //Verifica o m�ximo de cargas de �cido
           {
                inst.Alvo = obj.transform; //Passa o alvo da colis�o
                inst.Dano += dano; //Passa o dano do disparo
                inst.Stacks++; //Aumenta a quantidade de stacks            
           }           
        }
    }
}
