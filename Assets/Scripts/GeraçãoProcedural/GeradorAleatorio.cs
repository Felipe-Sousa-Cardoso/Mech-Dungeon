using System.Collections.Generic;
using UnityEngine;

public class GeradorAleatorio : MonoBehaviour
{
    [SerializeField] GameObject cadaSala; //Objeto de cada sala
    [SerializeField] List<GameObject> interiores;
    [SerializeField] List<GameObject> SalasDeItem;
    [SerializeField] List<GameObject> SalasDeBoss;

    [SerializeField] int maximoDeCorredores;
    [SerializeField] int tamanhoDeCadaCorredor;
    List<Vector2> dire�oes = new List<Vector2> { new Vector2 (17f,0), new Vector2(0, 11f), new Vector2(-17f, 0), new Vector2(0, -11)};
    [SerializeField] List<Vector2> posi��esOcupadas = new List<Vector2>();
    [SerializeField] List<(Vector2 , CadaSala)> salasOcupadas = new List<(Vector2 posi��o, CadaSala sala)>();
    [SerializeField] List<Vector2> posi��esOcupadasEspeciais = new List<Vector2>();
    [SerializeField] List<(Vector2, CadaSala)> salasOcupadasEspeciais = new List<(Vector2 posi��o, CadaSala sala)>();

    [SerializeField] Transform Grid;
    [SerializeField] Vector2 posi��oAtual;

    [SerializeField] ControladorDeMinimapa mineMapa;

    public Vector2 Posi��oAtual { get => posi��oAtual; set => posi��oAtual = value;}
    public List<Vector2> Dire�oes { get => dire�oes; set => dire�oes = value;}
    public ControladorDeMinimapa MineMapa { get => mineMapa; set => mineMapa = value; }

    void Start()
    {
        MineMapa = ControladorDeMinimapa.instance;
        ResetarPosi��o();
        CriarPrimeiraSala();       
        CriarCorredores();
        SetarVizinhos();
        CriarSalaDeItens();
        CriarSalaDeChefe();
        SetarVizinhos();
      
    }
    private void Update()
    {
        if (MineMapa == null)
        {
            MineMapa = FindAnyObjectByType<ControladorDeMinimapa>();
        }
    }
    void ResetarPosi��o()
    {
        posi��oAtual = Vector3.zero;
    }
    void CriarPrimeiraSala()
    {
        GameObject obj = Instantiate(cadaSala, Vector3.zero, Quaternion.identity,Grid);
       // MineMapa.AumentarMiniMapa(Vector3.zero, 0);
        posi��esOcupadas.Add(Vector2.zero);
        CadaSala sala = obj.GetComponent<CadaSala>();
        salasOcupadas.Add((Vector2.zero, sala));
        sala.Posi��o = posi��oAtual;
        sala.Gerador = this;
        if (interiores[0])
        {
            sala.Interior = interiores[0];
        }
    }
    void CriarCorredores()
    {
        maximoDeCorredores = UnityEngine.Random.Range(3, 5);
        for (int i = 0; i < maximoDeCorredores; i++) //Repete para cada corredor
        {
            tamanhoDeCadaCorredor = UnityEngine.Random.Range(3, 6);
            Vector2 posi��oInicial = Vector2.zero;
            //define onde come�a a ser intanciado a sala, � resetado em cada curva de cada corredor
            Vector2 posi��oAtual = Vector2.zero;
            //� alterado para receber onde cada sala precisa ser instanciada
            int indexDire��o = i;
            //S�o as 4 dire��es, as impares s�o verticais e pares as horizontais 

            int TamanhoAtualDoCorredor = 1;
            for (int j = 1; j <= tamanhoDeCadaCorredor; j++) //Para cada sala no corredor instancia com uma posi��o alterada 
            {
                if (TamanhoAtualDoCorredor>2&&UnityEngine.Random.Range(1,10)>3) //Curvas
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
                posi��oAtual = posi��oInicial + Dire�oes[indexDire��o] * TamanhoAtualDoCorredor;

                if (!posi��esOcupadas.Contains(posi��oAtual))
                {
                    float k = UnityEngine.Random.value; //Serve apenas para aumentar a aleatoriedade do randow abaixo

                    GameObject obj = Instantiate(cadaSala, posi��oAtual, Quaternion.identity,Grid);
                    posi��esOcupadas.Add(posi��oAtual); //Adiciona a posi��o atual na lista de posi��es ocupadas
                    CadaSala sala = obj.GetComponent<CadaSala>();
                    salasOcupadas.Add((posi��oAtual, sala)); //Adiciona cada posi��o e sua respectitiva sala                 
                    if (sala)
                    {
                        sala.Posi��o = posi��oAtual;
                        sala.Gerador = this;
                        int y = UnityEngine.Random.Range(1, interiores.Count);
                        if (interiores[y])
                        {
                            sala.Interior = interiores[y];
                        }                       
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
                if (posi��esOcupadas.Contains(sala.Item1 + Dire�oes[i])) //Verifica o vizinho para cada posi��es
                {
                    sala.Item2.Vizinhos[i] = true;
                }
            }
        }
    }
    private void CriarSalaDeItens()
    {
        int indexDaSalaNormal = UnityEngine.Random.Range(1, salasOcupadas.Count);
        int indexDosVizinhos = 0;
        CadaSala salaNormal;
        List<Vector2> vizinhosVagos = new List<Vector2>();
        
        salaNormal = salasOcupadas[indexDaSalaNormal].Item2;
        
        foreach(bool vizinho in salaNormal.Vizinhos)
        {
            if (!vizinho)
            {
                vizinhosVagos.Add(Dire�oes[indexDosVizinhos]);
               
            }
            indexDosVizinhos++;
        }
        Vector2 posi��oDaSala = salasOcupadas[indexDaSalaNormal].Item1 + vizinhosVagos[UnityEngine.Random.Range(0, vizinhosVagos.Count)];

        GameObject obj = Instantiate(cadaSala, posi��oDaSala, Quaternion.identity, Grid);
        posi��esOcupadas.Add(posi��oDaSala); //Adiciona a posi��o atual na lista de posi��es ocupadas
        posi��esOcupadasEspeciais.Add(posi��oDaSala);

        CadaSala salaDeItem = obj.GetComponent<CadaSala>();
        salasOcupadas.Add((posi��oDaSala, salaDeItem)); //Adiciona cada posi��o e sua respectitiva sala     
        salasOcupadasEspeciais.Add((posi��oDaSala, salaDeItem));

        if (salaDeItem)
        {
            salaDeItem.Posi��o = posi��oDaSala;
            salaDeItem.Gerador = this;
            salaDeItem.TipoDeSala = 1;
            int y = UnityEngine.Random.Range(0, SalasDeItem.Count);
            if (SalasDeItem[y])
            {
                salaDeItem.Interior = SalasDeItem[y];
            }
        }
    }
    private void CriarSalaDeChefe()
    {
        int indexDaSalaNormal = UnityEngine.Random.Range(1, salasOcupadas.Count); //Seleciona uma sala aleat�ria, para o caso de n�o ser encontrada nenhuma sala possivel
        float distanciaMaxima = 0;
        int index = 0;
        List<int> poss�veisIndex = new List<int>();

        foreach (Vector2 posi��o in posi��esOcupadas) 
        {
            float distancia = Vector2.Distance(posi��o, Vector2.zero);
            if (distancia == distanciaMaxima && !posi��esOcupadasEspeciais.Contains(posi��o))
            {
                poss�veisIndex.Add(index);
            }
            if ( distancia > distanciaMaxima&&!posi��esOcupadasEspeciais.Contains(posi��o))
            {
                distanciaMaxima = distancia;
                poss�veisIndex.Clear();
                poss�veisIndex.Add(index);
            }          
            index++;
        }
        indexDaSalaNormal = poss�veisIndex[UnityEngine.Random.Range(0, poss�veisIndex.Count)];
        int indexDosVizinhos = 0;
        CadaSala salaNormal;
        List<Vector2> vizinhosVagos = new List<Vector2>();

        salaNormal = salasOcupadas[indexDaSalaNormal].Item2;

        foreach (bool vizinho in salaNormal.Vizinhos)
        {
            if (!vizinho)
            {
                vizinhosVagos.Add(Dire�oes[indexDosVizinhos]);

            }
            indexDosVizinhos++;
        }
        Vector2 posi��oDaSala = salasOcupadas[indexDaSalaNormal].Item1 + vizinhosVagos[UnityEngine.Random.Range(0, vizinhosVagos.Count)];

        GameObject obj = Instantiate(cadaSala, posi��oDaSala, Quaternion.identity, Grid);
        posi��esOcupadas.Add(posi��oDaSala); //Adiciona a posi��o atual na lista de posi��es ocupadas
        posi��esOcupadasEspeciais.Add(posi��oDaSala);

        CadaSala salaDeChefe = obj.GetComponent<CadaSala>();
        salasOcupadas.Add((posi��oDaSala, salaDeChefe)); //Adiciona cada posi��o e sua respectitiva sala     
        salasOcupadasEspeciais.Add((posi��oDaSala, salaDeChefe));

        if (salaDeChefe)
        {
            salaDeChefe.Posi��o = posi��oDaSala;
            salaDeChefe.Gerador = this;
            salaDeChefe.TipoDeSala = 2;
            int y = UnityEngine.Random.Range(0, SalasDeBoss.Count);
            if (SalasDeBoss[y])
            {
                salaDeChefe.Interior = SalasDeBoss[y];
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
