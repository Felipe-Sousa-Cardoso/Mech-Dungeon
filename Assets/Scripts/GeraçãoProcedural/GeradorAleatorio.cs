
using System;
using System.Collections.Generic;
using UnityEngine;

public class GeradorAleatorio : MonoBehaviour
{
    [SerializeField] GameObject cadaSala; //Objeto de cada sala
    [SerializeField] int maximoDeCorredores;
    [SerializeField] int tamanhoDeCadaCorredor;
    List<Vector2> direçoes = new List<Vector2> { Vector2.right, Vector2.up, Vector2.left, Vector2.down };
    [SerializeField] List<Vector2> posiçõesOcupadas = new List<Vector2>();
    [SerializeField] List<(Vector2 , CadaSala)> salasOcupadas = new List<(Vector2 posição, CadaSala sala)>();


    void Start()
    {
        GameObject obj = Instantiate(cadaSala, Vector3.zero, Quaternion.identity); //Instancia a sala inicial e pinta ela de vermelho
        obj.GetComponent<SpriteRenderer>().color = Color.red;
        posiçõesOcupadas.Add(Vector2.zero);

        maximoDeCorredores = UnityEngine.Random.Range(3, 5);

        CriarCorredores();
        SetarVizinhos();
    }
    void CriarCorredores()
    {       
        for (int i = 0; i < maximoDeCorredores; i++) //Repete para cada corredor
        {
            tamanhoDeCadaCorredor = UnityEngine.Random.Range(6, 10);
            Vector2 posiçãoInicial = Vector2.zero;
            //define onde começa a ser intanciado a sala, é resetado em cada curva de cada corredor
            Vector2 posiçãoAtual = Vector2.zero;
            //É alterado para receber onde cada sala precisa ser instanciada
            int indexDireção = i;
            //São as 4 direções, as impares são verticais e pares as horizontais 

            int TamanhoAtualDoCorredor = 1;
            for (int j = 1; j <= tamanhoDeCadaCorredor; j++) //Para cada sala no corredor instancia com uma posição alterada 
            {
                if (TamanhoAtualDoCorredor>2&&UnityEngine.Random.Range(1,10)>2) //Curvas
                    //As curvas tem 70% de chance de ocorrer, e ocorrem quando o corredor tem pelo menos 2 blocos
                {
                    indexDireção = indexDireção + (UnityEngine.Random.value < 0.5f ? -1 : 1);
                    //Tem 50% de chance de alterar o indice em +1 ou -1, trocando a paridade, dessa forma se a direção inicial é a direita,
                    //pode alterar para cima e para baixo e assim por diante                  

                    if (indexDireção > 3) { indexDireção = 0; }
                    if (indexDireção < 0) { indexDireção = 3; }
                    //No caso da alteração exeder os limites do indice, corrige de forma que mantenha a paridade


                    TamanhoAtualDoCorredor = 1;                   
                    posiçãoInicial = posiçãoAtual;
                    //Faz com que o corredor coremeçe a ser gerado a partir da posição atual
                }
                posiçãoAtual = posiçãoInicial + direçoes[indexDireção] * TamanhoAtualDoCorredor;

                if (!posiçõesOcupadas.Contains(posiçãoAtual))
                {
                    GameObject obj = Instantiate(cadaSala, posiçãoAtual, Quaternion.identity);
                    posiçõesOcupadas.Add(posiçãoAtual); //Adiciona a posição atual na lista de posições ocupadas
                    CadaSala sala = obj.GetComponent<CadaSala>();
                    salasOcupadas.Add((posiçãoAtual, sala)); //Adiciona cada posição e sua respectitiva sala                 
                    if (sala)
                    {
                        sala.Posição = posiçãoAtual;
                    }                   
                }
                else { j--;} //caso a sala esteja ocupada repete essa iteração mais uma vez
                TamanhoAtualDoCorredor++;
            }         
        }
    }
    private void SetarVizinhos()
    {
        foreach ((Vector2, CadaSala) sala in salasOcupadas)
        //Percorre cada sala dentre as ocupadas
        {
            for (int i = 0; i <= 3; i++) //para cada uma das 4 direções
            {
                if (posiçõesOcupadas.Contains(sala.Item1 + direçoes[i])) //Verifica o vizinho para cada posições
                {
                    sala.Item2.Vizinhos[i] = true;
                }
            }
        }
    }
    public void EmbaralharLista<T>(List<T> lista) //embaralha a lista, serve para qualquer lista, é chamado externamente
    {
        for (int i = 0; i < lista.Count; i++)
        {
            int rand = UnityEngine.Random.Range(i, lista.Count);
            (lista[i], lista[rand]) = (lista[rand], lista[i]);
        }
    }
}
