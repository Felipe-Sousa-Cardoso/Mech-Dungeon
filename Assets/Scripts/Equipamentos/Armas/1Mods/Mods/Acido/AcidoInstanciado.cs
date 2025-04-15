using UnityEngine;
using static Danificavel;

public class AcidoInstanciado : MonoBehaviour
{
    ParticleSystem ps;
    [SerializeField] Transform alvo;
    [SerializeField] float dano;
    float timer;
    int stacks;
    IDanificavel obj;



    public Transform Alvo
    {
        get { return alvo; }
        set { alvo = value; }
    } //Recebe o alvo que da colisão no qual será aplicado o dano do acido
    public float Dano
    {
        get { return dano; }
        set { dano = value; }
    }//Adiciona o dano causado pelos disparos
    public int Stacks
    {
        get { return stacks; }
        set { stacks = value; }
    }//Verifica se o dano pode continuar escalando

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        transform.localPosition = new Vector3(0, 0, 0); //centraliza o objeto instanciado na posição do objeto pai
        if (alvo != null) 
        {
            obj = alvo.GetComponent<IDanificavel>(); //Acessa o componente que implemente a interface IDanificavel no alvo
        }
        
    }
    private void FixedUpdate()
    {      
        if (stacks > 0&&alvo!=null) //Verifica se existe algum stack para aplicar o ácido e se o alvo ainda não morreu
        {          
            timer += Time.deltaTime;
            if (timer >= 1f) //Ativa o veneno a cada 1 segundo
            {
                
                if (obj != null)
                {
                    obj.Danificar(dano / 2); //Causa a metade do dano que já foi causado do veneno
                    dano = stacks-1* dano / stacks; //reduz um pouco o dano total
                }              
                timer = 0;
                stacks--;                             
            }
        }
        Particula(Stacks * 4);

        if (alvo == null) //Quando o objeto pai é destruido desliga a emissão e espera 1 segundo para que todas as particulas desapareçam para destruir o objeto
        {
            Particula(0);
            Destroy(gameObject, 1f);
            
        }
    }
    public void Particula(int valor) //Atualiza o sistema de particulas
    {
        var emissao = ps.emission; 
        emissao.rateOverTime = valor;      
    }     
}
