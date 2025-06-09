using UnityEngine;
using UnityEngine.SceneManagement;

public class Seed : MonoBehaviour
{
    [SerializeField] string seed = "";
    int atualSeed = 0;
    public static Seed instance;

    public string _Seed { get => seed; set => seed = value; }

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
       
        SceneManager.sceneLoaded += ResetarSeed;
    }


    void ResetarSeed(Scene scene, LoadSceneMode mode)
    {
        atualSeed = (seed + SceneManager.GetActiveScene().buildIndex.ToString()).GetHashCode();//Trasforma qualquer string em um numero inteiro

        Random.InitState(atualSeed); //Usa esse numero inteiro para determinar o estado inicial do Random, fazendo que qualquer aleatoriedade baseada
                                     //nesse método seja deterministica
    }
}
