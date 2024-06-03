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

        public AudioClip audioClip;
    }
  
}
public partial class SoundData
{
    private Dictionary<string, SoundDataInformation> SoundDataInformationDictonary = default;
   
    const string soundFilePath = "Sound";

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
            SoundDataInformation soundDataInformation = soundDataInformationArray[index];

            soundDataInformation.audioClip = Resources.Load(soundFilePath+"/"+soundDataInformation.soundPath) as AudioClip;
            

            SoundDataInformationDictonary.Add(soundDataInformationArray[index].index, soundDataInformationArray[index]);
        }
    }


}
public partial class SoundData
{
    public AudioClip GetAudioClip(string narrationName)
    {

        Debug.Log("사운드 스탑도 만들어야해");
        return SoundDataInformationDictonary[narrationName].audioClip;
    }
}