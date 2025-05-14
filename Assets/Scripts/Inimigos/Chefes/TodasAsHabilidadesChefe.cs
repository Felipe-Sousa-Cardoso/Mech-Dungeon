using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class TodasAsHabilidadesChefe : MonoBehaviour
{
    [SerializeField] Transform chefe;

    List<int> numeros = new List<int> { 0,1,2,3 };


    [SerializeField] List<CadaHabilidadeChefe> todasAsHabilidades = new List<CadaHabilidadeChefe>();//Lista que gaurda todas as habilidades que foram
    //instanciadas e ainda n foram destruidas

    [SerializeField] CadaHabilidadeChefe prefab; //Guarda o prefab de cada habilidade

    public List<CadaHabilidadeChefe> TodasAsHabilidades { get => todasAsHabilidades; set => todasAsHabilidades = value; }

    [SerializeField] float indexHabilidadeSec;

    private void Start()
    {
        AdicionarHabilidades();
    }

    [System.Obsolete]
    void Update()
    {
        if (chefe) 
        {
            transform.position = chefe.position;
        }//Se o chefe existe segue ele, se ele já tiver sido destruido também destroi esse objeto
        else
        {
            Destroy(gameObject);
        }

        if (indexHabilidadeSec>5) //Faz com que uma habilidade aleatória dentre as instanciadas seja ativada a cada 5s
        {
            indexHabilidadeSec = 0;
            if (todasAsHabilidades.Count>0)
            {
                EmbaralharLista<CadaHabilidadeChefe>(todasAsHabilidades);
                if (TodasAsHabilidades[0])
                {
                    TodasAsHabilidades[0].Ativar();
                }
            }
        }
        else
        {
            indexHabilidadeSec += Time.deltaTime;
        }
        
    }
    private void AdicionarHabilidades()
    {
        EmbaralharLista(numeros);
        int i = Random.Range(1, 5); //Cria um inteiro entre 1 e 4
        for (int j = 0; j < i; j++)
        {

            CadaHabilidadeChefe obj = Instantiate(prefab,this.transform);//instancia cada prefab como um filho do trasform dessa classe

            obj.Posição = numeros[j];//define a posição para uma posição aleatória e sem repetição
        }
    }
    void EmbaralharLista<T>(List<T> lista) //embaralha a lista, serve para qualquer lista
    {
        for (int i = 0; i < lista.Count; i++)
        {
            int rand = Random.Range(i, lista.Count);
            (lista[i], lista[rand]) = (lista[rand], lista[i]);
        }
    }

}
