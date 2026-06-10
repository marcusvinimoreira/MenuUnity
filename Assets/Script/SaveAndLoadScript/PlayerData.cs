using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Classe responsável por conter todas os dados que serão salvos no game como por exemplo: 
// vida do player; level; posição do player; tempo de jogo etc...
[System.Serializable]
public class PlayerData
{
    //estou pegando o número do level index(a cena que está aberta no momento do game para salvar)
    public int level; //= SceneManager.GetActiveScene().buildIndex;
    public bool[] levelUnlocked;
    public float timeRun;
    public float[] position;

    public PlayerData(SavePlayer player)
    {
        level = player.level;
        levelUnlocked = player.levelUnlocked;
        timeRun = player.timeRun;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;


    }
}
