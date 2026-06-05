using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PauseMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Button btnResume, btnLevelSelect, btnQuit;
    public SavePlayer savePlayer;

    // Start is called before the first frame update
    void Start()
    {
        savePlayer = GameObject.Find("Player").GetComponent<SavePlayer>();


        // transitionManager = GameObject.Find("Crossfade").GetComponent<TransitionManager>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }

    }
    public void Resume()
    {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void SaveAndQuit()
    {

        Time.timeScale = 1f;
        savePlayer.PlayerSave();
        StartCoroutine(LoadLevel("Menu"));
    }


    public void LevelSelectPanel()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel("LevelSelect"));

    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        string currentSceneIndex = SceneManager.GetActiveScene().name;
        Debug.Log(currentSceneIndex);
        StartCoroutine(LoadLevel(currentSceneIndex));

    }

    IEnumerator LoadLevel(string levelIndex)
    {

        yield return new WaitForSeconds(0.5f);
        //Play animation
        // transition.SetTrigger("start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene(levelIndex);

    }
}
