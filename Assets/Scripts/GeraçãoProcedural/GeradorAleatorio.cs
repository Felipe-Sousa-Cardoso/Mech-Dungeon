using System.Collections.Generic;
using UnityEngine;

public class GeradorAleatorio : MonoBehaviour
{
    [SerializeField] GameObject cadaSala; //Objeto de cada sala
    [SerializeField] int maximoDeCorredores;
    [SerializeField] int tamanhoDeCadaCorredor;
    List<Vector2> dire�oes = new List<Vector2> { Vector2.right, Vector2.up, Vector2.left, Vector2.down };
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
            Vector2 posi��oInicial = Vector2.zero;
            Vector2 posi��oAtual = Vector2.zero;
            int indexDire��o = i;
            int TamanhoAtualDoCorredor = 1;
            for (int j = 1; j <= tamanhoDeCadaCorredor; j++) //Para cada sala no corredor instancia com uma posi��o na dire��o inicial do corredor
            {
                print("TentativablocoColocado");
                if (TamanhoAtualDoCorredor>2&&Random.Range(1,10)>4)
                {
                    indexDire��o = indexDire��o + (Random.value < 0.5f ? -1 : 1);
                    

                    if (indexDire��o > 3) { indexDire��o = 0; }
                    if (indexDire��o < 0) { indexDire��o = 3; }


                    TamanhoAtualDoCorredor = 1;
                    posi��oInicial = posi��oAtual;
                }
                posi��oAtual = posi��oInicial + dire�oes[indexDire��o] * TamanhoAtualDoCorredor;
                if (!salasOcupadas.Contains(posi��oAtual))
                {
                    Instantiate(cadaSala, posi��oAtual, Quaternion.identity);
                    salasOcupadas.Add(posi��oAtual); //Adiciona a posi��o atual na lista de posi��es ocupadas
                    print("blocoColocado");
                }            
                TamanhoAtualDoCorredor++;
            }         
        }
    }
    public void EmbaralharLista<T>(List<T> lista) //embaralha a lista, serve para qualquer lista, � chamado externamente
    {
        for (int i = 0; i < lista.Count; i++)
        {
            int rand = Random.Range(i, lista.Count);
            (lista[i], lista[rand]) = (lista[rand], lista[i]);
        }
    }
}
