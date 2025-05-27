using System.Collections.Generic;
using UnityEngine;

public class CadaCelulaMineMapa : MonoBehaviour
{
    [SerializeField] GameObject[] portas;
    List<bool> vizinhos;

    public List<bool> Vizinhos { get => vizinhos; set => vizinhos = value; }

    void Start()
    {
        int index = 0;
        foreach(GameObject porta in portas)
        {
            if (vizinhos != null)
            {
                if (!vizinhos[index])
                {
                    porta.SetActive(false);
                }
                index++;
            }          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
