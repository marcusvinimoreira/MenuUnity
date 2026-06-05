using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    //  private TransitionManager transitionManager;
    public Button[] levelButtons;
    //private GameManager gameManager;

    void Start()
    {

        //  gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //  transitionManager = GameObject.Find("Crossfade").GetComponent<TransitionManager>();
        PlayerData data = SaveAndLoad.LoadPlayer();
        if (data == null)
        {
            Debug.Log("Nenhum save encontrado.");

            return;
        }
        Debug.Log("Level ."+data.level);

        int levelReached = data.level;
        if (levelReached == 0)
        {
            levelReached = 1;
        }
       // int levelReached = PlayerPrefs.GetInt("levelReached", 1);


        for (int i = 0; i <levelButtons.Length; i++)
        {
            if (i + 1 >levelReached)
            {
                levelButtons[i].interactable = false;
            }

        }

    }


    public void Select(string levelName)
    {
        // PlayerPrefs.SetString("EnterNextLevel", "true");
        StartCoroutine(LoadLevel(levelName));
        // transitionManager.EffectTransiton(levelName);

    }

    IEnumerator LoadLevel(string levelIndex)
    {

        yield return new WaitForSeconds(0.5f);
        //Play animation
        //  transition.SetTrigger("start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene(levelIndex);

    }
}
