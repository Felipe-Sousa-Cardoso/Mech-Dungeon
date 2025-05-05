using UnityEngine;

public class InimigoAtirador : BaseInimigos
{
    [SerializeField] Transform Arma; //Arma, usada para controlar a posi�ao e intanciar as muni��es
    [SerializeField] Transform Jogador;
    Vector3 dire��o; //A dire��o que o jogador est�

    private void Update()
    {
        dire��o = Jogador.position - transform.position; //Define o vetor dire��o, como o final menos o inicial

        Debug.DrawRay(Arma.position, dire��o, Color.green);

        Arma.transform.localPosition = dire��o.normalized*0.3f; //Normaliza o etor dire��o e aponta para o jogador � uma distancia de 0.3

        Arma.transform.right = dire��o; //Aponta a arma para o jogador
    }
}
