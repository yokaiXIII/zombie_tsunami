using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : Singleton<SceneManager>
{
    void Update()
    {
        // Example: Restart the scene when the "R" key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MovementDemo3", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MovementDemo2", LoadSceneMode.Single);
        }
    }

    static public void RestartScene()
    {
        // Get the current active scene and reload it
        Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.name);
    }
}
