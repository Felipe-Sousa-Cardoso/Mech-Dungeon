using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorMovimento : MonoBehaviour
{
    JogadorAtributos jogadorAtributos; //Script que controla atributos gerais do jogador
    [SerializeField] UsoDash DashAtual; //É o objeto que contem o script do Dash
    [SerializeField] DadosDoDash DadosDash; //Armazena os valores do Dash, é usado para controle de cargas e interface, � um objeto Scriptavel
    Vector3 MousePos;
    bool isdashing; 
    Vector3 direção;
    float VelocidadeDeMovimento = 200;

    TrailRenderer TrailRenderer;
    Rigidbody2D rb;

    public JogadorAtributos JogadorAtributos //Acessado para auterear atributos no sistema de cartas
    {
        get { return jogadorAtributos; }
        set { value = jogadorAtributos; }
    }
    
    private void Awake()
    {
        jogadorAtributos = GetComponent<JogadorAtributos>();
        rb = GetComponent<Rigidbody2D>();   
        TrailRenderer = rb.GetComponent<TrailRenderer>();
    }
    void Start()
    {
        ResetDash();
        DadosDash.ContadorCDdash = DadosDash.CDdoDash;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TrailRenderer.emitting = isdashing; //Controla a emiss�o do rastro baseado se o personagem está fazendo o dash
        if (!isdashing)
        {
            direção = new Vector3(ControladorDeInput.GetMoveInput().x, ControladorDeInput.GetMoveInput().y);
        }
        rb.linearVelocity = direção*Time.deltaTime * VelocidadeDeMovimento;  
 
    }
    private void Update()
    { 
        if (ControladorDeInput.GetDashInput())
        {  
            if (DadosDash.CargasDoDash>=1&&rb.linearVelocity!= new Vector2(0,0))
            {
                StartCoroutine(DashAtual.usodash(this));     
                DadosDash.CargasDoDash --;
            }               
        }

        ControleCDDash();
        GetMousePos();
    }
    void ControleCDDash() //Faz as verificações do Cd e da quantidade de cargas
    {
        if (DadosDash.CargasDoDash < DashAtual.Valores.Cargas)
        {
            DadosDash.ContadorCDdash -= Time.deltaTime;
        }
        if (DadosDash.ContadorCDdash <= 0)
        {
            DadosDash.ContadorCDdash = DadosDash.CDdoDash;
            DadosDash.CargasDoDash++;
        }
    }
    private void ResetDash() //Trás o Dash para a configuraçao inicial
    {
        DashAtual = Resources.Load<UsoDash>("Dashs/DashBasico");
        DashAtual.Valores.QualidadeDeManufatura = 0;
        DashAtual.Valores.AtributoEspecial = 0;
        UpdateDash();
    }
    public void UpdateDash() //Tr�s os valores do script de cada dash para o objeto scriptavel
    {
        DashAtual.updateDash(this);
        GetComponentInChildren<AnimaçãoDoDash>().SpriteDash(DashAtual.Valores.sprite);
    }
    void GetMousePos()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        transform.right = new Vector2(MousePos.x - transform.position.x, MousePos.y - transform.position.y);
    } //Pega a posi��o do mouse em referencia a posição atual
    #region Métodos de acesso
    public float VelLMov
    {
        get { return VelocidadeDeMovimento; }
        set { VelocidadeDeMovimento=value; }
    }
    public UsoDash GetSetDash
    {
        get { return DashAtual; }
        set { DashAtual = value; }
    }
    public DadosDoDash GetSetDashAtual
    {
        get { return DadosDash; }
        set { DadosDash = value; }
    }
    public bool Isdashing
    {
        get { return isdashing; }
        set { isdashing = value; }
    }
    #endregion

}
