using UnityEngine;
using static Danificavel;

public class AcidoInstanciado : MonoBehaviour
{
    public ParticleSystem ps;
    [SerializeField] Transform alvo;
    float dano;
    float timer;
    int stacks;
    

    public Transform Alvo
    {
        get { return alvo; }
        set { alvo = value; }
    } //Recebe o alvo que da colisão no qual será aplicado o dano do acido
    public float Dano
    {
        get { return dano; }
        set { dano = value; }
    }
    public int Stacks
    {
        get { return stacks; }
        set { stacks = value; }
    }

    private void FixedUpdate()
    {
        
        if (stacks > 0&&alvo!=null)
        {          
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                GetComponentInParent<IDanificavel>().Danificar(dano / 2);
                timer = 0;
                stacks--;                             
            }
        }
        Particula(Stacks * 4);
        if (alvo == null)
        {
            Particula(0);
            Destroy(gameObject, 1f);
            
        }
    }

    public void Particula(int sim)
    {
        var emissao = ps.emission;
        emissao.rateOverTime = sim;
       
    }


    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        transform.localPosition = new Vector3(0, 0, 0);
    }



}
