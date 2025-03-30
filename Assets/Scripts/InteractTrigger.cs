using UnityEngine;
using UnityEngine.InputSystem;

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

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Mouse")) {
            //Change cursor color/shape
            if (Input.GetMouseButtonDown(0)) {
                TriggerEvent();
            }
        }
    }

    void TriggerEvent()
    {
        if (isDialogueTrigger)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PlayDialogue(dialogue);
        }
        else if (isZoomTrigger)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Move(trigger);
        }
        else if (isMoveTrigger)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Move(trigger);
        }
    }
}
