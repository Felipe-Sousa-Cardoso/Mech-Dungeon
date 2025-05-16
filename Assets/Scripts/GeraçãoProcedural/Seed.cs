using UnityEngine;

public class Seed : MonoBehaviour
{
    public string seed = "";
    public int atualSeed = 0;

    private void Awake()
    {
        if (seed == "")
        {
            seed = Random.value.ToString();
        }
        atualSeed = seed.GetHashCode(); //Trasforma qualquer string em um numero inteiro

        Random.InitState(atualSeed); //Usa esse numero inteiro para determinar o estado inicial do Random, fazendo que qualquer aleatoriedade baseada
        //nesse método seja deterministica
    }
}
