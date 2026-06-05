using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


//Classe responsável por salvar, deletar e carregar as informações do jogo
//Essa classe cria um caminha dentro do jogo para armazenar o que será salvo 
//Além de salvar ela converte para binário as informações para ficar mais segura
//chamamos as funções de SavePlayer quando queremos salvar - nesse processo ela acessa as variáveis da classe SavePlayer para converter
//Função que está nessa classe é chamada pela classe SavePlayer que está dentro do game no Player para salvar ou carregar as infomações

public static class SaveAndLoad
{
    public static void SavePlayer(SavePlayer player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        // string path = Application.persistentDataPath + "/player.fun";
        string path = Application.persistentDataPath + "/player" + SaveSlotManager.currentSlot + ".fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();


    }

    public static PlayerData LoadPlayer()
    {
        //string path = Application.persistentDataPath + "/player.fun";
        string path = Application.persistentDataPath + "/player" + SaveSlotManager.currentSlot + ".fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;


        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;

        }

    }

    public static void DeleteAllSaveFiles()
    {

        // string path = Application.persistentDataPath + "/player.fun";
        string path = Application.persistentDataPath + "/player" + SaveSlotManager.currentSlot + ".fun";

        File.Delete(path);
    }
    public static bool SaveExists()
    {
        string path = Application.persistentDataPath + "/player" + SaveSlotManager.currentSlot + ".fun";

        return File.Exists(path);
    }

}
