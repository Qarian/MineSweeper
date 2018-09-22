using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour{

    public void ChangeSceneNum(int num)
    {
        SceneManager.LoadScene(num);
    }
}
