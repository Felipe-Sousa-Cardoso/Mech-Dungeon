using Unity.VisualScripting;
using UnityEngine;

public class AtivaDesativa : MonoBehaviour
{
    [SerializeField] GameObject mineMapa;
    [SerializeField] GameObject marcador;
    private void Start()
    {
        mineMapa = GetComponentInChildren<ControladorDeMinimapa>().gameObject;
        marcador = GetComponentInChildren<Marcador>().gameObject;
    }
    private void Update()
    {
        if (ControladorDeInput.MineMapa())
        {
            mineMapa.SetActive(true);
            marcador.SetActive(true);
        }
        else
        {
            mineMapa.SetActive(false);
            marcador.SetActive(false);
        }
    }

}
