using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDaCamera : MonoBehaviour
{
    [SerializeField] GeradorAleatorio geradorAleatorio;

    private void Start()
    {
        if (FindFirstObjectByType<GeradorAleatorio>())
        {
            geradorAleatorio = FindFirstObjectByType<GeradorAleatorio>();
        }
    }  
    void LateUpdate()
    {
        if (geradorAleatorio)
        {
            transform.position = new Vector3(geradorAleatorio.Posi��oAtual.x, geradorAleatorio.Posi��oAtual.y,-10);
        }
        
    }
}
