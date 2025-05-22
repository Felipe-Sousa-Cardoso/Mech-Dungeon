using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CadaSala : MonoBehaviour
{
    [SerializeField] List<bool> vizinhos;
    [SerializeField] List<GameObject> portas;
    [SerializeField] List<GameObject> marcadores; //0 item e 1 boss
    [SerializeField] GameObject interior;
    [SerializeField] GeradorAleatorio gerador;
    [SerializeField] int quantidadeDeInimigos;
    [SerializeField] GameObject interiorInstanciado;
    [SerializeField] int tipoDeSala;//0 normal, 1 item e 2 chefe
    List<Vector2> offSettDasPortas = new List<Vector2> { new Vector2(10f, 0), new Vector2(0, 6f), new Vector2(-10f, 0), new Vector2(0, -6f) };


    [SerializeField] float index;

    [SerializeField] Vector2 posi��o;

    public Vector2 Posi��o { get => posi��o; set => posi��o = value; }
    public List<bool> Vizinhos { get => vizinhos; set => vizinhos = value; }
    public GeradorAleatorio Gerador { get => gerador; set => gerador = value; }
    public GameObject Interior { get => interior; set => interior = value; }
    public int TipoDeSala { get => tipoDeSala; set => tipoDeSala = value; }

    void Awake()
    {
        vizinhos = new List<bool>() { false, false, false, false };
    }
    private void Start()
    {
        index = 1;
        if (tipoDeSala > 0)
        {
            int index2 = 0;
            foreach (GameObject porta in portas)
            {
                GameObject obj = Instantiate(marcadores[tipoDeSala - 1], transform);
                obj.transform.localPosition = offSettDasPortas[index2];
                index2++;
            }
        }
    }
    private void LateUpdate()
    {
        if (quantidadeDeInimigos == 0) //Quando a quantidade de inimigos � 0 libera as portas que d�o nos vizinhos
        {
            int x = 0;
             foreach (bool bl in vizinhos)
             {
                if (portas[x])
                {
                    portas[x].SetActive(!vizinhos[x]);
                }                              
                x++;
             }
        }
        if (interiorInstanciado) 
        {
            if (index > 0) //Fecha as portas ap�s 2 segundos que o interior foi instanciado
            {
                index -= Time.deltaTime;
            }
            else
            {
                if (quantidadeDeInimigos > 0)
                {
                    int x = 0;

                    foreach (bool bl in vizinhos)
                    {
                        if (portas[x])
                        {
                             portas[x].SetActive(true);
                        }
                       
                        x++;
                    }
                }
            }
        }      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jogador"))
        {
            if (gerador)
            {
                gerador.Posi��oAtual = posi��o;
                if (interior&&!interiorInstanciado)
                {
                    interiorInstanciado = Instantiate(interior, transform);
                }
            }
        }
        if (collision.CompareTag("Inimigo"))
        {
            quantidadeDeInimigos++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            quantidadeDeInimigos--;
        }
    }
}
