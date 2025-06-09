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
    List<Vector2> direçoes = new List<Vector2> { new Vector2 (17f,0), new Vector2(0, 11f), new Vector2(-17f, 0), new Vector2(0, -11)};
    [SerializeField] List<Vector2> posiçõesOcupadas = new List<Vector2>();
    [SerializeField] List<(Vector2 , CadaSala)> salasOcupadas = new List<(Vector2 posição, CadaSala sala)>();
    [SerializeField] List<Vector2> posiçõesOcupadasEspeciais = new List<Vector2>();
    [SerializeField] List<(Vector2, CadaSala)> salasOcupadasEspeciais = new List<(Vector2 posição, CadaSala sala)>();

    [SerializeField] Transform Grid;
    [SerializeField] Vector2 posiçãoAtual;

    [SerializeField] ControladorDeMinimapa mineMapa;

    public Vector2 PosiçãoAtual { get => posiçãoAtual; set => posiçãoAtual = value;}
    public List<Vector2> Direçoes { get => direçoes; set => direçoes = value;}
    public ControladorDeMinimapa MineMapa { get => mineMapa; set => mineMapa = value; }

    void Start()
    {
        MineMapa = ControladorDeMinimapa.instance;
        ResetarPosição();
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
    void ResetarPosição()
    {
        posiçãoAtual = Vector3.zero;
    }
    void CriarPrimeiraSala()
    {
        GameObject obj = Instantiate(cadaSala, Vector3.zero, Quaternion.identity,Grid);
       // MineMapa.AumentarMiniMapa(Vector3.zero, 0);
        posiçõesOcupadas.Add(Vector2.zero);
        CadaSala sala = obj.GetComponent<CadaSala>();
        salasOcupadas.Add((Vector2.zero, sala));
        sala.Posição = posiçãoAtual;
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
            Vector2 posiçãoInicial = Vector2.zero;
            //define onde começa a ser intanciado a sala, é resetado em cada curva de cada corredor
            Vector2 posiçãoAtual = Vector2.zero;
            //É alterado para receber onde cada sala precisa ser instanciada
            int indexDireção = i;
            //São as 4 direções, as impares são verticais e pares as horizontais 

            int TamanhoAtualDoCorredor = 1;
            for (int j = 1; j <= tamanhoDeCadaCorredor; j++) //Para cada sala no corredor instancia com uma posição alterada 
            {
                if (TamanhoAtualDoCorredor>2&&UnityEngine.Random.Range(1,10)>3) //Curvas
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
                posiçãoAtual = posiçãoInicial + Direçoes[indexDireção] * TamanhoAtualDoCorredor;

                if (!posiçõesOcupadas.Contains(posiçãoAtual))
                {
                    float k = UnityEngine.Random.value; //Serve apenas para aumentar a aleatoriedade do randow abaixo

                    GameObject obj = Instantiate(cadaSala, posiçãoAtual, Quaternion.identity,Grid);
                    posiçõesOcupadas.Add(posiçãoAtual); //Adiciona a posição atual na lista de posições ocupadas
                    CadaSala sala = obj.GetComponent<CadaSala>();
                    salasOcupadas.Add((posiçãoAtual, sala)); //Adiciona cada posição e sua respectitiva sala                 
                    if (sala)
                    {
                        sala.Posição = posiçãoAtual;
                        sala.Gerador = this;
                        int y = UnityEngine.Random.Range(1, interiores.Count);
                        if (interiores[y])
                        {
                            sala.Interior = interiores[y];
                        }                       
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
                if (posiçõesOcupadas.Contains(sala.Item1 + Direçoes[i])) //Verifica o vizinho para cada posições
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
                vizinhosVagos.Add(Direçoes[indexDosVizinhos]);
               
            }
            indexDosVizinhos++;
        }
        Vector2 posiçãoDaSala = salasOcupadas[indexDaSalaNormal].Item1 + vizinhosVagos[UnityEngine.Random.Range(0, vizinhosVagos.Count)];

        GameObject obj = Instantiate(cadaSala, posiçãoDaSala, Quaternion.identity, Grid);
        posiçõesOcupadas.Add(posiçãoDaSala); //Adiciona a posição atual na lista de posições ocupadas
        posiçõesOcupadasEspeciais.Add(posiçãoDaSala);

        CadaSala salaDeItem = obj.GetComponent<CadaSala>();
        salasOcupadas.Add((posiçãoDaSala, salaDeItem)); //Adiciona cada posição e sua respectitiva sala     
        salasOcupadasEspeciais.Add((posiçãoDaSala, salaDeItem));

        if (salaDeItem)
        {
            salaDeItem.Posição = posiçãoDaSala;
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
        int indexDaSalaNormal = UnityEngine.Random.Range(1, salasOcupadas.Count); //Seleciona uma sala aleatória, para o caso de não ser encontrada nenhuma sala possivel
        float distanciaMaxima = 0;
        int index = 0;
        List<int> possíveisIndex = new List<int>();

        foreach (Vector2 posição in posiçõesOcupadas) 
        {
            float distancia = Vector2.Distance(posição, Vector2.zero);
            if (distancia == distanciaMaxima && !posiçõesOcupadasEspeciais.Contains(posição))
            {
                possíveisIndex.Add(index);
            }
            if ( distancia > distanciaMaxima&&!posiçõesOcupadasEspeciais.Contains(posição))
            {
                distanciaMaxima = distancia;
                possíveisIndex.Clear();
                possíveisIndex.Add(index);
            }          
            index++;
        }
        indexDaSalaNormal = possíveisIndex[UnityEngine.Random.Range(0, possíveisIndex.Count)];
        int indexDosVizinhos = 0;
        CadaSala salaNormal;
        List<Vector2> vizinhosVagos = new List<Vector2>();

        salaNormal = salasOcupadas[indexDaSalaNormal].Item2;

        foreach (bool vizinho in salaNormal.Vizinhos)
        {
            if (!vizinho)
            {
                vizinhosVagos.Add(Direçoes[indexDosVizinhos]);

            }
            indexDosVizinhos++;
        }
        Vector2 posiçãoDaSala = salasOcupadas[indexDaSalaNormal].Item1 + vizinhosVagos[UnityEngine.Random.Range(0, vizinhosVagos.Count)];

        GameObject obj = Instantiate(cadaSala, posiçãoDaSala, Quaternion.identity, Grid);
        posiçõesOcupadas.Add(posiçãoDaSala); //Adiciona a posição atual na lista de posições ocupadas
        posiçõesOcupadasEspeciais.Add(posiçãoDaSala);

        CadaSala salaDeChefe = obj.GetComponent<CadaSala>();
        salasOcupadas.Add((posiçãoDaSala, salaDeChefe)); //Adiciona cada posição e sua respectitiva sala     
        salasOcupadasEspeciais.Add((posiçãoDaSala, salaDeChefe));

        if (salaDeChefe)
        {
            salaDeChefe.Posição = posiçãoDaSala;
            salaDeChefe.Gerador = this;
            salaDeChefe.TipoDeSala = 2;
            int y = UnityEngine.Random.Range(0, SalasDeBoss.Count);
            if (SalasDeBoss[y])
            {
                salaDeChefe.Interior = SalasDeBoss[y];
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
