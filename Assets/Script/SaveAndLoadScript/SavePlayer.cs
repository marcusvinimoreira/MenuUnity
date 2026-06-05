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
    public int levelMax;
    public float timeRun;

    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex - 4;

        if (SaveAndLoad.SaveExists())
        {
            LoadPlayer();
        }
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
        Debug.Log("Level salvo: " + level);

        SaveAndLoad.SavePlayer(this);
    }

    //Esse método é chamdo na classe NextLevelManager
    //Quando vamos trocar de cenas para a próxima fase
    //é necessário salvar o jogo 
    //e acrescentamos +1 no level para liber a próxima fase
    public void PlayerSaveNextLevel()
    {
        level = SceneManager.GetActiveScene().buildIndex - 4;
        level++; //acrescenta mais 1 no level para passar para o próximo nível e já salvar 
        Debug.Log("Level salvo next: " + level);
        if(levelMax < level)
        {
            levelMax = level;
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
        timeRun = data.timeRun;
        Vector3 pos;
        pos.x = data.position[0];
        pos.y = data.position[1];
        pos.z = data.position[2];

        transform.position = pos;


    }


    public void LoadGame()
    {

        SceneManager.LoadScene(level);

    }


}
