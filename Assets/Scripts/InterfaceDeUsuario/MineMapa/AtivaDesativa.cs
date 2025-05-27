using Unity.VisualScripting;
using UnityEngine;

public class AtivaDesativa : MonoBehaviour
{
    [SerializeField] GameObject mineMapa;
    private void Start()
    {
        mineMapa = GetComponentInChildren<ControladorDeMinimapa>().gameObject;
    }
    private void Update()
    {
        if (ControladorDeInput.MineMapa())
        {
            mineMapa.SetActive(true);
        }
        else
        {
            mineMapa.SetActive(false);
        }
    }

}
