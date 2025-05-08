using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorAtributos : MonoBehaviour, IDanificavel
{
    Animator anim;

    bool armaAtiva = true; //Verifica se o jogador pode atirar
    [SerializeField] DadosDoJogador dados;

    float tempoEntreHits = 1;
    bool vulner�vel = true;

    #region M�todos de acesso
    public bool ArmaAtiva
    {
        get { return armaAtiva; }
        set { armaAtiva = value; }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        dados.MaxVida = 10;
        dados.Vida = dados.MaxVida;
    }
    #endregion
    public void AtivarArma()
    {
        armaAtiva = true;
    }

    public void Danificar(float Quanto)
    {
        if (vulner�vel)
        {
            anim.SetTrigger("hit");
            dados.Vida -= Quanto;
            if (dados.Vida <= 0)
            {
                Destroy(gameObject);
            }
            StartCoroutine(ivulnerabilidade(tempoEntreHits));
        }
        
    }

    IEnumerator ivulnerabilidade(float tempo)
    {
        vulner�vel = false;
        yield return new WaitForSeconds(tempo);
        vulner�vel = true;
    }

    


}
