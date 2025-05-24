using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDaCamera : MonoBehaviour
{
    [SerializeField] GeradorAleatorio geradorAleatorio;
    [SerializeField] Vector3 posi��o;

    private void Start()
    {
        if (FindFirstObjectByType<JogadorAtributos>())
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
