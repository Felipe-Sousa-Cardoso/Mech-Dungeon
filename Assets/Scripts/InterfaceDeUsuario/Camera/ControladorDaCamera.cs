using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDaCamera : MonoBehaviour
{
    [SerializeField] GeradorAleatorio geradorAleatorio;
    [SerializeField] Vector3 posição;

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
            transform.position = new Vector3(geradorAleatorio.PosiçãoAtual.x, geradorAleatorio.PosiçãoAtual.y,-10);
        }
        
    }
}
