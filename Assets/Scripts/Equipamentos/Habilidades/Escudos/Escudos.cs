using UnityEngine;

public class Escudos : CadaHabilidade
{
    [SerializeField] Transform Jogador; //Jogador onde será instanciado o escudo
    [SerializeField] GameObject[] escudos; //Representa todas versão do escudo
    [SerializeField] DadosDaHabilidade daHabilidade;

    [SerializeField] GameObject escudoInst; //Obj que armazena o objeto que vai ser instanciado

    public override void UsarHabilidade(JogadorHabilidades jog)
    {
        
        Jogador = jog.gameObject.transform; //Pega o Transform do jogador para movimentar o escudo
        
        daHabilidade.recarregando = true; //Marca que a habilidade está recarregando

        if (nivel < escudos.Length)//Verifica se o nível é valido
        {
            if (escudos[nivel] != null && Jogador != null&& escudoInst==null) //Verifica se o escudo para aquele nível e o
                                                                              //jogador existem além de verificar se já não existe um escudo
            {
                escudoInst = Instantiate(escudos[nivel]); //Instancia o escudo e mantem uma referencia para ele
            }
        }
                   
    }
    void Update()
    {
        if (escudoInst != null)
        {
            escudoInst.transform.position = Jogador.transform.position;
            escudoInst.transform.Rotate(0, 0, 45 * Time.deltaTime);
            if (daHabilidade.TimerRecarga >= 3)
            {
                Destroy(escudoInst);
            }
        }
        if (daHabilidade != null) //Verifica se o objeto scripatvel existe
        {
            if (daHabilidade.recarregando) //Verifica se a habilidade está recarregando
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
    private void OnDestroy()
    {
        if (escudoInst)
        {
            Destroy(escudoInst.gameObject);
        }       
    }
}
