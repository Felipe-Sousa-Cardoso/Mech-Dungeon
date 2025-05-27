using UnityEngine;
using UnityEngine.UI;

public class ControladorDeMinimapa : MonoBehaviour
{
    public GameObject cadaSala;
    public void AumentarMiniMapa(Vector2 posi��o, int tipoDaSala)
    {
        GameObject obj = Instantiate(cadaSala,transform);
        obj.transform.localPosition = new Vector3(posi��o.x*100, posi��o.y*100, 0);
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
