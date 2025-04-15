using UnityEngine;

public class Gelo : CadaMod
{
    [SerializeField] GameObject prefab; //É o prefab que realiza todo o efeito de gelo
    public void gelo(GameObject obj, float dano) //Metodo que é chamado depois do disparo atingir
    {
        if (prefab != null)
        {
            if (obj.GetComponentInChildren<GeloInstanciado>() == null) //caso não exista ainda cria o prefab como filho do obejto atingido
            {
                Instantiate(prefab, obj.transform); //Instancia o objet que controla o efeito de gelo
            }
            GeloInstanciado inst = obj.GetComponentInChildren<GeloInstanciado>(); //busca o componente GeloInstanciado no alvo do disparo

            if (inst != null)
            {             
                if (inst.Stacks < 4) //Verifica o máximo de cargas de gelo
                {
                    inst.Stacks++;
                    inst.Alvo = obj.transform;
                }
            }
        }
    }
}
