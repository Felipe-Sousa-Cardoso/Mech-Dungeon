using UnityEngine;
using System.Collections;

public class ChefeDano : AtivarHabilidadeChefe
{
    public override void Ativar()
    {
        StartCoroutine(buff());
        cor = Color.red;
    }

    IEnumerator buff()
    {
        modDano += 1;
        yield return new WaitForSeconds(3);
        modDano -= 1;
    }
}
