using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
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

    public GameObject minhaArma;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Start()
    {
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
        if(minhaArma == null && scene.name == "FaseTorre")
        {
            minhaArma = GameObject.FindWithTag("Arma");
        }
    }
}
