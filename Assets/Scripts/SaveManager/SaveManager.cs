using UnityEngine;
using System;
using System.Collections.Generic;


public class SaveManager
{
    private static SaveManager _instance = null;

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
        String prefix = "Save_";
        int save_id = 1;
        List<(String, int, float)> saves = new List<(String, int, float)>();

        while(checkSaveExists(prefix + save_id)) {
            (int level, float score) = getSave(prefix + save_id);

            saves.Add((prefix + save_id, level, score));
            save_id += 1;
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
        String prefix = "Save_";
        int save_id = 1;
        while (checkSaveExists(prefix + save_id)) {
            save_id += 1;
        }

        return prefix + save_id;
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