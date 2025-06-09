using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDoCanvas : MonoBehaviour
{
    public static ControladorDoCanvas instance;
    void Awake()
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
    }
    private void OnEnable()
    {
        // Se inscreve no evento
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Visibilidade();
    }

    void Visibilidade()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
