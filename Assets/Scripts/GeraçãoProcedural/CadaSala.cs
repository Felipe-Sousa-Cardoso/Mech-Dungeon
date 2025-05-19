using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CadaSala : MonoBehaviour
{
    [SerializeField] List<bool> vizinhos;
    [SerializeField] List<GameObject> portas;

    [SerializeField] Vector2 posição;

    public Vector2 Posição { get => posição; set => posição = value; }
    public List<bool> Vizinhos { get => vizinhos; set => vizinhos = value; }

    void Awake()
    {
        vizinhos = new List<bool>() { false, false, false, false };
    }
    private void Start()
    {
        int x = 0;
        foreach(bool bl in vizinhos)
        {
            portas[x].SetActive(!vizinhos[x]);
            x++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
