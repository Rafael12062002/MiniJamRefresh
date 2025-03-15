using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.LookDev;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogue;
    public Button buttonNextDialogue;
    public int cont = 0;
    public float speedTiping = 0.05f;

    Enemy enemy;

    string[] dialogues = new string[3];
    public string dialogue1;
    public string dialogue2;
    public string dialogue3;
    void Start()
    {
        enemy = GetComponent<Enemy>();

        dialogues[0] = dialogue1;
        dialogues[1] = dialogue2;
        dialogues[2] = dialogue3;

        buttonNextDialogue.gameObject.SetActive(false);
        buttonNextDialogue.onClick.AddListener(NextDialogue);
        dialogue.text = "";
        StartCoroutine(Rotina());
    }

    public IEnumerator Rotina()
    {
        dialogue.text = "";
        var operation = dialogues[cont];
        yield return operation;
        string textBuscado = operation;

        foreach(char letter  in textBuscado.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSeconds(speedTiping);
        }
        buttonNextDialogue.gameObject.SetActive(true);
    }

    public void NextDialogue()
    {
        buttonNextDialogue.gameObject.SetActive(false);
        cont++;
        if(cont < dialogues.Length)
        {
            StartCoroutine(Rotina());
        }
        else
        {
            dialoguePanel.SetActive(false);
            enemy.gameObject.SetActive(true);
        }
    }
}
