using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rooms;

    [SerializeField]
    private GameObject dialoguePanel;

    private GameObject currentRoom;

    public void PlayDialogue(string[] lines)
    {
        GameObject[] gos = currentRoom.GetComponentsInChildren<GameObject>();
        GameObject triggers = null;
        for (int i = 0; i < gos.Length; i++)
        {
            if (gos[i].name.Equals("Triggers"))
            {
                triggers = gos[i];
                break;
            }
        }
        triggers.SetActive(false);
        dialoguePanel.SetActive(true);
        //dialoguePanel.GetComponent<DialogueManager>();
    }

    public void StopDialogue()
    {
        GameObject[] gos = currentRoom.GetComponentsInChildren<GameObject>();
        GameObject triggers = null;
        for (int i = 0; i < gos.Length; i++)
        {
            if (gos[i].name.Equals("Triggers"))
            {
                triggers = gos[i];
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
