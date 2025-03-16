using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Esse Script serve para silenciar todos os audios do jogo e mudar a cor da imagem
//This script is used to mute all game audio and change the image color
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
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
        UpdateAudioState();
    }

    //Evento de botão referenciado no inspector do botão de som
    //Button event referenced in the sound button inspector
    public void ToggleAudio()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0f : 1f;
        Debug.Log("Som Mutado: " + isMuted);

        if (iconButton != null)
        {
            iconButton.color = isMuted ? muteColor : normalColor;
        }
    }

    private void UpdateAudioState()
    {
        AudioListener.volume = isMuted ? 0f : 1f;

        if (iconButton != null)
        {
            iconButton.color = isMuted ? muteColor : normalColor;
        }
    }
}
