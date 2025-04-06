using UnityEngine;

public class JogadorAtributos : MonoBehaviour
{
    bool armaAtiva = true; //Verifica se o jogador pode atirar
    #region Métodos de acesso
    public bool ArmaAtiva
    {
        get { return armaAtiva; }
        set { armaAtiva = value; }
    }
    #endregion
}
