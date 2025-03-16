using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.LookDev;
using UnityEngine.SceneManagement;
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

    private void Awake()
    {
        if (dialoguePanel == null)
        {
            dialoguePanel = GameObject.FindWithTag("DialoguePanel");
        }
        if (dialogue == null)
        {
            dialogue = GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        }
        if (buttonNextDialogue == null)
        {
            buttonNextDialogue = GameObject.Find("Next").GetComponent<Button>();
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("Painel começa ativo? " + dialoguePanel.activeInHierarchy);
    }
    void Start()
    {
        Debug.Log("Iniciando Dialogue.cs...");

        dialoguePanel = GameObject.FindWithTag("DialoguePanel"); // Substitua pelo nome correto

        if (dialoguePanel == null)
        {
            Debug.LogError("Painel de diálogo não encontrado!");
        }
        else
        {
            Debug.Log("Painel de diálogo encontrado corretamente.");
        }

        // Desativa o painel de diálogo logo no começo
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);  // Certifique-se que o painel começa desativado
        }

        enemy = GetComponent<Enemy>();

        dialogues[0] = dialogue1;
        dialogues[1] = dialogue2;
        dialogues[2] = dialogue3;

        buttonNextDialogue.gameObject.SetActive(false);
        buttonNextDialogue.onClick.AddListener(NextDialogue);
        dialogue.text = "";
        StartCoroutine(Rotina());
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(dialoguePanel ==  null)
        {
            dialoguePanel = GameObject.FindWithTag("DialoguePanel");
        }
        if(dialogue ==  null)
        {
            dialogue = GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        }
        if(buttonNextDialogue == null)
        {
            buttonNextDialogue = GameObject.Find("Next").GetComponent<Button>();
        }
        if(dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
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
