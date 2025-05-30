using UnityEngine;

public class Escudos : CadaHabilidade
{
    [SerializeField] Transform Jogador; //Jogador onde ser� instanciado o escudo
    [SerializeField] GameObject[] escudos; //Representa todas vers�o do escudo


    [SerializeField] GameObject escudoInst; //Obj que armazena o objeto que vai ser instanciado

    private void Awake()
    {
        index = 1;
    }
    public override void UsarHabilidade(JogadorHabilidades jog)
    {
        
        Jogador = jog.gameObject.transform; //Pega o Transform do jogador para movimentar o escudo
        
        daHabilidade.recarregando = true; //Marca que a habilidade est� recarregando

        if (nivel < escudos.Length)//Verifica se o n�vel � valido
        {
            if (escudos[nivel] != null && Jogador != null&& escudoInst==null) //Verifica se o escudo para aquele n�vel e o
                                                                              //jogador existem al�m de verificar se j� n�o existe um escudo
            {
                escudoInst = Instantiate(escudos[nivel]); //Instancia o escudo e mantem uma referencia para ele
            }
        }                
    }
    void Update()
    {
        if (escudoInst != null)
        {
            escudoInst.transform.position = Jogador.transform.position; //Faz com que o escudo instanciado se movimente para junto do jogador
            escudoInst.transform.Rotate(0, 0, 45 * Time.deltaTime); //Rotaciona ele

            if (daHabilidade.TimerRecarga >= 3) //Destroi o escudo depois de 3 segundos
            {
                Destroy(escudoInst);
            }
        }
        if (daHabilidade != null) //Verifica se o objeto scripatvel existe
        {
            if (daHabilidade.recarregando) //Verifica se a habilidade est� recarregando
            {
                daHabilidade.TimerRecarga += Time.deltaTime; //Aumenta o Timer
            }
            if (daHabilidade.TimerRecarga >= daHabilidade.CDrecarga) //Vefifica se o timer for menor que o CD
            {
                daHabilidade.recarregando = false; // libera utilizar novamente a habilidade
                daHabilidade.TimerRecarga = 0;
            }
        }      
    }
}
