using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneDialog : MonoBehaviour
{
    [SerializeField] float typeSpeed;
    public AudioClip clickSound;
    public string[] sentences;
    public TMP_Text textArea;
    public GameObject continueButton;
    public GameObject mainMenuButton;
    private int index;


    void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textArea.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void NextSentence()
    {
        SFXSoundPlayer.Instance.PlaySoundEffect(clickSound);
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textArea.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textArea.text = "";
            continueButton.SetActive(false);
        }

    }

    void Update()
    {
        if (textArea.text == sentences[index] && index != sentences.Length - 1)
        {
            continueButton.SetActive(true);
        }
        else if (textArea.text == sentences[index] && index == sentences.Length - 1)
        {
            mainMenuButton.SetActive(true);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
