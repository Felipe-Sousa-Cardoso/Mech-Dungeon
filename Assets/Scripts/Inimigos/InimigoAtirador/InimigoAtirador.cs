using UnityEngine;

public class InimigoAtirador : BaseInimigos
{
    [SerializeField] Transform Arma; //Arma, usada para controlar a posiçao e intanciar as munições
    [SerializeField] Transform Jogador;
    Vector3 direção; //A direção que o jogador está

    private void Update()
    {
        direção = Jogador.position - transform.position; //Define o vetor direção, como o final menos o inicial

        Debug.DrawRay(Arma.position, direção, Color.green);

        Arma.transform.localPosition = direção.normalized*0.3f; //Normaliza o etor direção e aponta para o jogador à uma distancia de 0.3

        Arma.transform.right = direção; //Aponta a arma para o jogador
    }
}
