using UnityEngine;

public class AcidoInstanciado : MonoBehaviour
{
    [SerializeField] Transform alvo;
    public float dano;
    float timer;

    public Transform Alvo
    {
        get { return alvo; }
        set { alvo = value; }
    } //Recebe o alvo que dacolis�o no qual ser� aplicado o dano do acido

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
    }



}
