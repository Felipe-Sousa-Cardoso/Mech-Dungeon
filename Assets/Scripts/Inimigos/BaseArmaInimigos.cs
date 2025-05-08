using UnityEngine;

public class BaseArmaInimigos : MonoBehaviour
{
    [SerializeField] protected CadaArmaInimigos dadosDoInimigo;
    [SerializeField] SpriteRenderer sr;
    public CadaArmaInimigos DadosDaArma { get => dadosDoInimigo; set => dadosDoInimigo = value; }

    public void UpdateFoto()
    {
        if (sr&&dadosDoInimigo)
        {
            sr.sprite = dadosDoInimigo.SpriteDaArma;
            sr.color = dadosDoInimigo.CorDaArma;
        }
    }

    
}
