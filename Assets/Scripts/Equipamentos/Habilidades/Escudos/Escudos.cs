using UnityEngine;

public class Escudos : CadaHabilidade
{
    [SerializeField] Transform Jogador; //Jogador onde será instanciado o escudo
    [SerializeField] GameObject obj0; //Representa a primeira versão do escudo
    [SerializeField] GameObject obj1; //Representa a segunda versão do escudo
    [SerializeField] int forçaDeEscudo; //Durabilidade do Escudo
    GameObject escudoInst; //Obj que armazena o objeto que vai ser instanciado
    public override void UsarHabilidade(JogadorHabilidades jog)
    {  
        Jogador = jog.gameObject.transform;
        if (obj0 != null && Jogador != null)
        {
            escudoInst = Instantiate(obj0);
            escudoInst.GetComponent<EscudosInstanciados>().ForcaDoEscudo = forçaDeEscudo;
        }        
    }
    void Update()
    {
        if (escudoInst != null)
        {
            escudoInst.transform.position = Jogador.transform.position;
            escudoInst.transform.Rotate(0, 0, 30 * Time.deltaTime);
        }
        
    }
}
