using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;
    [SerializeField]
    private TextMeshProUGUI textField;
    private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //textField = GetComponent<TextMeshProUGUI>();
        index = 0;
    }

    public void UpdateText(string[] lines)
    {
        if (lines.Length >= index)
        {
            gameManager.GetComponent<GameManager>().StopDialogue();
            index = 0;
            textField.text = "-";
            return;
        }
    }

    public void UpdateIndex()
    {
        index++;
    }
}
