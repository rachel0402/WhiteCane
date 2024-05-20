using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class JsonParser
{
    public JsonExtension JsonExtension { get; private set; }

}
public partial class JsonParser 
{
    private void Allocate()
    {
        JsonExtension = new JsonExtension();
    }
    public void Initialize()
    {
        Allocate();
    }
}
public partial class JsonParser 
{
    public string LoadJsonToString(string path)
    {
        return Resources.Load<TextAsset>(path).ToString();
    }
    public T[] LoadFromJson<T>(string jsonPath)
    {
        return JsonExtension.FromJson<T>(LoadJsonToString(jsonPath));
    }
    public List<int> LoadNestedArrayToIndexList(string nestedArray)
    {
        List<int> indexList = new List<int>();

        string[] divideArray = nestedArray.Split(',');

        for (int index = 0; index < divideArray.Length; index++)
        {
            indexList.Add(int.Parse(divideArray[index]));
        }

        return indexList;
    }
}
