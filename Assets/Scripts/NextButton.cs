using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class NextButton : MonoBehaviour
{
    [SerializeField]
    private DialogueManager dialogueManager;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Mouse"))
        {
            other.GetComponentInChildren<Image>().color = new Color(0.31f, 0.839f, 1f);
            //Change cursor color/shape
            if (Input.GetMouseButtonDown(0))
            {
                other.GetComponentInChildren<Image>().color = Color.white;

                StartCoroutine(Buffer());
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Mouse"))
        {
            //Debug.Log("Mouse has left.");
            collision.GetComponentInChildren<Image>().color = Color.white;
        }
    }

    IEnumerator Buffer()
    {
        yield return new WaitForSeconds(.15f);
        dialogueManager.UpdateIndex();
        dialogueManager.DisplayText();
    }


}
