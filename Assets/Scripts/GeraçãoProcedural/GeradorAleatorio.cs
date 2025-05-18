
using System;
using System.Collections.Generic;
using UnityEngine;

public class GeradorAleatorio : MonoBehaviour
{
    [SerializeField] GameObject cadaSala; //Objeto de cada sala
    [SerializeField] int maximoDeCorredores;
    [SerializeField] int tamanhoDeCadaCorredor;
    List<Vector2> dire�oes = new List<Vector2> { Vector2.right, Vector2.up, Vector2.left, Vector2.down };
    [SerializeField] List<Vector2> posi��esOcupadas = new List<Vector2>();
    [SerializeField] List<(Vector2 , CadaSala)> salasOcupadas = new List<(Vector2 posi��o, CadaSala sala)>();


    void Start()
    {
        GameObject obj = Instantiate(cadaSala, Vector3.zero, Quaternion.identity); //Instancia a sala inicial e pinta ela de vermelho
        obj.GetComponent<SpriteRenderer>().color = Color.red;
        posi��esOcupadas.Add(Vector2.zero);

        maximoDeCorredores = UnityEngine.Random.Range(3, 5);

        CriarCorredores();
        SetarVizinhos();
    }
    void CriarCorredores()
    {       
        for (int i = 0; i < maximoDeCorredores; i++) //Repete para cada corredor
        {
            tamanhoDeCadaCorredor = UnityEngine.Random.Range(6, 10);
            Vector2 posi��oInicial = Vector2.zero;
            //define onde come�a a ser intanciado a sala, � resetado em cada curva de cada corredor
            Vector2 posi��oAtual = Vector2.zero;
            //� alterado para receber onde cada sala precisa ser instanciada
            int indexDire��o = i;
            //S�o as 4 dire��es, as impares s�o verticais e pares as horizontais 

            int TamanhoAtualDoCorredor = 1;
            for (int j = 1; j <= tamanhoDeCadaCorredor; j++) //Para cada sala no corredor instancia com uma posi��o alterada 
            {
                if (TamanhoAtualDoCorredor>2&&UnityEngine.Random.Range(1,10)>2) //Curvas
                    //As curvas tem 70% de chance de ocorrer, e ocorrem quando o corredor tem pelo menos 2 blocos
                {
                    indexDire��o = indexDire��o + (UnityEngine.Random.value < 0.5f ? -1 : 1);
                    //Tem 50% de chance de alterar o indice em +1 ou -1, trocando a paridade, dessa forma se a dire��o inicial � a direita,
                    //pode alterar para cima e para baixo e assim por diante                  

                    if (indexDire��o > 3) { indexDire��o = 0; }
                    if (indexDire��o < 0) { indexDire��o = 3; }
                    //No caso da altera��o exeder os limites do indice, corrige de forma que mantenha a paridade


                    TamanhoAtualDoCorredor = 1;                   
                    posi��oInicial = posi��oAtual;
                    //Faz com que o corredor coreme�e a ser gerado a partir da posi��o atual
                }
                posi��oAtual = posi��oInicial + dire�oes[indexDire��o] * TamanhoAtualDoCorredor;

                if (!posi��esOcupadas.Contains(posi��oAtual))
                {
                    GameObject obj = Instantiate(cadaSala, posi��oAtual, Quaternion.identity);
                    posi��esOcupadas.Add(posi��oAtual); //Adiciona a posi��o atual na lista de posi��es ocupadas
                    CadaSala sala = obj.GetComponent<CadaSala>();
                    salasOcupadas.Add((posi��oAtual, sala)); //Adiciona cada posi��o e sua respectitiva sala                 
                    if (sala)
                    {
                        sala.Posi��o = posi��oAtual;
                    }                   
                }
                else { j--;} //caso a sala esteja ocupada repete essa itera��o mais uma vez
                TamanhoAtualDoCorredor++;
            }         
        }
    }
    private void SetarVizinhos()
    {
        foreach ((Vector2, CadaSala) sala in salasOcupadas)
        //Percorre cada sala dentre as ocupadas
        {
            for (int i = 0; i <= 3; i++) //para cada uma das 4 dire��es
            {
                if (posi��esOcupadas.Contains(sala.Item1 + dire�oes[i])) //Verifica o vizinho para cada posi��es
                {
                    sala.Item2.Vizinhos[i] = true;
                }
            }
        }
    }
    public void EmbaralharLista<T>(List<T> lista) //embaralha a lista, serve para qualquer lista, � chamado externamente
    {
        for (int i = 0; i < lista.Count; i++)
        {
            int rand = UnityEngine.Random.Range(i, lista.Count);
            (lista[i], lista[rand]) = (lista[rand], lista[i]);
        }
    }
}
