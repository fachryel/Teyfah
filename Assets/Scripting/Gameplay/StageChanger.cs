using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChanger : MonoBehaviour
{

    public string sceneToLoad;
    public Vector2 startPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

        }
    }
    
    public IEnumerator ChangeScene()
    {
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
