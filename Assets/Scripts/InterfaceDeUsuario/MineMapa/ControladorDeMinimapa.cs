using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDeMinimapa : MonoBehaviour
{
    [SerializeField] GameObject cadaSala;
    [SerializeField] GameObject marcador;

    public void AumentarMiniMapa(Vector2 posição, int tipoDaSala, List<bool> vizinhos)
    {
        GameObject obj = Instantiate(cadaSala, transform);
        obj.transform.localPosition = new Vector3(posição.x * 100, posição.y * 100, 0);
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
    public void trocarposição(Vector2 posição)
    {
        marcador.transform.localPosition = new Vector2( posição.x*100,posição.y*100);
    }
}
