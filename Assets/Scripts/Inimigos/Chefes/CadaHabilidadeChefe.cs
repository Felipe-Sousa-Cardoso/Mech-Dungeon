using Unity.Burst.Intrinsics;
using UnityEngine;

public class CadaHabilidadeChefe : MonoBehaviour, IDanificavel
{
    [SerializeField] int posição; //Cada uma das 5 possiveis posições da arma
    [SerializeField] Transform jogador;
    [SerializeField] Transform arma; //Trasform que contem o objeto da arma
    [SerializeField] float vida;

    Vector3 direção;

    public Transform Jogador { get => jogador; set => jogador = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (posição)
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
            direção = (Jogador.position - arma.transform.position).normalized; //Define e normaliza o vetor direção, como o final menos o inicial
            arma.transform.right = new Vector3( direção.x,direção.y,0); //Aponta a arma para o jogador
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
