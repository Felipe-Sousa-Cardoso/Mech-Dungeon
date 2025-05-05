using UnityEngine;

public class JogadorAtributos : MonoBehaviour, IDanificavel
{
    bool armaAtiva = true; //Verifica se o jogador pode atirar
    [SerializeField] float vida;
    #region Métodos de acesso
    public bool ArmaAtiva
    {
        get { return armaAtiva; }
        set { armaAtiva = value; }
    }
    #endregion
    public void AtivarArma()
    {
        armaAtiva = true;
    }

    public void Danificar(float Quanto)
    {
        vida -= Quanto;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    } 
}
