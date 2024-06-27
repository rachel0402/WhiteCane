using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//내가 정답인지 아닌지를 알려주기
// 내가 눌렸는지 안눌렸는지 알려주기

public partial class QuizOption : MonoBehaviour
{
    [SerializeField]
    private TMP_Text optionText;

    [SerializeField]
    private bool isTrue = true;
   
}
public partial class QuizOption : MonoBehaviour
{
    public void Check()
    {
        if(isTrue)
        {
            Debug.Log("이건 맞는 거임");
        }
        else
        {
           // MainSystem.Instance.DataManager.QuizData.QuizDataController.NextProblem();
            Debug.Log("맞았어용!! 다음문제로 ㄱㄱ");
        }
    }
}
public partial class QuizOption : MonoBehaviour
{
    //true or false
    public void SetOptionState(bool optionStateValue)
    {
        isTrue = optionStateValue;
    }
    //set text
    public void SetOptionInformationText(string optionValue)
    {
        optionText.text = optionValue;
    }
}