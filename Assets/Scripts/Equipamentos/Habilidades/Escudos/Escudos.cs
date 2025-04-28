using UnityEngine;

public class Escudos : CadaHabilidade
{
    [SerializeField] Transform Jogador; //Jogador onde será instanciado o escudo
    [SerializeField] GameObject[] escudos; //Representa todas versão do escudo
    [SerializeField] DadosDaHabilidade daHabilidade;
    
    [SerializeField] int nivel;


    [SerializeField] GameObject escudoInst; //Obj que armazena o objeto que vai ser instanciado

    public int Nivel { get => nivel; set => nivel = value; }

    public override void UsarHabilidade(JogadorHabilidades jog)
    {
        
        print("UsouHabilidade");
        Jogador = jog.gameObject.transform;
        
        daHabilidade.recarregando = true;

        print(jog.DdHabilidades.CDrecarga);

        if (escudos[nivel] != null && Jogador != null)
        {
            escudoInst = Instantiate(escudos[nivel]);
        }            
    }
    void Update()
    {
        if (escudoInst != null)
        {
            escudoInst.transform.position = Jogador.transform.position;
            escudoInst.transform.Rotate(0, 0, 45 * Time.deltaTime);
        }
        if (daHabilidade != null) //Verifica se o objeto scripatvel existe
        {
            if (daHabilidade.recarregando) //Verifica se a habilidade está recarregando
            {
                daHabilidade.TimerRecarga += Time.deltaTime; //Aumenta o Timer
            }
            if (daHabilidade.TimerRecarga >= daHabilidade.CDrecarga) //Vefifica se o timer for menor que o CD
            {
                print("podeUsar");
                daHabilidade.recarregando = false; // libera utilizar novamente a habilidade
                daHabilidade.TimerRecarga = 0;
            }
        }
        
        
    }
}
