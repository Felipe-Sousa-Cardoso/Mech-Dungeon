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
    bool vulner�vel = true;

    #region M�todos de acesso
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
            Destroy(gameObject); // j� existe, destr�i o duplicado
        }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        dados.MaxVida = 40;
        dados.Vida = dados.MaxVida;
        SceneManager.sceneLoaded+= ResetarPosi��o;
    }
   

    void ResetarPosi��o(Scene scene, LoadSceneMode mode)
    {
        if (gameObject!=null)
        {
            transform.position = Vector3.zero;
        }   
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }
    
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

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= ResetarPosi��o;
        SceneManager.LoadScene(0);
    }



}
