using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartaDeDash : MonoBehaviour
{
    
    [SerializeField] Image Icone;
    [SerializeField] Image CartaToda;
    [SerializeField] Image borda;
    [SerializeField] Sprite[] bordas;//Conjunto dos sprit es das bordas
    [SerializeField] Text Nome;
    [SerializeField] Text Descrição;
    [SerializeField] Sprite[] Atributos; //Conjunto dos sprites dos atributos
    [SerializeField] Transform Atributo;

    ParticleSystem particle;

    public JogadorMovimento jog; //informações que são definidas pelo gerenciador de cartas
    public UsoDash dah;
    public CadaCarta carta;
    public int qualidade;
    public int atributo;

    private void OnEnable()
    {
        particle = GetComponent<ParticleSystem>();
        CartaToda = GetComponent<Image>();
        Borda();
        Atributod();

        Icone.sprite = carta.sprite;
        Nome.text = carta.Nome;
        Descrição.text = carta.Descricao;
    }
    
    public void DarODash() //Acesado pelo botão
    {
        jog.JogadorAtributos.ArmaAtiva = true;
        jog.GetSetDash = dah;
        dah.Valores.QualidadeDeManufatura = qualidade;
        dah.Valores.AtributoEspecial = atributo;
        jog.UpdateDash();
        GerenciadorDeCartas.instancia.Destruir(0);
    }
    void Borda()//Modifica a borda conforme a qualidade de manufatura
    {
        switch (qualidade)
        {
            case 0: borda.color = new Vector4(1, 1, 1, 0); break;
            case 1: borda.sprite = bordas[0]; break;
            case 2: borda.sprite = bordas[1]; break;
            case 3: borda.sprite = bordas[2]; break;
        }
    }
    void Atributod()//Aplica a animação e o icone de cada atributo
    {
        ParticleSystem.MainModule main = particle.main;
        switch (atributo)
        {
            case 0: particle.Pause(); break;
            case 1: main.startColor = Color.blue; CartaToda.color = new Color(0.722f, 1, 0.973f); IconeAtributo(0, 1); break;
            case 2: main.startColor = Color.red; CartaToda.color = new Color(1, 0.514f, 0.514f); IconeAtributo(1, 1); break;
            case 3: main.startColor = Color.yellow; CartaToda.color = new Color(0.984f, 1, 0.514f); IconeAtributo(2, 1); break;
        }
    }
    public void IconeAtributo(int Qual,int Quantos)
    {
        Image icone;
        int x = 1;
        foreach (Transform filho in Atributo)
        {
            icone = filho.GetComponent<Image>();
            if (x <= Quantos)
            {
               
                icone.sprite = Atributos[Qual];
                x++;
            }
            else
            {
                icone.color = new Color(1, 1, 1, 0);
            }
        }

    }
}
