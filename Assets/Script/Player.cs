using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Classe que pode separar atributos mais importantes e herda o entity
public class Player : MonoBehaviour
{
    public Entity entity;
    public GameObject balaProjetil;
    public Transform arma;
    private bool tiro;
    public float forcaTiro;
    public bool tiroLiberado;
    public bool isdead;
    public GameObject minhaArma;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Start()
    {
        if (minhaArma == null && SceneManager.GetActiveScene().name == "FaseTorre")
        {
            minhaArma = GameObject.FindWithTag("Arma");
        }
        isdead = false;
        tiroLiberado = false;
    }

    // Update is called once per frame
    void Update()
    {
        tiro = Input.GetButtonDown("Fire1");

        Atirar();
    }

    void Atirar()
    {
        if(tiro == true && tiroLiberado)
        {
            GameObject temp = Instantiate(balaProjetil);
            temp.transform.position = arma.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaTiro, 0);
            Destroy(temp.gameObject, 3f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Finish"))
        {
            Morte();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Arma"))
        {
            Destroy(minhaArma.gameObject);
            tiroLiberado = true;
        }
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        if(minhaArma == null)
        {
            minhaArma = GameObject.FindWithTag("Arma");
        }
    }

    public void Morte()
    {
        isdead = true;
        gameObject.SetActive(false);
        if(isdead)
        {
            UiManager.instance.panelGameOver.SetActive(true);
        }
    }
}
