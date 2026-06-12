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
    public bool[] levelReached;
    //  private int levelReached;
    //private GameManager gameManager;

    void Start()
    {

        //  gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //  transitionManager = GameObject.Find("Crossfade").GetComponent<TransitionManager>();
        PlayerData data = SaveAndLoad.LoadPlayer();

        if (data != null && data.levelUnlocked != null)
        {
            levelReached = data.levelUnlocked;

        }
        else
        {
            levelReached = new bool[levelButtons.Length];
            levelReached[0] = true;
        }
        for (int i = 0; i < levelButtons.Length; i++)
        {
            Debug.Log(i + " Levele Reached: " + levelReached[i]);
        }

            for (int i = 0; i < levelButtons.Length; i++)
        {
            if (!levelReached[i])
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
