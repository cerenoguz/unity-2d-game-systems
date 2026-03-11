using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private void Start()
    {
        // Add a listener to the button's click event
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        // Reload the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
