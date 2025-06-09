using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ControladorDeInput : MonoBehaviour
{

    // Variáveis de armazenam o valor de cada input
    Vector2 MovementInput;
    bool dash;
    bool mineMapa;
    bool HabilidadeQ;
    bool Tiro;
    bool TrocaDeArma;
    bool miniMapa;
#region VerificaçãoDeUnicidade
    //Verifica se exite apenas uma intancia do controlador de Input
    public static ControladorDeInput instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    #region Inputs
    //Cria cada input e seu respectivo método de acesso
    void OnMove(InputValue valor){
        MovementInput = valor.Get<Vector2>();
    }
    public static Vector2 GetMoveInput()
    {
        return instance.MovementInput;
    }
    void OnDash(InputValue valor){
        dash = valor.isPressed;
    }
    public static bool GetDashInput() 
    {
        return instance.dash;
    }
    void OnHabilidadeE(InputValue valor)
    {
        mineMapa = valor.isPressed;
    }
    public static bool MineMapa()
    {   
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            return instance.mineMapa;
        }
        else
        {
            return false;
        }
        
    }
    void OnHabilidadeQ(InputValue valor)
    {
        HabilidadeQ = valor.isPressed;
    }
    public static bool GetHabilidadeQInput()
    {
        return instance.HabilidadeQ;
    }
    void OnTiro(InputValue valor)
    {
        Tiro = valor.isPressed;
    }
    public static bool GetTiroInput()
    {
        return instance.Tiro;
    }
    void OnTrocaDeArma(InputValue valor)
    {
        TrocaDeArma = valor.isPressed;
    }
    public static bool GetTrocaArmaInput()
    {
        return instance.TrocaDeArma;
    }


    #endregion
    #region Correção
    //Reseta o valor dos inputs no final da cada frame, para garantir que possam sem usados novamente
    private void LateUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
        dash = false;
        HabilidadeQ = false;
        TrocaDeArma = false;
    }
#endregion
}