using System.Collections;
using UnityEngine;

public class ChefeCadencia : AtivarHabilidadeChefe
{
    public override void Ativar()
    {
        StartCoroutine(buff());
    }

    IEnumerator buff()
    {
        mod += 1;
        yield return new WaitForSeconds(3);
        mod -= 1;
    }
}
