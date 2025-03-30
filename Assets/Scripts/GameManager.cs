using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rooms;

    [SerializeField]
    private GameObject dialoguePanel;

    private GameObject currentRoom;

    public void PlayDialogue(string[] lines)
    {
        GameObject triggers = null;
        Debug.Log("Playing dialogue");
        Debug.Log("Current room: " + currentRoom.name);
        for (int i = 0; i < currentRoom.transform.childCount; i++)
        {
            GameObject child = currentRoom.transform.GetChild(i).gameObject;
            if (child.name.Equals("Triggers"))
            {
                triggers = currentRoom.transform.GetChild(i).gameObject;
                break;
            }
        }
        triggers.SetActive(false);
        dialoguePanel.SetActive(true);
        dialoguePanel.GetComponent<DialogueManager>().UpdateLines(lines);
        dialoguePanel.GetComponent<DialogueManager>().DisplayText();
    }

    public void StopDialogue()
    {
        GameObject triggers = null;
        for (int i = 0; i < currentRoom.transform.childCount; i++)
        {
            GameObject child = currentRoom.transform.GetChild(i).gameObject;
            if (child.name.Equals("Triggers"))
            {
                triggers = currentRoom.transform.GetChild(i).gameObject;
                break;
            }
        }

        triggers.SetActive(true);
        dialoguePanel.SetActive(false);
    }

    public void Move(Trigger name)
    {
        currentRoom = rooms[(int)name];

        for (int i = 0; i < rooms.Length; i++)
        {
            if (i == (int)name)
            {
                rooms[i].SetActive(true);
            }
            else
            {
                rooms[i].SetActive(false);
            }
        }
    }

    
}
