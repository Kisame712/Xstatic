using UnityEngine; 
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
    }
}
