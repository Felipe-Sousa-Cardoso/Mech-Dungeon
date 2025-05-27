using UnityEngine;
using UnityEngine.UI;

public class ControladorDeMinimapa : MonoBehaviour
{
    public GameObject cadaSala;
    public void AumentarMiniMapa(Vector2 posição, int tipoDaSala)
    {
        GameObject obj = Instantiate(cadaSala,transform);
        obj.transform.localPosition = new Vector3(posição.x*100, posição.y*100, 0);
        if (tipoDaSala == 1)
        {
            obj.GetComponent<Image>().color = Color.yellow;
        }
        if (tipoDaSala == 2)
        {
            obj.GetComponent<Image>().color = Color.red;
        }
    }
}
