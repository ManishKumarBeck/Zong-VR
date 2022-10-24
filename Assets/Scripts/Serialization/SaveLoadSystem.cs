using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveLoadSystem : MonoBehaviour
{


    private static SaveLoadSystem instance;
    public static SaveLoadSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SaveLoadSystem();
            }

            return instance;
        }
    }


    public string savePath => $"{Application.persistentDataPath}/save.txt";

    [ContextMenu("Save")]
    public void Save()
    {
        var state = LoadFile();
        SaveState(state);
        SaveFile(state);
    }

    [ContextMenu("Load")]
    public void Load()
    {
        var state = LoadFile();
        LoadState(state);

    }

    public void SaveFile(object state)
    {
        using (var stream = File.Open(savePath, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
        }
    }


    Dictionary<string, object> LoadFile()
    {
        if(!File.Exists(savePath))
        {
            Debug.Log("No save File Found");
            return new Dictionary<string, object>();
        }

        using(FileStream stream = File.Open(savePath, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            return (Dictionary<string, object>)formatter.Deserialize(stream);
        }
    }


    void SaveState(Dictionary<string, object> state)
    {
        foreach(var saveable in FindObjectsOfType<SaveableEntity>())
        {
            state[saveable.ID] = saveable.SaveState();
        }
    }

    void LoadState(Dictionary<string, object> state)
    {

        foreach (var saveable in FindObjectsOfType<SaveableEntity>())
        {
            if(state.TryGetValue(saveable.ID, out var savedState))
            {
                saveable.LoadState(savedState);
            }
        }

    }
}
