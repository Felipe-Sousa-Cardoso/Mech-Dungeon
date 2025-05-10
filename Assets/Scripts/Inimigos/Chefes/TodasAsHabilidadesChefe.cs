using UnityEngine;
using UnityEngine.UIElements;

public class TodasAsHabilidadesChefe : MonoBehaviour
{
    [SerializeField] Transform chefe;
    // Update is called once per frame
    void Update()
    {
        if (chefe)
        {
            transform.position = chefe.position;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
