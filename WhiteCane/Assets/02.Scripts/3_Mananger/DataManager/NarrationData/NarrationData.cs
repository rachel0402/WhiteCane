 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class NarrationData//JSON
{
	[Serializable]
	public class NarrationDataInformation
	{
		public string index;
		public string narrationText;

	}
}
public partial class NarrationData //DATA FEILD
{
	private Dictionary<string, NarrationDataInformation> narrationDataInformationDictonary= default;

	public UINarrationController UINarrationController { get; private set; } = default;
}
public partial class NarrationData //Initialize
{
	
	private void Allocate()
	{
		narrationDataInformationDictonary = new Dictionary<string, NarrationDataInformation>();
	}
	public void Initialize()
	{
		Allocate();
		Setup();
	}

	private void Setup()
	{
		JsonParser jsonParser = MainSystem.Instance.ParserManager.JsonParser;


		NarrationDataInformation[] narrationDataInformationArray = jsonParser.LoadFromJson<NarrationDataInformation>("Json/NarrationData");


		for (int index = 0; index < narrationDataInformationArray.Length; index++)
		{
			narrationDataInformationDictonary.Add(narrationDataInformationArray[index].index, narrationDataInformationArray[index]);
		}
	}
	public NarrationDataInformation GetNarrationDatInformation(string index)
	{
		return narrationDataInformationDictonary[index];
	}
}
public partial class NarrationData //Get
{
	public void DynamicAllocate_UINarrationController(UINarrationController UINarrationControllerValue)
	{
		UINarrationController = UINarrationControllerValue;
		UINarrationController.Initialize();
	}
	public NarrationDataInformation GetNarrationInformation(string index)
	{
		return narrationDataInformationDictonary[index];
	}

	public String GetNarration(string index)
	{
		return narrationDataInformationDictonary[index].narrationText;
	}


	public List<NarrationDataInformation> GetNarrationDataInformationList()
	{
		return new List<NarrationDataInformation>(narrationDataInformationDictonary.Values);
	}
}