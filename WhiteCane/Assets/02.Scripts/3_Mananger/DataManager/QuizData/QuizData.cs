using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public partial class QuizData//json
{
	[Serializable]
	public class QuizDataInformation
	{
		public string index;
		public string problem;

		public string option_01;
		public string option_02;
		public string option_03;

		public int wrongOption;
	}
}
public partial class QuizData
{
	private Dictionary<string, QuizDataInformation> QuizDataInformationDictonary = default;
	public QuizDataController QuizDataController{ get; private set; } = default;
}
public partial class QuizData
{
	private void Allocate()
    {
		QuizDataInformationDictonary = new Dictionary<string, QuizDataInformation>();
	}
	public void Initialize()
	{
		Allocate();
		Setup();
	}

	private void Setup()
    {
		JsonParser jsonParser = MainSystem.Instance.ParserManager.JsonParser;

		QuizDataInformation[] quizDataInformationArray = jsonParser.LoadFromJson<QuizDataInformation>("Json/QuizData");

		for(int index =0; index< quizDataInformationArray.Length; index++)
        {
			QuizDataInformationDictonary.Add(quizDataInformationArray[index].index, quizDataInformationArray[index]);
		}

	}

}
public partial class QuizData
{
	public void DynamicAllocate_QuizDataController(QuizDataController QuizDataControllerValue)
	{
		QuizDataController = QuizDataControllerValue;
		QuizDataController.Initialize();
	}

	public List<QuizDataInformation> GetQuizDataInformationList()
    {
		return new List<QuizDataInformation>(QuizDataInformationDictonary.Values);
	}
}