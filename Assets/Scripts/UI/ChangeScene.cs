using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public string scene;
    public void GoToScene()
    {
        SceneManager.LoadScene(scene);
    }

}
