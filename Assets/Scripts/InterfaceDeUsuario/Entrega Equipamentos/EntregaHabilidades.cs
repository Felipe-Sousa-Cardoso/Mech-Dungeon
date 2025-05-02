using UnityEngine;

public class EntregaHabilidades : MonoBehaviour
{
    [SerializeField] CadaHabilidade[] listaDeHabilidades;
    void Start()
    {
        listaDeHabilidades = Resources.LoadAll<CadaHabilidade>("Habilidades"); //carrega todas as habilidades da pasta Resorces para o array    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
