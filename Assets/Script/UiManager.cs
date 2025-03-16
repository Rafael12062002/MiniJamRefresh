using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Localization.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86;

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
    public Button ingles;
    public Button portugues;
    public Button fecharTutorial;


    public Button backMenu;
    //public Button playAgain;

    //panels Menu
    public GameObject panelGameOver;
    public GameObject panelConfig;
    public GameObject panelOptions;
    public GameObject panelLoja;
    public GameObject panelTutorial;

    Player player;
    //Url Do portifolio
    public string url = "https://paulo-rafael-c-r.itch.io/";
    private bool isChanging = false;

    private void Awake()
    {
        if (instance == null)
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

    public void AtualizarUI(string sceneName)
    {
        if (sceneName == "Menu")
        {
            // Menu
            config = GameObject.Find("Config").GetComponent<Button>();
            loja = GameObject.Find("Loja").GetComponent<Button>();
            som = GameObject.Find("Som").GetComponent<Button>();
            fecharPanelLoja = GameObject.Find("FecharPanelLoja").GetComponent<Button>();
            outrosJogos = GameObject.Find("OutrosJogos").GetComponent<Button>();
            startGame = GameObject.Find("StartGame").GetComponent<Button>();
            quitGame = GameObject.Find("QuitGame").GetComponent<Button>();
            options = GameObject.Find("Options").GetComponent<Button>();
            fecharPanelOptions = GameObject.Find("FecharPanel").GetComponent<Button>();
            panelConfig = GameObject.FindWithTag("Config");
            panelOptions = GameObject.FindWithTag("PanelOptions");
            panelLoja = GameObject.FindWithTag("PanelLoja");
            ingles = GameObject.Find("Ingles").GetComponent<Button>();
            portugues = GameObject.Find("Portugues").GetComponent<Button>();  

            //PanelConfig começa desativado
            panelOptions.SetActive(false);
            panelLoja.SetActive(false);
            panelConfig.SetActive(false);

            //Buttons Menu
            config.onClick.AddListener(AbrirPanelConfig);
            startGame.onClick.AddListener(StartGame);
            quitGame.onClick.AddListener(QuitGame);
            options.onClick.AddListener(Options);
            loja.onClick.AddListener(AbrirPanelLoja);
            fecharPanelOptions.onClick.AddListener(FecharPanelOptions);
            fecharPanelLoja.onClick.AddListener(FecharPanelLoja);
            outrosJogos.onClick.AddListener(ButtonOutrosJogos);
            som.onClick.AddListener(RemoverSom); 
        }
        if(sceneName == "FaseIntrodutoria" || sceneName == "FaseTorre")
        {
            Debug.Log("Tentando encontrar panel Game over");
            if(player == null)
            {
                player = FindObjectOfType<Player>();
            }
            if(panelGameOver == null)
            {
                panelGameOver = GameObject.FindGameObjectWithTag("PanelGameOver");
            }
            if(panelTutorial == null)
            {
                panelTutorial = GameObject.FindWithTag("TutorialPanel");
            }
            if(fecharTutorial == null)
            {
                fecharTutorial = GameObject.Find("FecharT").GetComponent<Button>();
            }
            if(backMenu == null)
            {
                backMenu = GameObject.Find("BackToMenu").GetComponent<Button>();
            }
            if(panelGameOver !=  null)
            {
                panelGameOver.SetActive(false);
            }
            fecharTutorial.onClick.AddListener(FecharTutorial);
            backMenu.onClick.AddListener((BackToMenu));
        }
        //panelGameOver.SetActive(false);
        // Verifique a lógica do método
        Debug.Log($"Atualizando UI para a cena {sceneName}");
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

    void FecharTutorial()
    {
        panelTutorial.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void BackToMenu()
    {
        Debug.Log("Apertado");
        SceneManager.LoadScene("Menu");
    }

    void ButtonOutrosJogos()
    {
        Application.OpenURL(url);
    }

    void RemoverSom()
    {

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.gameObject.SetActive(true);
    }

    public void ChangeToEnglish()
    {
        StartCoroutine(SetLanguage("en-US"));
    }

    public void ChangeToPortuguese()
    {
        StartCoroutine(SetLanguage("pt-BR"));
    }

    private IEnumerator SetLanguage(string localeCode)
    {
        if (isChanging) yield break; // Evita múltiplas chamadas simultâneas
        isChanging = true;

        yield return LocalizationSettings.InitializationOperation;

        var locale = LocalizationSettings.AvailableLocales.Locales.Find(l => l.Identifier.Code == localeCode);
        if (locale != null)
        {
            LocalizationSettings.SelectedLocale = locale;
        }
        else
        {
            Debug.LogError("Idioma não encontrado: " + localeCode);
        }

        isChanging = false;
    }
}