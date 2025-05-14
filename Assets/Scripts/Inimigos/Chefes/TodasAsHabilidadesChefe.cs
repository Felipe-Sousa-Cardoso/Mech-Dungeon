using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class TodasAsHabilidadesChefe : MonoBehaviour
{
    [SerializeField] Transform chefe;
    [SerializeField] List<CadaHabilidadeChefe> todasAsHabilidades = new List<CadaHabilidadeChefe>();

    public List<CadaHabilidadeChefe> TodasAsHabilidades { get => todasAsHabilidades; set => todasAsHabilidades = value; }

    [SerializeField] float indexHabilidadeSec;

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (chefe)
        {
            transform.position = chefe.position;
        }
        else
        {
            Destroy(gameObject);
        }

        if (indexHabilidadeSec>5)
        {
            indexHabilidadeSec = 0;
            if (todasAsHabilidades.Count>0)
            {
                EmbaralharArray<CadaHabilidadeChefe>(todasAsHabilidades);
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

    void EmbaralharArray<T>(List<T> lista) //embaralha a lista, serve para qualquer array, é chamado externamente
    {
        for (int i = 0; i < lista.Count; i++)
        {
            int rand = Random.Range(i, lista.Count);
            (lista[i], lista[rand]) = (lista[rand], lista[i]);
        }
    }
}
