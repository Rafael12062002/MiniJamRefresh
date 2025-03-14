using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectInteractive : MonoBehaviour
{
    public GameObject objectInteractive;
    Dialogue dialogue;
    public bool isTrigger = false;
    public AudioSource audioMaquina;

    void Start()
    {
        dialogue = GetComponent<Dialogue>();
        objectInteractive.SetActive(false);
    }

    void Update()
    {
        if(isTrigger && Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("Interagindo...");
            dialogue.dialoguePanel.SetActive(true);
            audioMaquina.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            objectInteractive.SetActive(true);
            isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTrigger = false;
            objectInteractive.SetActive(false);
            dialogue.dialoguePanel.SetActive(false);
            audioMaquina.Stop();
        }
    }
}
