using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class SaveSlotManager : MonoBehaviour
{
    public static int currentSlot = 1;
    public GameObject panelConfirmDelete;
    public Animator transition;
    public float transitionTime = 1f;

    public void SlotSelect(int slotId)
    {
        currentSlot = slotId;
        StartCoroutine(LoadLevel("LevelSelect"));


    }

    public void DeleteSlotGame(int slotId)
    {
        currentSlot = slotId;
        panelConfirmDelete.SetActive(true);
    }
    public void ConfirmDeletethisSaveGame()
    {
        SaveAndLoad.DeleteAllSaveFiles();
        panelConfirmDelete.SetActive(false);

    }
    public void CancelDeletethisSaveGame()
    {
        panelConfirmDelete.SetActive(false);

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
