using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{
    private LocalizedString[] textos; // Lista de textos que serão passados na introdução, esta como Localization por conta da dependencia
    // List of texts that will be displayed in the introduction, set as Localization due to dependency
    public TextMeshProUGUI texto; // texto da cena
    // scene text
    int cont = 0; // contador
    // counter
    public Button nextText;
    public float typingSpeed = 0.05f; // velocidade que o texto será digitado
                                      // speed at which the text will be typed

    void Start()
    {
        textos = new LocalizedString[5]; // definindo a quantidade de textos
        // defining the number of texts

        // aqui a gente coloca os textos em cada posição do vetor e utilizamos o LocalizateString para pegar o nome da tebela que tem os textos
        //de segundo parametro temos as chaves de referencia do texto que será traduzido
        // here we place the texts in each position of the array and use LocalizateString to get the name of the table that contains the texts
        // as a second parameter, we have the reference keys of the text that will be translated
        textos[0] = new LocalizedString("Traducao", "Intro_0");
        textos[1] = new LocalizedString("Traducao", "Intro_1");
        textos[2] = new LocalizedString("Traducao", "Intro_2");
        textos[3] = new LocalizedString("Traducao", "Intro_3");
        textos[4] = new LocalizedString("Traducao", "Intro_4");

        nextText.onClick.AddListener(NextText);
        texto.text = "";
        nextText.gameObject.SetActive(false);
        StartCoroutine(Rotina()); // inicializa a rotina de digitação
        // starts the typing routine
    }

    public IEnumerator Rotina()
    {
        texto.text = "";
        // Busca o texto localizado antes de exibir
        // Fetches the localized text before displaying
        var operation = textos[cont].GetLocalizedStringAsync();
        yield return operation;

        string textBuscado = operation.Result;

        // busca letra por letra do texto e imprime uma atrás da outra
        // retrieves letter by letter of the text and prints one after the other
        foreach (char letter in textBuscado.ToCharArray())
        {
            texto.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        nextText.gameObject.SetActive(true);
    }

    // Ativa o botão de passar o texto
    // Activates the button to proceed with the text
    public void NextText()
    {
        nextText.gameObject.SetActive(false);
        cont++;

        if (cont < textos.Length)
        {
            StartCoroutine(Rotina());
        }
        else
        {
            SceneManager.LoadScene("FaseIntrodutoria"); // Troca para a próxima cena
            // Switches to the next scene
        }
    }
}
