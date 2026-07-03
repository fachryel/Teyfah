using UnityEngine;
using TMPro;
public class Pausystem : MonoBehaviour
{

    public bool isPaused = false;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaused && Input.GetButtonDown("Pause")){
            Time.timeScale = 1f;
            text.text = "";
            isPaused = false;
        } else if(!isPaused && Input.GetButtonDown("Pause")){
            Time.timeScale = 0f;
            isPaused = true;
            text.text = "Paused";
        }
    }
}
