using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{
    private LocalizedString[] textos;
    public TextMeshProUGUI texto;
    int cont = 0;
    public Button nextText;
    public float typingSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        textos = new LocalizedString[5];

        textos[0] = new LocalizedString("Traducao", "Intro_0");
        textos[1] = new LocalizedString("Traducao", "Intro_1");
        textos[2] = new LocalizedString("Traducao", "Intro_2");
        textos[3] = new LocalizedString("Traducao", "Intro_3");
        textos[4] = new LocalizedString("Traducao", "Intro_4");

        nextText.onClick.AddListener(NextText);
        texto.text = "";
        nextText.gameObject.SetActive(false);
        StartCoroutine(Rotina());
    }

    public IEnumerator Rotina()
    {
        texto.text = "";
        // Busca o texto localizado antes de exibir
        var operation = textos[cont].GetLocalizedStringAsync();
        yield return operation;

        string textBuscado = operation.Result;

        foreach (char letter in textBuscado.ToCharArray())
        {
            texto.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        nextText.gameObject.SetActive(true);
    }

    public void NextText()
    {
        nextText.gameObject.SetActive(false);
        cont++;

        if(cont < textos.Length)
        {
            StartCoroutine(Rotina());
        }
        else
        {
            SceneManager.LoadScene("FaseIntrodutoria"); // Troca para a próxima cena
        }
    }
}
