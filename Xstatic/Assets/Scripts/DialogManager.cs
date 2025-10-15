using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class DialogManager : MonoBehaviour
{
    [SerializeField] float typeSpeed;
    [SerializeField] GameObject cutSceneDirector;
    [SerializeField] GameObject skipButton;
    [SerializeField] GameObject audioManager;
    public AudioClip clickSound;
    public string[] sentences;
    public TMP_Text textArea;
    public GameObject continueButton;
    public GameObject startGameButton;
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

    public void LoadGameScene()
    {
        textArea.gameObject.SetActive(false);
        audioManager.SetActive(false);
        skipButton.SetActive(false);
        cutSceneDirector.SetActive(true);
    }

    public void SkipCutScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
 
    void Update()
    {
        if (textArea.text == sentences[index] && index != sentences.Length - 1)
        {
            continueButton.SetActive(true);
        }
        else if (textArea.text == sentences[index] && index == sentences.Length - 1)
        {
            startGameButton.SetActive(true);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
