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
    OFFICE_ZOOM, 
    //INVESTIGATE
}

public class InteractTrigger : MonoBehaviour
{
    [SerializeField]
    private bool isDialogueTrigger;
    [SerializeField]
    private bool isZoomTrigger;
    [SerializeField]
    private bool isMoveTrigger;
   // [SerializeField]    private bool isInvestgateTrigger;

    public Trigger trigger;

    [TextArea(2, 10)]
    public string flavorText;

    [TextArea(4, 10)]
    public string[] dialogue;

    private GameObject flavorTextObj = null;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Mouse")) {
            other.GetComponentInChildren<Image>().color = new Color(0.31f, 0.839f, 1f);
            flavorTextObj = null;
            if (flavorText != null && flavorText.Length > 0)
            {
               
                
                GameObject mouse = GameObject.Find("Mouse");
                for (int i = 0; i < mouse.transform.childCount; i++)
                {
                    GameObject child = mouse.transform.GetChild(i).gameObject;
                    if (child.name.Equals("FlavorText"))
                    {
                        flavorTextObj = child;
                        break;
                    }
                }
                flavorTextObj.SetActive(true);
                flavorTextObj.GetComponent<TextMeshProUGUI>().text = flavorText;

            }

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
            if (flavorText != null && flavorText.Length > 0)
            {
                if (flavorText != null && flavorText.Length > 0)
                {
                    GameObject flavorTextObj = null;

                    GameObject mouse = GameObject.Find("Mouse");
                    for (int i = 0; i < mouse.transform.childCount; i++)
                    {
                        GameObject child = mouse.transform.GetChild(i).gameObject;
                        if (child.name.Equals("FlavorText"))
                        {
                            flavorTextObj = child;
                            break;
                        }
                    }
                    flavorTextObj.GetComponent<TextMeshProUGUI>().text = "";
                    flavorTextObj.SetActive(false);

                }
            }
        }
    }

    void TriggerEvent()
    {
        if (isDialogueTrigger)
        {
            flavorTextObj.SetActive(false);
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
        yield return new WaitForSeconds(.15f);
        TriggerEvent();
    }
}
