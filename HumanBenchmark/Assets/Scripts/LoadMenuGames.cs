using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuGames : MonoBehaviour
{
    public Object VerbalMemoryScene;
    public Object ReactionTimeScene;

    public void OpenVerbalMemoryGame() {
        SceneManager.LoadScene("VerbalMemoryGame", LoadSceneMode.Single);
    }

    public void OpenReactionTimeGame() {
        SceneManager.LoadScene("ReactionTimeGame", LoadSceneMode.Single);
    }
}
