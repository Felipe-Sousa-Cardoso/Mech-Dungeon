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
    } //Recebe o alvo que dacolisão no qual será aplicado o dano do acido

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
    }



}
