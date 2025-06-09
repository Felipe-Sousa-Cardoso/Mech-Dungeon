using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorDeMinimapa : MonoBehaviour
{
    [SerializeField] GameObject cadaSala;
    [SerializeField] GameObject marcador;

    public static ControladorDeMinimapa instance;

    void Awake()
    {
        instance = this;
    }
    public void AumentarMiniMapa(Vector2 posi��o, int tipoDaSala, List<bool> vizinhos)
    {
        GameObject obj = Instantiate(cadaSala, transform);
        obj.transform.localPosition = new Vector3(posi��o.x * 100, posi��o.y * 100, 0);
        obj.GetComponent<CadaCelulaMineMapa>().Vizinhos = vizinhos;
        if (tipoDaSala == 1)
        {
            obj.GetComponent<Image>().color = Color.yellow;
        }
        if (tipoDaSala == 2)
        {
            obj.GetComponent<Image>().color = Color.red;
        }
    }
    public void trocarposi��o(Vector2 posi��o)
    {
        marcador.transform.localPosition = new Vector2( posi��o.x*100,posi��o.y*100);
    }
    public void DestroyAllChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void OnEnable()
    {
        // Se inscreve no evento
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        DestroyAllChildren();
    }
}
