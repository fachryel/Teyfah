using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{

    public BoxCollider2D triggerArea;
    public CapsuleCollider2D doorCollider;
    [SerializeField] private bool isOpen;
    public Vector3 tarPos;
    public Vector3 defPos;
    public bool isMoving;
    public bool isOpening;
    public bool isClosing;
    public string sceneToLoad;
    public int Stage;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        triggerArea = GetComponent<BoxCollider2D>();
        doorCollider = GetComponent<CapsuleCollider2D>();
        defPos = transform.position;
        tarPos = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        player = GameObject.FindWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerArea.IsTouchingLayers(LayerMask.GetMask("Player")) && Input.GetKeyUp(KeyCode.E) && isOpen == false)
        {
            doorCollider.isTrigger = true;
            isOpening = true;
            isClosing = false;
            StartCoroutine(OnOpen());
            StopCoroutine(OnClose());
            isOpen = true;

        }
        else if (triggerArea.IsTouchingLayers(LayerMask.GetMask("Player")) && Input.GetKeyUp(KeyCode.E) && isOpen == true)
        {
            doorCollider.isTrigger = false;
            isClosing = true;
            isOpening = false;
            StopCoroutine(OnOpen());
            StartCoroutine(OnClose());
            isOpen = false;

        }
    }

   

    public GameObject player;
    public Vector3 vposition;
    //lerp for the door open and close
    public IEnumerator OnOpen()
    {
        while (isOpening)
        {
            transform.position = Vector3.Lerp(transform.position, tarPos, 0.1f);
            if (Mathf.Abs(transform.position.y - tarPos.y) < 0.1f)
            {
                transform.position = tarPos;
                StopCoroutine(OnOpen());
                isOpening = false;
            }

            yield return new WaitForSeconds(0.3f);
            //load next scene
            if (sceneToLoad != null)
            {
                player.transform.position = vposition;
                player.GetComponent<PlayerHealth>().stage += 1;
                sceneToLoad = "Stage" + Stage;
                SceneManager.LoadScene(sceneToLoad);
            }

        }

    }

    public IEnumerator OnClose()
    {
        while (isClosing)
        {
            transform.position = Vector3.Lerp(transform.position, defPos, 0.1f);
            if (Mathf.Abs(transform.position.y - defPos.y) < 0.1f)
            {
                StopCoroutine(OnClose());
                transform.position = defPos;
                isClosing = false;
            }
            yield return new WaitForSeconds(0.1f);

        }

    }
}
