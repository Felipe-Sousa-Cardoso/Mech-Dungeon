using UnityEngine;
using UnityEngine.SceneManagement;

public class InimigoChefe : MonoBehaviour
{
    private void OnDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
