using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
