using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToStage1()
    {
        SceneManager.LoadScene("Stage1");
        SceneManager.UnloadSceneAsync("MainMenu");
    }
}
