using TMPro;
using UnityEngine;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;
    [SerializeField]
    private TextMeshProUGUI textField;
    private int index;
    private string[] lines;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //textField = GetComponent<TextMeshProUGUI>();
        index = 0;
    }

    public void DisplayText()
    {
        if (lines == null) { return; }
        if (index >= lines.Length)
        {
            gameManager.GetComponent<GameManager>().StopDialogue();
            index = 0;
            lines = null;
            textField.text = "-";
            return;
        }
        textField.text = lines[index];
    }

    public void UpdateLines(string[] lines)
    {
        this.lines = (string[])lines.Clone();
       
    }

    public void UpdateIndex()
    {
        index++;
    }
}
