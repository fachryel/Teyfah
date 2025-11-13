using UnityEngine;
using Unity.Cinemachine;


public class CameraFoV : MonoBehaviour
{

    public CinemachineCamera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1") && cam.Lens.OrthographicSize > 5)
        {
            cam.Lens.OrthographicSize -= 1;
        }
        if (Input.GetKey("2") && cam.Lens.OrthographicSize < 10)
        {
            cam.Lens.OrthographicSize += 1;
        }
    }
}
