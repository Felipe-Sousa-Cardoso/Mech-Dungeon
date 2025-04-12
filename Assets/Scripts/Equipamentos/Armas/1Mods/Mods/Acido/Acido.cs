using UnityEngine;

public class Acido : CadaMod
{
    [SerializeField] GameObject prefab; //É o prefab que realiza todo o efeito de acido
    public void acido(GameObject obj, float dano) //Metodo que é chamado depois do disparo atingir
    {
        if (prefab != null)
        {
            if (obj.GetComponentInChildren<AcidoInstanciado>() == null) //caso não exista ainda cria o prefab como filho do obejto atingido
            {
                Instantiate(prefab, obj.transform); //Instancia o objet que controla o dano de ácido
            }
            AcidoInstanciado inst = obj.GetComponentInChildren<AcidoInstanciado>(); //busca o componente AcidoInstanciado no alvo do disparo
            

           if (inst.Stacks < 6) //Verifica o máximo de cargas de ácido
           {
                inst.Alvo = obj.transform; //Passa o alvo da colisão
                inst.Dano += dano; //Passa o dano do disparo
                inst.Stacks++; //Aumenta a quantidade de stacks            
           }           
        }
    }
}
