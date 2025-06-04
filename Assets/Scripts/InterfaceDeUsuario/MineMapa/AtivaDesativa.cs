using Unity.VisualScripting;
using UnityEngine;

public class AtivaDesativa : MonoBehaviour
{
    [SerializeField] GameObject mineMapa;
    [SerializeField] GameObject marcador;
    [SerializeField] GameObject recome�ar;
    private void Start()
    {
        mineMapa = GetComponentInChildren<ControladorDeMinimapa>().gameObject;
        marcador = GetComponentInChildren<Marcador>().gameObject;
        recome�ar = GetComponentInChildren<Recome�ar>().gameObject;
    }
    private void Update()
    {
        if (ControladorDeInput.MineMapa())
        {
            mineMapa.SetActive(true);
            marcador.SetActive(true);
            recome�ar.SetActive(true);
        }
        else
        {
            mineMapa.SetActive(false);
            marcador.SetActive(false);
            recome�ar.SetActive(false);
        }
    }

}
