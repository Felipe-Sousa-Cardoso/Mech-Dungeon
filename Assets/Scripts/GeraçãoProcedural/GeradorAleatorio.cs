using System.Collections.Generic;
using UnityEngine;

public class GeradorAleatorio : MonoBehaviour
{
    [SerializeField] GameObject cadaSala; //Objeto de cada sala
    [SerializeField] int maximoDeCorredores;
    [SerializeField] int tamanhoDeCadaCorredor;
    List<Vector2> direçoes = new List<Vector2> { Vector2.right, Vector2.up, Vector2.left, Vector2.down };
    [SerializeField] List<Vector2> salasOcupadas;


    void Start()
    {
        GameObject obj = Instantiate(cadaSala, Vector3.zero, Quaternion.identity); //Instancia a sala inicial e pinta ela de vermelho
        obj.GetComponent<SpriteRenderer>().color = Color.red;
        salasOcupadas.Add(Vector2.zero);

        maximoDeCorredores = Random.Range(3, 5);

        CriarCorredores();
    }
    void CriarCorredores()
    {       
        for (int i = 0; i < maximoDeCorredores; i++) //Repete para cada corredor
        {
            tamanhoDeCadaCorredor = Random.Range(4, 8);
            Vector2 posiçãoInicial = Vector2.zero;
            Vector2 posiçãoAtual = Vector2.zero;
            int indexDireção = i;
            int TamanhoAtualDoCorredor = 1;
            for (int j = 1; j <= tamanhoDeCadaCorredor; j++) //Para cada sala no corredor instancia com uma posição na direção inicial do corredor
            {
                print("TentativablocoColocado");
                if (TamanhoAtualDoCorredor>2&&Random.Range(1,10)>4)
                {
                    indexDireção = indexDireção + (Random.value < 0.5f ? -1 : 1);
                    

                    if (indexDireção > 3) { indexDireção = 0; }
                    if (indexDireção < 0) { indexDireção = 3; }


                    TamanhoAtualDoCorredor = 1;
                    posiçãoInicial = posiçãoAtual;
                }
                posiçãoAtual = posiçãoInicial + direçoes[indexDireção] * TamanhoAtualDoCorredor;
                if (!salasOcupadas.Contains(posiçãoAtual))
                {
                    Instantiate(cadaSala, posiçãoAtual, Quaternion.identity);
                    salasOcupadas.Add(posiçãoAtual); //Adiciona a posição atual na lista de posições ocupadas
                    print("blocoColocado");
                }            
                TamanhoAtualDoCorredor++;
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
