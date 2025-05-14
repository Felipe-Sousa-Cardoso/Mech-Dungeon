using System.Collections;
using UnityEngine;

public class ChefeCadencia : AtivarHabilidadeChefe
{
    public override void Ativar()
    {
        StartCoroutine(buff());
        cor = Color.yellow;
    }

    IEnumerator buff()
    {
        modCadencia += 1;
        yield return new WaitForSeconds(3);
        modCadencia -= 1;
    }
}
