using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JSONParser : MonoBehaviour
{
    private DataResources jsonData;
    public JSONParser(string filename)
    {

        TextAsset json = Resources.Load<TextAsset>(filename);

        this.jsonData = JsonUtility.FromJson<DataResources>(json.ToString());
    }
    public PlanetItem GetTextItem(string key)
    {
        PlanetItem item = jsonData.Items.Where(x => x.Key == key).FirstOrDefault();
        return item;
    }
}

[Serializable]
public class DataResources
{
    public List<PlanetItem> Items;
}

[Serializable]
public class PlanetItem
{
    public string Key;
    public float Distance;
    public float Size;
    public float Translation;
    public float Rotation;
}




