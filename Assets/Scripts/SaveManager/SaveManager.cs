using UnityEngine;
using System;
using System.Collections.Generic;


public class SaveManager
{
    private static SaveManager _instance = null;
    
    private static int MAX_SAVES = 10;
    private static String PREFIX = "Save_";

    public static SaveManager Instance { get { 
        if (_instance == null)
            _instance = new SaveManager();
        
        return _instance;
    } }

    private static JsonDataService dataService = new JsonDataService();
    private String current_saveName;

    private SaveManager()
    {
        current_saveName = getNextNewSave();
    }

    public String getCurrentSaveName()
    {
        return current_saveName;
    }

    public void updateCurrentSave((int, float) saveData)
    {
        updateSave(current_saveName, saveData);
    }

    public static List<(String, int, float)> getAllSaves()
    {
        int save_id = 0;
        List<(String, int, float)> saves = new List<(String, int, float)>();

        while(++save_id <= MAX_SAVES) {
            if (!checkSaveExists(PREFIX + save_id))
                continue;
                
            (int level, float score) = getSave(PREFIX + save_id);

            saves.Add((PREFIX + save_id, level, score));
        }

        return saves;
    }


    public static (int, float) defaultStartSave()
    {
        return (1, 0f);
    }

    private static bool checkSaveExists(String saveName)
    {
        return dataService.FileExists(saveName);
    }

    public String getNextNewSave()
    {
        int save_id = 1;
        while (checkSaveExists(PREFIX + save_id)) {
            save_id += 1;
        }

        return PREFIX + save_id;
    }

    public void setCurrentSave(String saveName)
    {
        current_saveName = saveName;
    }

    public void deleteSave(String saveName)
    {
        dataService.DeleteFile(saveName);
    }

    private static void updateSave(String saveName, (int, float) saveData)
    {
        Debug.Log("Saving: " + saveName);

        dataService.SaveData(saveName, saveData);
    }

    private static (int, float) getSave(String saveName) 
    {
        return dataService.LoadData<(int, float)>(saveName);
    }
}