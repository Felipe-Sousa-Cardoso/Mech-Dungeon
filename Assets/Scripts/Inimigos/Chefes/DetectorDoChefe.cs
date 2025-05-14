using UnityEngine;

public class DetectorDoChefe : MonoBehaviour
{
    [SerializeField] CadaHabilidadeChefe habilidade;

    private void Start()
    {
        habilidade = GetComponentInParent<CadaHabilidadeChefe>();
    }
    protected void OnTriggerEnter2D(Collider2D collision)//Quando um jogador entra na colisão define a variável 
    {
        if (collision.CompareTag("Jogador")&&habilidade)
        {
            habilidade.Jogador = collision.transform;
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)//Quando um jogador sai da colisão redefine a variável
    {
        if (collision.CompareTag("Jogador"))
        {
            habilidade.Jogador = null;
        }
    }
}
