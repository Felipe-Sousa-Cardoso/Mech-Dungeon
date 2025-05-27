using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogadorAtributos : MonoBehaviour, IDanificavel
{
    Animator anim;

    private static JogadorAtributos instancia;

    bool armaAtiva = true; //Verifica se o jogador pode atirar
    [SerializeField] DadosDoJogador dados;

    float tempoEntreHits = 1;
    bool vulnerável = true;

    #region Métodos de acesso
    public bool ArmaAtiva
    {
        get { return armaAtiva; }
        set { armaAtiva = value; }
    }
    #endregion
    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // já existe, destrói o duplicado
        }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        dados.MaxVida = 40;
        dados.Vida = dados.MaxVida;
        SceneManager.sceneLoaded+= ResetarPosição;
    }
   

    void ResetarPosição(Scene scene, LoadSceneMode mode)
    {
        transform.position = Vector3.zero;
    }
    
    public void AtivarArma()
    {
        armaAtiva = true;
    }

    public void Danificar(float Quanto)
    {
        if (vulnerável)
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
        vulnerável = false;
        yield return new WaitForSeconds(tempo);
        vulnerável = true;
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene(0);
    }



}
