using UnityEngine;

public class ControladorDaCamera : MonoBehaviour
{
    [SerializeField] Transform jogador;
    void LateUpdate()
    {
        if (jogador)
        {
            transform.position = new Vector3( jogador.transform.position.x, jogador.transform.position.y,-10);
        }
        
    }
}
