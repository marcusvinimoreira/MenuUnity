using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class BackScene : MonoBehaviour
{
    [SerializeField]
    private Button btnBackScene;
    public Animator transition;
    public float transitionTime = 1f;
    public string nameSceneBack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        btnBackScene = GameObject.Find("btnBack").GetComponent<Button>();
        btnBackScene.onClick.AddListener(BackSceneGame);
    }

    public void BackSceneGame()
    {

        SceneManager.LoadScene(nameSceneBack);
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
