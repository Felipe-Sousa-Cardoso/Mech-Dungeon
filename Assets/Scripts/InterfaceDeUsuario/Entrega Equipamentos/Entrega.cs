using UnityEngine;

public class Entrega : MonoBehaviour //Contem os métodos comuns a todas as entregas
{
    protected void EmbaralharArray<T>(T[] lista) //embaralha a lista, serve para qualquer array
    {
        for (int i = 0; i < lista.Length; i++)
        {
            int rand = Random.Range(i, lista.Length);
            (lista[i], lista[rand]) = (lista[rand], lista[i]);
        }

    }
}
