using UnityEngine;

public class Gelo : CadaMod
{
    [SerializeField] GameObject prefab; //� o prefab que realiza todo o efeito de gelo
    public void gelo(GameObject obj, float dano) //Metodo que � chamado depois do disparo atingir
    {
        if (prefab != null)
        {
            if (obj.GetComponentInChildren<GeloInstanciado>() == null) //caso n�o exista ainda cria o prefab como filho do obejto atingido
            {
                Instantiate(prefab, obj.transform); //Instancia o objet que controla o efeito de gelo
            }
            GeloInstanciado inst = obj.GetComponentInChildren<GeloInstanciado>(); //busca o componente GeloInstanciado no alvo do disparo

            if (inst != null)
            {             
                if (inst.Stacks < 4) //Verifica o m�ximo de cargas de gelo
                {
                    inst.Stacks++;
                    inst.Alvo = obj.transform;
                }
            }
        }
    }
}
