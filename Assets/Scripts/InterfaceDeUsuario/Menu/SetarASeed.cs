using UnityEngine;
using TMPro;
public class SetarASeed : MonoBehaviour
{
    TMP_InputField input;
    [SerializeField] Seed seed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        seed._Seed = input.text;
    }
}
