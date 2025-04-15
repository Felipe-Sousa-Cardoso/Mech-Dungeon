using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

 public class GerenciadorDeCartas : MonoBehaviour 
{
    public static GerenciadorDeCartas instancia;
    [SerializeField] GameObject carta;
    CartaDeDash cartaIsnt;
    [SerializeField] Transform Canvas;

    void Start()
    {
        instancia = this;
    }
    public void CriarCarta (JogadorMovimento jog, params UsoDash[] cartas ) //Cria as cartas para os dashs
    {

        
        for ( int i = 0; i < cartas.Length; i++ )
        {
            cartaIsnt = carta.GetComponent<CartaDeDash>();
            cartaIsnt.carta = cartas[i].Valores;
            cartaIsnt.jog = jog;
            cartaIsnt.dah = cartas[i];

            int rand = Random.Range(0, 100); //Roleta a qualidade da carta
            switch (rand)
            {
                case int n when (n < 50): cartaIsnt.qualidade = 0; break;
                case int n when (n < 80): cartaIsnt.qualidade = 1; break;
                case int n when (n <= 100): cartaIsnt.qualidade = 2; break;
            }
            rand = Random.Range(0, 100); //Roleta o atributo da carta
            switch (rand)
            {
                case int n when (n < 40): cartaIsnt.atributo = 0; break;
                case int n when (n < 60): cartaIsnt.atributo = 1; break;
                case int n when (n < 80): cartaIsnt.atributo = 2; break;
                case int n when (n <= 100): cartaIsnt.atributo = 3; break;
            }

            GameObject inst; //Seleciona a carta que foi instanciada para poder alterar sua posição
            switch (i)
            {
                case 0: inst = Instantiate(carta, Canvas); inst.transform.localPosition = new Vector3(-200, 0, 0); break;
                case 1: inst = Instantiate(carta, Canvas); inst.transform.localPosition = new Vector3(200, 0, 0); break;
            }            
        }
    }
    public void CriarCarta (JogadorArma jog, params UsoArma[] cartas)
    {
        print(cartas[0].name);
    }
    public void Sumir()
    {
        foreach (Transform filho in this.transform)
        {
            filho.gameObject.SetActive(false);
        }

    } //Apaga momentaneamente as cartas, é chamado externamente
    public void Destruir()
    {
        foreach (Transform filho in this.transform)
        {
            Destroy(filho.gameObject);
        }
        Resources.UnloadUnusedAssets();
    }//destroi as cartas, é chamado externamente
    public void Aparecer()
    {
        foreach (Transform filho in this.transform)
        {
            filho.gameObject.SetActive(true);
        }

    }//mostra as cartas as cartas, é chamado externamente
    public void EmbaralharArray<T>(T[] lista) //embaralha a lista, serve para qualquer array, é chamado externamente
    {
        for (int i = 0; i < lista.Length; i++)
        {
            int rand = Random.Range(i, lista.Length);
            (lista[i], lista[rand]) = (lista[rand], lista[i]);
        }

    }

}
