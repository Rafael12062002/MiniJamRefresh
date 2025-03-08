using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    //buttons Menu
    public Button config;
    public Button outrosJogos;
    public Button som;
    public Button loja;
    public Button startGame;
    public Button quitGame;
    public Button options;
    public Button fecharPanelOptions;
    public Button fecharPanelLoja;

    //panels Menu
    public GameObject panelConfig;
    public GameObject panelOptions;
    public GameObject panelLoja;

    //Intro
    public Button voltarMenu;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Start()
    {
        AtualizarUI(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AtualizarUI(scene.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AtualizarUI(string sceneName)
    {
        if(sceneName == "Menu")
        {
            // Menu
            config = GameObject.Find("Config").GetComponent<Button>();
            outrosJogos = GameObject.Find("OutrosJogos").GetComponent<Button>();
            som = GameObject.Find("Som").GetComponent<Button>();
            //loja = GameObject.Find().
            startGame = GameObject.Find("StartGame").GetComponent<Button>();
            quitGame = GameObject.Find("QuitGame").GetComponent<Button>();
            options = GameObject.Find("Options").GetComponent<Button>();
            fecharPanelOptions = GameObject.Find("FecharPanel").GetComponent<Button>();
            fecharPanelLoja = GameObject.Find("FecharPanelLoja").GetComponent<Button>();
            panelConfig = GameObject.FindWithTag("Config");
            panelOptions = GameObject.FindWithTag("PanelOptions");
            panelLoja = GameObject.FindWithTag("PanelLoja");

            //PanelConfig começa desativado
            panelConfig.SetActive(false);
            panelOptions.SetActive(false);
            panelLoja.SetActive(false);

            //Buttons Menu
            config.onClick.AddListener(AbrirPanelConfig);
            startGame.onClick.AddListener(StartGame);
            quitGame.onClick.AddListener(QuitGame);
            options.onClick.AddListener(Options);
            loja.onClick.AddListener(AbrirPanelLoja);
            fecharPanelOptions.onClick.AddListener(FecharPanelOptions);
            fecharPanelLoja.onClick.AddListener(FecharPanelLoja);
        }
        if(sceneName == "Intro")
        {
            voltarMenu = GameObject.Find("VoltarMenu").GetComponent<Button>();
            //Buttons Intro
            voltarMenu.onClick.AddListener(BackToMenu);
        }
    }

    void AbrirPanelConfig()
    {
        panelConfig.gameObject.SetActive(true);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }

    void Options()
    {
        panelOptions.gameObject.SetActive(true);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void FecharPanelOptions()
    {
        Debug.Log("Fechando...");
        panelOptions.gameObject.SetActive(false);
    }

    void AbrirPanelLoja()
    {
        panelLoja.gameObject.SetActive(true);
    }

    void FecharPanelLoja()
    {
        panelLoja.SetActive(false);
    }

    void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
