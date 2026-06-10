using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//Essa classe é responsável por chamar as funções da Classe SaveAndLoad para salvar ou carregar as informações
//basicamente temos duas funções playersave() que é usada para salvar as informações e 
//função LoadPlayer() para carregar as informações 
//essas funções podem ser chamadas em botões para carregar ou salvar ou como desejar

public class SavePlayer : MonoBehaviour
{
    public Text txtTimeRun;
    public Text txtNumberLevel;
    public int level;
    public bool[] levelUnlocked = new bool[4];
    public float timeRun;
    public static bool loadSaveOnStart = true; // variável static usada no restart game para carregar a posição inicial e não fazer o load
    public static bool loadPosition = true; // variável static usada no next level game para carregar a posição inicial e não fazer o load


    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex - 4;
        levelUnlocked[0] = true;
        if (SaveAndLoad.SaveExists() /*&& loadSaveOnStart /*&& loadPosition*/)
        {
            LoadPlayer();

        }
        else
        {
            levelUnlocked = new bool[4];
            levelUnlocked[0] = true;
        }
        loadSaveOnStart = true;
        loadPosition = true;
        //txtTimeRun.text = timeRun.ToString("00");
        // txtNumberLevel.text = levelActive.ToString();
    }

    void Update()
    {
        timeRun += Time.deltaTime;

        // txtTimeRun.text = timeRun.ToString("00");

    }
    //Esse método é chamado no pause 
    //Quando o player deseja sair do game 
    public void PlayerSave()
    {
        level = SceneManager.GetActiveScene().buildIndex - 4;
        levelUnlocked[level] = true;
        SaveAndLoad.SavePlayer(this);
    }

    //Esse método é chamdo na classe NextLevelManager
    //Quando vamos trocar de cenas para a próxima fase
    //é necessário salvar o jogo antes da mudança 
    public void PlayerSaveNextLevel()
    {

        level = SceneManager.GetActiveScene().buildIndex - 4;
        if (level + 1 <= levelUnlocked.Length)
        {
            levelUnlocked[level] = true;
        }

        SaveAndLoad.SavePlayer(this);
    }

    public void LoadPlayer()
    {

        PlayerData data = SaveAndLoad.LoadPlayer();

        if (data == null)
        {
            Debug.Log("Nenhum save encontrado.");

            return;
        }
        level = data.level;
        levelUnlocked = data.levelUnlocked;
       

        timeRun = data.timeRun;
        int levelCurrent = SceneManager.GetActiveScene().buildIndex - 4;
        if (/*loadPosition*/ data.level == levelCurrent)
        {
            Vector3 pos;
            pos.x = data.position[0];
            pos.y = data.position[1];
            pos.z = data.position[2];

            transform.position = pos;

        }


    }


    public void LoadGame()
    {

        SceneManager.LoadScene(level);

    }


}
