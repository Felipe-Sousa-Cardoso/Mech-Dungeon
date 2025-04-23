using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

 public class GerenciadorDeCartas : MonoBehaviour 
{
    public static GerenciadorDeCartas instancia; //A instancia que é chamada de fora da classe pelos objetos de dropam os equipamentos

    [SerializeField] GameObject cartaDeDash; //Os prefabs que contem o script que gerencia a carta 
    [SerializeField] GameObject cartaDeArma;

    CartaDeDash cartaDeDashIsnt; //As variáveis que usadas para instanciar cada carta
    CartaDeArmas cartaDeArmaIsnt;

    [SerializeField] Transform CanvasDash;//int 0 //Trasforms que receberam a instanciação da cartas
    [SerializeField] Transform CanvasArmas;//int 1

    void Start()
    {
        instancia = this;
    }
    public void CriarCarta (JogadorMovimento jog, params UsoDash[] cartas ) //Cria as cartas para os dashs
    {   
        for ( int i = 0; i < cartas.Length; i++ )
        {
            cartaDeDashIsnt = cartaDeDash.GetComponent<CartaDeDash>(); //Acessa o componente CartasDeDash de Dash do prefab
            //define no prefab da carta as informações relevantes
            cartaDeDashIsnt.carta = cartas[i].Valores;
            cartaDeDashIsnt.jog = jog;
            cartaDeDashIsnt.dah = cartas[i];

            int rand = Random.Range(0, 100); //Roleta a qualidade da carta
            switch (rand)
            {
                case int n when (n < 50): cartaDeDashIsnt.qualidade = 0; break;
                case int n when (n < 80): cartaDeDashIsnt.qualidade = 1; break;
                case int n when (n <= 100): cartaDeDashIsnt.qualidade = 2; break;
            }
            rand = Random.Range(0, 100); //Roleta o atributo da carta
            switch (rand)
            {
                case int n when (n < 40): cartaDeDashIsnt.atributo = 0; break;
                case int n when (n < 60): cartaDeDashIsnt.atributo = 1; break;
                case int n when (n < 80): cartaDeDashIsnt.atributo = 2; break;
                case int n when (n <= 100): cartaDeDashIsnt.atributo = 3; break;
            }

            GameObject inst; //Instancia o prefab com as informações salvas e altera a posição conforme o indice
            switch (i)
            {
                case 0: inst = Instantiate(cartaDeDash, CanvasDash); inst.transform.localPosition = new Vector3(-200, 0, 0); break;
                case 1: inst = Instantiate(cartaDeDash, CanvasDash); inst.transform.localPosition = new Vector3(200, 0, 0); break;
            }            
        }
    }
    public void CriarCarta (JogadorArma jog, params UsoArma[] cartas)
    {
        for (int i = 0; i < cartas.Length; i++)
        {
            
            cartaDeArmaIsnt = cartaDeArma.GetComponent<CartaDeArmas>(); //Acessa o componente CartasDeArmas da Arma do prefab

            //definem no prefab da carta as informações relevantes
            cartaDeArmaIsnt.Carta = cartas[i].Valores;
            cartaDeArmaIsnt.Jog = jog;
            cartaDeArmaIsnt.Arma = cartas[i];

            int rand = Random.Range(0, 100); //Roleta a qualidade da carta
            switch (rand)
            {
                case int n when (n < 50): cartaDeArmaIsnt.Qualidade = 0; break;
                case int n when (n < 80): cartaDeArmaIsnt.Qualidade = 1; break;
                case int n when (n <= 100): cartaDeArmaIsnt.Qualidade = 2; break;
            }
            rand = Random.Range(0, 100); //Roleta o primeiro atributo da carta (penetração ou perseguir)
            switch (rand)
            {
                case int n when (n < 60): cartaDeArmaIsnt.Atributos[0] = new Vector2Int(0,0); break;
                case int n when (n < 80): cartaDeArmaIsnt.Atributos[0] = new Vector2Int(1, 0); break;
                case int n when (n <= 100): cartaDeArmaIsnt.Atributos[0] = new Vector2Int(2, 0); break;

            }
            rand = Random.Range(0, 100); //Roleta o segundo atributo da carta (Efeitos)
            switch (rand)
            {
                case int n when (n < 40): cartaDeArmaIsnt.Atributos[1] = new Vector2Int(0, 0); break;
                case int n when (n < 60): cartaDeArmaIsnt.Atributos[1] = new Vector2Int(3, 0); break;
                case int n when (n < 80): cartaDeArmaIsnt.Atributos[1] = new Vector2Int(4, 0); break;
                case int n when (n <= 100): cartaDeArmaIsnt.Atributos[1] = new Vector2Int(5, 0); break;
            }

            GameObject inst; //Seleciona a carta que foi instanciada para poder alterar sua posição
            switch (i)
            {
                case 0: inst = Instantiate(cartaDeArma, CanvasArmas); inst.transform.localPosition = new Vector3(-200, 0, 0); break;
                case 1: inst = Instantiate(cartaDeArma, CanvasArmas); inst.transform.localPosition = new Vector3(200, 0, 0); break;
            }
        }
    }
    public void Sumir(int Qual)
    {
        Transform pai = transform;
        switch (Qual)
        {
            case 0: pai = CanvasDash; break;
            case 1: pai = CanvasArmas;  break;
        }
        foreach (Transform filho in pai)
        {
            filho.gameObject.SetActive(false);
        }

    } //Apaga momentaneamente as cartas, é chamado externamente
    public void Destruir(int Qual)
    {
        Transform pai = transform;
        switch (Qual)
        {
            case 0: pai = CanvasDash; break;
            case 1: pai = CanvasArmas; break;
        }
        foreach (Transform filho in pai)
        {
            Destroy(filho.gameObject);
        }
        Resources.UnloadUnusedAssets();
    }//destroi as cartas, é chamado externamente
    public void Aparecer(int Qual)
    {
        Transform pai = transform;
        switch (Qual)
        {
            case 0: pai = CanvasDash; break;
            case 1: pai = CanvasArmas; break;
        }
        foreach (Transform filho in pai)
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
