using Unity.VisualScripting;
using UnityEngine;

public class AtivaDesativa : MonoBehaviour
{
    [SerializeField] GameObject mineMapa;
    [SerializeField] GameObject marcador;
    [SerializeField] GameObject recomešar;
    private void Start()
    {
        mineMapa = GetComponentInChildren<ControladorDeMinimapa>().gameObject;
        marcador = GetComponentInChildren<Marcador>().gameObject;
        recomešar = GetComponentInChildren<Recomešar>().gameObject;
    }
    private void Update()
    {
        if (ControladorDeInput.MineMapa())
        {
            mineMapa.SetActive(true);
            marcador.SetActive(true);
            recomešar.SetActive(true);
        }
        else
        {
            mineMapa.SetActive(false);
            marcador.SetActive(false);
            recomešar.SetActive(false);
        }
    }

}
