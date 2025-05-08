using UnityEngine;
using UnityEngine.UI;

public class IconeDaHabilidade : MonoBehaviour
{
    [SerializeField] Image habilidade; //Icone da Habilidade atual

    [SerializeField] Image cobertura; //cobertura para o efeito de fill amount

    [SerializeField] DadosDaHabilidade daHabilidade; //Obeto com as informações da habilidade

    bool executando = true; //Serve para não chamar repetidas vezes a troca de cor da cobertura quando ela não estiver recarregando

    private void Start()
    {
        daHabilidade.sprite = null;
        daHabilidade.habilidade = 0;
    }
    private void Update()
    {
        if (daHabilidade.troca)
        {
            habilidade.sprite = daHabilidade.sprite; //Troca o srite para a habilidade atual
            daHabilidade.troca = !daHabilidade.troca; //Avisa que a troca terminou
        }
        
        switch (daHabilidade.habilidade)
        {
            case 1: habilidade.rectTransform.Rotate(0, 0, 40 * Time.deltaTime); break;
            case 2: break;
            case 3: break;
        }//Executa um efeito para cada tipo de habilidade

        if (daHabilidade.recarregando)
        {
            executando = true;
            if (daHabilidade.TimerRecarga < 0.05f) //Evita que as trocas de cores sejão em todos os frames
            {
                cobertura.color = new Vector4(0.5f, 0.5f, 0.5f, 0.6f);
            }
            
            cobertura.fillAmount = 1-( daHabilidade.TimerRecarga / daHabilidade.CDrecarga);
        }
        else //Quando não está recarregando apaga a cobertura
        {
            if (executando == true) 
            {
                cobertura.color = new Vector4(0.5f, 0.5f, 0.5f, 0f);
                executando = false;
            }
            
        }

    }
}
