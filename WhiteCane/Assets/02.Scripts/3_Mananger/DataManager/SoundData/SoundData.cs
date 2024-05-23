using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public partial class SoundData//json
{
    [Serializable]
    public class SoundDataInformation
    {
        public string index;
        public string soundPath;
    }
  
}
public partial class SoundData
{
    private Dictionary<string, SoundDataInformation> SoundDataInformationDictonary = default;

}
public partial class SoundData
{
    private void Allocate()
    {
        SoundDataInformationDictonary = new Dictionary<string, SoundDataInformation>();
    }
    public void Initialize()
    {
        Allocate();
        Setup();
    }
    private void Setup()
    {
        JsonParser jsonParser = MainSystem.Instance.ParserManager.JsonParser;

        SoundDataInformation[] soundDataInformationArray = jsonParser.LoadFromJson<SoundDataInformation>("Json/SoundData");

        for (int index = 0; index < soundDataInformationArray.Length; index++)
        {
            SoundDataInformationDictonary.Add(soundDataInformationArray[index].index, soundDataInformationArray[index]);
        }
    }


}