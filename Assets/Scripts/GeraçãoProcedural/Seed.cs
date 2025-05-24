using UnityEngine;
using UnityEngine.SceneManagement;

public class Seed : MonoBehaviour
{
    public string seed = "";
    public int atualSeed = 0;
    Seed instance;
    private void Awake()
    {      
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        if (seed == "")
        {
            seed = Random.value.ToString();
        }
        atualSeed = (seed + SceneManager.GetActiveScene().buildIndex.ToString()).GetHashCode();//Trasforma qualquer string em um numero inteiro

        Random.InitState(atualSeed); //Usa esse numero inteiro para determinar o estado inicial do Random, fazendo que qualquer aleatoriedade baseada
        //nesse método seja deterministica
    }
}
