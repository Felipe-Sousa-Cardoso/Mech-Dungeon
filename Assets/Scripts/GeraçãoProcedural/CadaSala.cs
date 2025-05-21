using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CadaSala : MonoBehaviour
{
    [SerializeField] List<bool> vizinhos;
    [SerializeField] List<GameObject> portas;
    [SerializeField] List<GameObject> interiores;
    [SerializeField] GeradorAleatorio gerador;

    [SerializeField] Vector2 posição;

    public Vector2 Posição { get => posição; set => posição = value; }
    public List<bool> Vizinhos { get => vizinhos; set => vizinhos = value; }
    public GeradorAleatorio Gerador { get => gerador; set => gerador = value; }

    void Awake()
    {
        vizinhos = new List<bool>() { false, false, false, false };
    }
    private void Start()
    { 
        int x = 0;
        
        foreach (bool bl in vizinhos)
        {
            portas[x].SetActive(!vizinhos[x]);
            x++;
        }
        int y = Random.Range(0, interiores.Count);
        Instantiate(interiores[y],transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jogador"))
        {
            if (gerador)
            {
                gerador.PosiçãoAtual = posição;
            }
        }
    }
}
