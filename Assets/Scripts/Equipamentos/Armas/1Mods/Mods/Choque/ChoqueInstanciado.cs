using UnityEngine;

public class ChoqueInstanciado : MonoBehaviour
{
    [SerializeField] Transform alvo1;
    [SerializeField] Transform alvo2;
    [SerializeField] LineRenderer ln;
    [SerializeField] Texture[] texturas = new Texture[4];
    int indexTextura;
    float timer;
    public float dano; //dano do disparo

    private void Start()
    {
        ln = GetComponent<LineRenderer>();
    }
    public Transform Alvo1
    {
        get { return alvo1; }
        set { alvo1 = value; }
    }//Metodo de acesso usado para registrar o primeiro alvo da colisão
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (alvo1 != null)
        {
            if (collision.gameObject.tag == "Inimigo")
            {
                if (collision.transform != alvo1 && alvo2 == null) //escolhe o primeiro alvo como inimigo
                {
                    alvo2 = collision.transform;
                    choque();
                }
                if (collision.transform != alvo1 && //continua verificando se a colisão não é o primeiro alvo
                    Vector2.Distance(alvo1.position, alvo2.position) //calcula a distancia entre o primeiro alvo e o alvo atual
                    > Vector2.Distance(alvo1.position, collision.transform.position//se essa distancia for maior que a nova colisão substitue o alvo atual,
                                                                                   //focando assim o mais proximo
                    ))
                {
                    alvo2 = collision.transform;
                    choque();

                }
            }
        }
        
    } //colisão e detecção do alvo mais proximo
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.05)
        {     
            if (indexTextura < 3)
            {              
                indexTextura++;
            }
            else
            {
                if (alvo2 != null)
                {
                    GameObject objeto = alvo2.gameObject;
                    objeto.GetComponent<IDanificavel>().Danificar(dano / 2);
                    
                }
                Destroy(gameObject);

            }
            ln.material.SetTexture("_MainTex", texturas[indexTextura]);
            timer = 0;
        }
        if (alvo1 == null)
        {
            Destroy(gameObject);
        }
        
    }

    void choque()
    {
        if (alvo1 != null & alvo2 != null)
        {
            ln.SetPosition(0, alvo1.position);
            ln.SetPosition(1, alvo2.position);
        }      
    }
}
