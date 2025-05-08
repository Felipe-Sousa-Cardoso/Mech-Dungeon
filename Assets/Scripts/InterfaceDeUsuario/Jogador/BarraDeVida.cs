using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField] Image barraDeVida;
    [SerializeField] Text texto;
    [SerializeField] DadosDoJogador dados;

    float alvo;

    // Update is called once per frame
    void Update()
    {

        float alvo = dados.Vida / dados.MaxVida;
        //Define a escala alvo como a porporção entre a vida atual e a vida maxima
        Vector3 escalaAtual = barraDeVida.rectTransform.localScale;

        float novoX = Mathf.MoveTowards(escalaAtual.x, alvo, Time.deltaTime * 1);
        //Altera lentamente a escala para se aproximar do alvo

        barraDeVida.rectTransform.localScale = new Vector3(novoX, escalaAtual.y, escalaAtual.z);

        texto.text = dados.Vida + "/" + dados.MaxVida;
    }

}
