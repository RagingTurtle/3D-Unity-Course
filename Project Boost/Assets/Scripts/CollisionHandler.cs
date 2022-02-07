using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log(other.gameObject.tag);
                break;
            case "Finish":
                Debug.Log(other.gameObject.tag);
                break;
            default:
                Debug.Log("default: " + other.gameObject.tag);
                ReloadLevel();
                break;
        }
    }

    private void ReloadLevel()
    {
        string currentLevel = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentLevel);
    }
}
