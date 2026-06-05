using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{
    public Button btnPlay, btnConfigure, btnCredits, btnExit;
    public Animator transition;
    public float transitionTime = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Pegando os componentes dos botões
        btnPlay = GameObject.Find("btnPlay").GetComponent<Button>();
        btnConfigure = GameObject.Find("btnConfigure").GetComponent<Button>();
        btnCredits = GameObject.Find("btnCredits").GetComponent<Button>();
        btnExit = GameObject.Find("btnExit").GetComponent<Button>();

        //Add Evento nos botoes
        btnPlay.onClick.AddListener(PlayGame);
        btnConfigure.onClick.AddListener(ConfigureScene);
        btnCredits.onClick.AddListener(CreditsScene);
        btnExit.onClick.AddListener(ExitGame);



    }

    public void PlayGame()
    {


        StartCoroutine(LoadLevel("ContinueGame"));

    }
    public void ConfigureScene()
    {
        StartCoroutine(LoadLevel("Configure"));
    }

    public void CreditsScene()
    {
        StartCoroutine(LoadLevel("Credits"));
    }


    public void ExitGame()
    {

        Application.Quit();
    }

    IEnumerator LoadLevel(string levelIndex)
    {

        yield return new WaitForSeconds(0.5f);
        //Play animation
        //
       // transition.SetTrigger("start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene(levelIndex);

    }


}
