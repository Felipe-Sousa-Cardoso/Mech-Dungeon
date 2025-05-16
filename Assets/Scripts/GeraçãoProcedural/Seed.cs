using UnityEngine;

public class Seed : MonoBehaviour
{
    public string seed = "";
    public int atualSeed = 0;

    private void Awake()
    {
        atualSeed = seed.GetHashCode();
        Random.InitState(atualSeed);
    }
}
