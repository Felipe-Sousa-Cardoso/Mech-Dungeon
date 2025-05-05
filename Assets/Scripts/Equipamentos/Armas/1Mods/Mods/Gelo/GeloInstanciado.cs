using UnityEngine;

public class GeloInstanciado : MonoBehaviour
{
    [SerializeField] float stacks;
    [SerializeField] Transform alvo;
    [SerializeField] float timer;
    ParticleSystem ps;
    [SerializeField] BaseInimigos obj;

    public float Stacks
    {
        get { return stacks; }
        set { stacks = value; }
    }
    public Transform Alvo
    {
        get { return alvo; }
        set { alvo = value; }
    }
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        if (alvo != null)
        {
            obj = alvo.GetComponent<BaseInimigos>(); //Acessa o componente base dos inimigos
        }
       
        transform.localPosition = new Vector3(0, 0, 0); //centraliza o objeto instanciado na posição do objeto pai
    }
    private void FixedUpdate()
    {
        if (stacks > 0 && alvo != null) //Verifica se existe algum stack para aplicar o gelo e se o alvo ainda não morreu
        {
            
            if(obj != null)
            {
                obj.ModificadorDeVelocidade = 1-(stacks/8); //Acessa o modificador geral de velocidade do inimigo
            }

            timer += Time.deltaTime;
            if (timer >= 2f) //reduz a quantidade de gelo a cada 2s
            {              
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
    public void Particula(float valor) //Atualiza o sistema de particulas
    {
        var emissao = ps.emission;
        emissao.rateOverTime = valor;
    }
}
