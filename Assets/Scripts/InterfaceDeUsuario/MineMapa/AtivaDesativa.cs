using Unity.VisualScripting;
using UnityEngine;

public class AtivaDesativa : MonoBehaviour
{
    [SerializeField] GameObject mineMapa;
    [SerializeField] GameObject marcador;
    [SerializeField] GameObject recomeçar;
    private void Start()
    {
        mineMapa = GetComponentInChildren<ControladorDeMinimapa>().gameObject;
        marcador = GetComponentInChildren<Marcador>().gameObject;
        recomeçar = GetComponentInChildren<Recomeçar>().gameObject;
    }
    private void Update()
    {
        if (ControladorDeInput.MineMapa())
        {
            mineMapa.SetActive(true);
            marcador.SetActive(true);
            recomeçar.SetActive(true);
        }
        else
        {
            mineMapa.SetActive(false);
            marcador.SetActive(false);
            recomeçar.SetActive(false);
        }
    }

}
