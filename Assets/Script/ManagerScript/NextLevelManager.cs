using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLevelManager : MonoBehaviour
{
    public SavePlayer savePlayer;
    public GameObject nextLevelUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextLevelUI.SetActive(false);

        savePlayer = GameObject.Find("Player").GetComponent<SavePlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("NextLevel");
            nextLevelUI.SetActive(true);
            savePlayer.PlayerSaveNextLevel();
        }
    }

    public void Select(string levelName)
    {
        StartCoroutine(LoadLevel(levelName));
        // transitionManager.EffectTransiton(levelName);

    }
    IEnumerator LoadLevel(string levelIndex)
    {

        yield return new WaitForSeconds(0.5f);
        //Play animation
        //  transition.SetTrigger("start");
        //Wait
        yield return new WaitForSeconds(0.5f);
        //Load scene
        SceneManager.LoadScene(levelIndex);

    }
}
