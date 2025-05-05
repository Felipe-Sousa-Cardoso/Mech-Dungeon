using UnityEngine;

public class BaseArmaInimigos : MonoBehaviour
{
    [SerializeField] protected CadaArmaInimigos dadosDaArma;
    [SerializeField] SpriteRenderer sr;
    public CadaArmaInimigos DadosDaArma { get => dadosDaArma; set => dadosDaArma = value; }

    void Start()
    {
        if (sr&&dadosDaArma)
        {
            sr.sprite = dadosDaArma.Sprite;
            sr.color = dadosDaArma.Cor;
        }
    }

    
}
