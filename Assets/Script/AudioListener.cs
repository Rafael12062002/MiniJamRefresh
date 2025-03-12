using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioListener : MonoBehaviour
{
    public static AudioListener instance;
    private AudioListener audioListener;
    public bool isMuted = false;
    public Image iconButton;

    public Color normalColor = Color.white;
    public Color muteColor = Color.gray;
    void Awake()
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
    }

    void Start()
    {
        audioListener = FindObjectOfType<AudioListener>();

        if(iconButton == null)
        {
            Debug.Log("Imagem não atribuida ao botão");
        }
    }

   public void ToggleAudio()
    {
        if(audioListener != null)
        {
            isMuted = !isMuted;
            audioListener.isMuted = !isMuted;
            Debug.Log("Som Mutado: " + isMuted);

            if (iconButton != null)
            {
                iconButton.color = isMuted ? muteColor : normalColor;
            }
        }
        else
        {
            Debug.LogError("AudioListener não encontrado!");
        }
    }
}
