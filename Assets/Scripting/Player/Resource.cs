using UnityEngine;
using TMPro;

public class Resource : MonoBehaviour
{
    public float coin;
    public AudioSource coinSound;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Coin: " + coin;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coinSound.Play();
        }
    }
}
