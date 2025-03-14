using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Esse Script serve para silenciar todos os audios do jogo e mudar a cor da imagem
//This script is used to mute all game audio and change the image color
public class AudioListener : MonoBehaviour
{
    public static AudioListener instance;
    private AudioListener audioListener;
    public bool isMuted = false;
    public Image iconButton;

    public Color normalColor = Color.white;
    public Color muteColor = Color.gray;

    //Método para fazer o script persistir entre as cenas e não ser destruido
    //Method to make the script persist between scenes and not be destroyed
    void Awake()
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
    }

    void Start()
    {
        audioListener = FindObjectOfType<AudioListener>();

        if (iconButton == null)
        {
            Debug.Log("Imagem não atribuida ao botão");
            //Image not assigned to the button
        }
    }

    //Evento de botão referenciado no inspector do botão de som
    //Button event referenced in the sound button inspector
    public void ToggleAudio()
    {
        if (audioListener != null)
        {
            isMuted = !isMuted;
            audioListener.isMuted = !isMuted;
            Debug.Log("Som Mutado: " + isMuted);
            //Sound Muted: " + isMuted

            if (iconButton != null)
            {
                iconButton.color = isMuted ? muteColor : normalColor;
            }
        }
        else
        {
            Debug.LogError("AudioListener não encontrado!");
            //AudioListener not found!
        }
    }
}
