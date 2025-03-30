using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool atStart = false;
    public bool atEnd = false;

    public bool sawPaper = false;
    public bool sawVideo = false;
    public bool sawKey = false;


    [SerializeField]
    private GameObject[] rooms;

    [SerializeField]
    private GameObject finalTrigger;

    [SerializeField]
    private GameObject dialoguePanel;

    private GameObject currentRoom;

    private void Update()
    {
        if (sawKey && sawVideo && sawPaper)
        {
            finalTrigger.SetActive(true);
        }
    }
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
        if (sawKey && sawPaper && sawVideo)
        {
            finalTrigger.SetActive(true);
        }
        GameObject triggers = null;
        for (int i = 0; i < currentRoom.transform.childCount; i++)
        {
            if (atStart)
            {
                atStart = false;
                Move(Trigger.LOBBY_MOVE);
            }
            if (atEnd)
            {
                atEnd = false;
                Move(Trigger.END_MOVE);
            }
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

    public void SetCurrentRoom(GameObject room)
    {
        currentRoom = room;
    }

    public void SetAtStart(bool atStart)
    {
        this.atStart = atStart;
    }

    public void SetAtEnd(bool atEnd)
    {
        this.atEnd = atEnd;
    }

    public void SawPaper()
    {
        sawPaper = true;
    }

    public void SawKey()
    {
        sawKey = true;
    }

    public void SawVideo()
    {
        sawVideo = true;
    }

    
}
