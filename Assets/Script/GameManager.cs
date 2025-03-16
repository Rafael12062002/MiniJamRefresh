using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public MovePlayer player;
    public Player estatisticPlayer;
    public Canvas canvas;
    public EventSystem eventSystem;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            if(player !=  null)
            {
                DontDestroyOnLoad(player.gameObject);
            }
            if(estatisticPlayer != null)
            {
                DontDestroyOnLoad(estatisticPlayer.gameObject);
            }
            if(canvas != null)
            {
                DontDestroyOnLoad(canvas.gameObject);
            }
            if(eventSystem != null)
            {
                DontDestroyOnLoad(eventSystem.gameObject);
            }
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (UiManager.instance.panelTutorial.activeInHierarchy)
        {
            Time.timeScale = 0f;
        }

        Debug.Log($"Cena carregada = {scene.name}");
        if(scene.name == "Menu" ||  scene.name == "Intro" || scene.name == "FimPrototipo")
        {
            Destroy(player?.gameObject);
            Destroy(estatisticPlayer?.gameObject);
            Destroy(canvas?.gameObject);
        }

        if (player == null && scene.name == "FaseIntrodutoria")
        {
            player = FindObjectOfType<MovePlayer>();
            if (player != null) DontDestroyOnLoad(player);
        }
        if (estatisticPlayer == null && scene.name == "FaseIntrodutoria")
        {
            estatisticPlayer = FindObjectOfType<Player>();
            if(estatisticPlayer != null) DontDestroyOnLoad(estatisticPlayer);
        }
        if (canvas == null && scene.name == "FaseIntrodutoria")
        {
            canvas = FindObjectOfType<Canvas>();
            if(canvas != null) DontDestroyOnLoad(canvas);
        }
        // Busca os painéis novamente
        UiManager uiManager = FindObjectOfType<UiManager>();
        if (uiManager != null)
        {
            uiManager.AtualizarUI(scene.name);
        }
        else
        {
            Debug.LogError("UiManager não encontrado na cena!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
