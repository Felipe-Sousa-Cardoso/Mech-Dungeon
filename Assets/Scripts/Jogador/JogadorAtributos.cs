using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorAtributos : MonoBehaviour, IDanificavel
{
    Animator anim;

    bool armaAtiva = true; //Verifica se o jogador pode atirar
    [SerializeField] float vida;

    float tempoEntreHits = 1;
    bool vulnerável = true;

    #region Métodos de acesso
    public bool ArmaAtiva
    {
        get { return armaAtiva; }
        set { armaAtiva = value; }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    #endregion
    public void AtivarArma()
    {
        armaAtiva = true;
    }

    public void Danificar(float Quanto)
    {
        if (vulnerável)
        {
            anim.SetTrigger("hit");
            vida -= Quanto;
            if (vida <= 0)
            {
                Destroy(gameObject);
            }
            StartCoroutine(ivulnerabilidade(tempoEntreHits));
        }
        
    }

    IEnumerator ivulnerabilidade(float tempo)
    {
        vulnerável = false;
        yield return new WaitForSeconds(tempo);
        vulnerável = true;
    }

    


}
