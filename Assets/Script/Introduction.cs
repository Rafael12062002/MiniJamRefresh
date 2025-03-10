using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{
    string[] textos = new string[5];
    public TextMeshProUGUI texto;
    int cont = 0;
    public Button nextText;
    public float typingSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        textos[0] = "O mundo e os seres humanos conseguiram viver em uma utopia cibernetica colocando sua consciencia em chips controlada por uma matriz na qual é super protegida por maquinas...";
        textos[1] = "...Mas toda a humanidade corre risco por uma falha desconhecida na matriz, agora todas as consciencias e o mundo cibernetico podem desaparecer...";
        textos[2] = "...Todos que tentaram chegar perto da matriz para concertar falharam miseravelmente, pois as maquinas foram programadas para proteger a matriz mão importa o motivo...";
        textos[3] = "...Pórem você que foi um dos cientistas a fazer a descoberta e implementar a utopia no mundo tem um plano, mas não será facil passar das maquinas...";
        textos[4] = "Não tive tempo de gerar as imagens para a historia, desculpe :)";

        nextText.onClick.AddListener(NextText);
        texto.text = "";
        nextText.gameObject.SetActive(false);
        StartCoroutine(Rotina());
    }

   public IEnumerator Rotina()
   {
        texto.text = "";

        foreach(char letter in textos[cont].ToCharArray())
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
