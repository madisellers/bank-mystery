using System.Collections;
using TMPro;
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

    [TextArea(4, 10)]
    public string[] dialogue;

    private void Start()
    {
        //if (trigger == null) { Debug.LogError("Trigger name not found"); Debug.Break(); }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Mouse")) {
            other.GetComponentInChildren<Image>().color = new Color(0.31f, 0.839f, 1f);
            //Change cursor color/shape
            if (Input.GetMouseButtonDown(0)) {
                other.GetComponentInChildren<Image>().color = Color.white;

                StartCoroutine(Buffer());
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Mouse"))
        {
            Debug.Log("Mouse has left.");
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

    IEnumerator Buffer()
    {
        yield return new WaitForSeconds(.25f);
        TriggerEvent();
    }
}
