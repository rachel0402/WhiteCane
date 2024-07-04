using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//���� �������� �ƴ����� �˷��ֱ�
// ���� ���ȴ��� �ȴ��ȴ��� �˷��ֱ�

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
            Debug.Log("�̰� �´� ����");
        }
        else
        {
           // MainSystem.Instance.DataManager.QuizData.QuizDataController.NextProblem();
            Debug.Log("�¾Ҿ��!! ���������� ����");
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