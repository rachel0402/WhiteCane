using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public partial class QuizData//json
{
	[Serializable]
	public class QuizDataInformation
	{
		public string quizName;
		public string problem;
		
		public string correctAnswer;

		public string soundPath;
		public AudioClip soundClip;
	}

	
}
public partial class QuizData
{
	private Dictionary<string, QuizDataInformation> QuizDataInformationDictonary = default;
	public QuizDataController QuizDataController { get; private set; } = default;
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

		for (int index = 0; index < quizDataInformationArray.Length; index++)
		{
			QuizDataInformationDictonary.Add(quizDataInformationArray[index].quizName, quizDataInformationArray[index]);

			//Debug.Log("오디오 소스 로드");
			quizDataInformationArray[index].soundClip = Resources.Load(quizDataInformationArray[index].soundPath) as AudioClip;
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

	public QuizDataInformation GetQuizObjectInformation(string quizIndexValue)
	{
		return QuizDataInformationDictonary[quizIndexValue];
	}
}