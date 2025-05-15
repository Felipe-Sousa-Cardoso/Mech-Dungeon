using UnityEngine;

public class ControladorDaCamera : MonoBehaviour
{
    [SerializeField] Transform jogador;
   
    private void Start()
    {
        if (FindFirstObjectByType<JogadorAtributos>())
        {
            jogador = FindFirstObjectByType<JogadorAtributos>().transform;
        }  
    }
    void LateUpdate()
    {
        if (jogador)
        {
            transform.position = new Vector3( jogador.transform.position.x, jogador.transform.position.y,-10);
        }
        
    }
}
