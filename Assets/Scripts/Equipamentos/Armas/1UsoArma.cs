using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsoArma : MonoBehaviour
{
    public CadaArma Valores;
    protected float Cadencia;
    protected float Alcance;
    protected int Velocidade;
    protected float Precisão;
    protected int Pente;
    protected float Recarga;
    protected float Dano;
    protected float ModDanoQualidade;
    protected int MuniçõesPorDisparo;

    public void Qualidade()
    {
        switch (Valores.QualidadeDeManufatura)
        {
            case 0: ModDanoQualidade = 1; break; 
            case 1: ModDanoQualidade = 1.5f; break; 
            case 2: ModDanoQualidade = 2; break; 
            case 3: ModDanoQualidade = 3; break;
        }
    }
    public virtual void atirar(GameObject Tiro,Transform Arma, float modPrecisão)
    {
        for (int i = 0; i < MuniçõesPorDisparo; i++)
        {
            float anguloArma = Arma.eulerAngles.z; //Olha o angulo da arma
            float anguloFinal = anguloArma + Random.Range(-Precisão/modPrecisão, Precisão/modPrecisão); // Adiciona o valor da precis�o de cada arma, alterado pelo modificador global de dano
            float anguloEmRadianos = anguloFinal * Mathf.Deg2Rad; // Converte o ângulo final em radianos
            Vector2 direcaoTiro = new Vector2(Mathf.Cos(anguloEmRadianos), Mathf.Sin(anguloEmRadianos)); // Calcula a direção do tiro

            GameObject tiro = Instantiate(Tiro, Arma.position, Quaternion.identity); //Instancia o prefab o tiro na posição da arma com a rotação zerada

            tiro.transform.Rotate(new Vector3(0, 0, anguloFinal)); //Corrige a direção do sprite do tiro

            tiro.GetComponent<Rigidbody2D>().linearVelocity = direcaoTiro * Velocidade; // Aplica a direção ao proj�til
            tiro.GetComponent<Munição>().Dano = Dano;

            Destroy(tiro, Alcance / Velocidade); //Usa valocidade para determinar o alcance
        }
    }

    public virtual void UpdateArma(JogadorArma jog) 
    {
        jog.Tiro.GetComponent<Munição>().LimparEfeito(); //Chama o método que limpa o evento que executa os efeitos
        foreach (CadaMod mod in jog.Tiro.GetComponents<CadaMod>()) 
        {
            mod.enabled = false;
            mod.nivel = 0;
        }// zera e desliga as modificações da arma anterior
        foreach (Vector2Int i in Valores.Modificações) //Altera as modificações e o nivel para a arma atual,
                                                       //O x representa qual modificação e y o nível da modificação
        {
            switch (i.x)
            {
                case 1: Perseguir perseguir = jog.Tiro.GetComponent<Perseguir>(); perseguir.enabled = true; perseguir.nivel = i.y; break;
                case 2: Perfurar perfurar = jog.Tiro.GetComponent<Perfurar>(); perfurar.enabled = true; perfurar.nivel = i.y; break;
                case 3: Choque choque = jog.Tiro.GetComponent<Choque>(); Munição.OnEfeito += choque.choque; choque.nivel = i.y; break;
                case 4: Acido acido = jog.Tiro.GetComponent<Acido>(); Munição.OnEfeito += acido.acido;acido.nivel = i.y; break;
                case 5: Gelo gelo = jog.Tiro.GetComponent<Gelo>(); Munição.OnEfeito += gelo.gelo; gelo.nivel = i.y; break;
            }
        }        
    }
}
