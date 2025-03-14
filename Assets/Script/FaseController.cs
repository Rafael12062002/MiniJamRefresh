using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseController : MonoBehaviour
{
    public GameObject aparecerButton;
    public bool isTrigger;
    // Start is called before the first frame update
    void Start()
    {
        aparecerButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isTrigger && Input.GetKeyUp(KeyCode.F))
        {
            SceneManager.LoadScene("FaseTorre");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            aparecerButton.SetActive(true);
            isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            aparecerButton.SetActive(false);
            isTrigger = false;
        }
    }
}
