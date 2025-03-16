using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectInteractive : MonoBehaviour
{
    public GameObject objectInteractive;
    Dialogue dialogue;
    public bool isTrigger = false;
    public AudioSource audioMaquina;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        audioMaquina = GameObject.Find("MaquinaHistory").GetComponent<AudioSource>();
        objectInteractive = transform.Find("ButtonInteract")?.gameObject;
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(dialogue ==  null)
        {
            dialogue = GetComponent<Dialogue>();
        }
        if(objectInteractive ==  null)
        {
            objectInteractive = transform.Find("ButtonInteract")?.gameObject;
        }
        if(audioMaquina == null)
        {
            audioMaquina = GameObject.Find("MaquinaHistory").GetComponent<AudioSource>();
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
