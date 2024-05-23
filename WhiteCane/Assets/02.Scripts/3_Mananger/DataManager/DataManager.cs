using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DataManager : MonoBehaviour
{
	public NarrationData NarrationData { get; private set; } = default;
	public QuizData QuizData { get; private set; } = default;
	public SoundData SoundData { get; private set; } = default;
}
public partial class DataManager : MonoBehaviour
{
    private void Allocate()
    {
        NarrationData = new NarrationData();
        QuizData = new QuizData();
        SoundData = new SoundData();
    }
    public void Initialize()
    {
        Allocate();
        NarrationData.Initialize();
        QuizData.Initialize();
        SoundData.Initialize();
    }
}
