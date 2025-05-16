using System.Collections.Generic;
using UnityEngine;

public class GeradorAleatorio : MonoBehaviour
{
    [SerializeField] GameObject cadaSala;
    [SerializeField] int maximoDeCorredores;
    [SerializeField] int tamanhoDeCadaCorredor;
    List<Vector2> direçoes = new List<Vector2> { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) };
    void Start()
    {
        GameObject obj = Instantiate(cadaSala, Vector3.zero, Quaternion.identity);
        obj.GetComponent<SpriteRenderer>().color = Color.red;
        EmbaralharLista(direçoes);
        maximoDeCorredores = Random.Range(2, 5);
        

        CriarCorredores();
    }
    void CriarCorredores()
    {
        
        for (int i = 0; i < maximoDeCorredores; i++)
        {
            Vector2 posiçãoAtual = Vector2.zero;
            tamanhoDeCadaCorredor = Random.Range(1, 5);
            for (int j = 1; j <= tamanhoDeCadaCorredor; j++)
            {
                Instantiate(cadaSala, posiçãoAtual + direçoes[i]*j, Quaternion.identity);
            }
            
        }
    }
    public void EmbaralharLista<T>(List<T> lista) //embaralha a lista, serve para qualquer lista, é chamado externamente
    {
        for (int i = 0; i < lista.Count; i++)
        {
            int rand = Random.Range(i, lista.Count);
            (lista[i], lista[rand]) = (lista[rand], lista[i]);
        }
    }
}
