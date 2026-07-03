using UnityEngine;
using TMPro;

public class win : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Resource coin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coin = GameObject.FindWithTag("Player").GetComponent<Resource>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Congratulation!! You get " + coin + "coins";
    }
}
