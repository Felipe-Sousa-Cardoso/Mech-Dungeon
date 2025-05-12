using UnityEngine;
using System.Collections;

public class ChefeDano : AtivarHabilidadeChefe
{
    public override void Ativar()
    {
        StartCoroutine(buff());
        print("sim");
    }

    IEnumerator buff()
    {
        ModDano += 1;
        yield return new WaitForSeconds(3);
        ModDano -= 1;
    }
}
