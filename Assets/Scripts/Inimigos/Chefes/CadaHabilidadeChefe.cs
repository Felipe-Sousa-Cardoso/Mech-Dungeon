using Unity.Burst.Intrinsics;
using UnityEngine;

public class CadaHabilidadeChefe : MonoBehaviour, IDanificavel
{
    [SerializeField] int posi��o; //Cada uma das 5 possiveis posi��es da arma
    [SerializeField] Transform jogador;
    [SerializeField] Transform arma; //Trasform que contem o objeto da arma
    [SerializeField] float vida;

    Vector3 dire��o;

    public Transform Jogador { get => jogador; set => jogador = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (posi��o)
        {
            case 0: transform.localPosition = new Vector2(0.6f,0.6f); break;
            case 1: transform.localPosition = new Vector2(0.6f, -0.6f); break;
            case 2: transform.localPosition = new Vector2(-0.6f, -0.6f); break;
            case 3: transform.localPosition = new Vector2(-0.6f, 0.6f); break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Jogador)
        {
            dire��o = (Jogador.position - arma.transform.position).normalized; //Define e normaliza o vetor dire��o, como o final menos o inicial
            arma.transform.right = new Vector3( dire��o.x,dire��o.y,0); //Aponta a arma para o jogador
        }
        else
        {
            arma.transform.right = Vector3.right; 
        }

        
    }

  

    public void Danificar(float Quanto)
    {
        vida -= Quanto;
        if (vida <= 0)
        {
            Destroy(gameObject, 0.3f);
        }
    }
}
