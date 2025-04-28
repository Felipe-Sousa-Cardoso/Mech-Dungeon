using UnityEngine;

public class CadaHabilidade : MonoBehaviour
{
    [SerializeField] protected string nome;

    [SerializeField] protected float recarga = 5; //Tempo de recarga
    [SerializeField] protected float duracao = 3; //Duração máxima do escudo


    public float Recarga { get => recarga; set => recarga = value; }
    public float Duracao { get => duracao; set => duracao = value; }

    public virtual void UsarHabilidade(JogadorHabilidades jog)
    {
        
    }
}
