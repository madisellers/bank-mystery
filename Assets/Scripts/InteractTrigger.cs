using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public enum Trigger
{
    LOBBY_MOVE,
    SECURITY_MOVE,
    OFFICE_MOVE,
    LOBBY_ZOOM,
    SECURITY_ZOOM,
    OFFICE_ZOOM
}

public class InteractTrigger : MonoBehaviour
{
    [SerializeField]
    private bool isDialogueTrigger;
    [SerializeField]
    private bool isZoomTrigger;
    [SerializeField]
    private bool isMoveTrigger;

    public Trigger trigger;

    public string[] dialogue;

    private void Start()
    {
        //if (trigger == null) { Debug.LogError("Trigger name not found"); Debug.Break(); }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Mouse")) {
            other.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
            //Change cursor color/shape
            if (Input.GetMouseButtonDown(0)) {
                TriggerEvent();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Mouse"))
        {
            collision.GetComponentInChildren<Image>().color = Color.white;
        }
    }

    void TriggerEvent()
    {
        if (isDialogueTrigger)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PlayDialogue(dialogue);
            Debug.Log("Triggered dialogue");
        }
        else if (isZoomTrigger)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Move(trigger);
            Debug.Log("Triggered zoom");
        }
        else if (isMoveTrigger)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Move(trigger);
            Debug.Log("Triggered move");
        }
    }
}
