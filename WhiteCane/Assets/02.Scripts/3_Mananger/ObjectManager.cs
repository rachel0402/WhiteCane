using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ObjectManager : MonoBehaviour
{
   public QuizObject quizObject;
    public bool quizAcitve = false;
}
public partial class ObjectManager : MonoBehaviour
{
    private void Allocate()
    {
    }
    public void Initialize()
    {
        Allocate();
    }
}
public partial class ObjectManager : MonoBehaviour
{
    public void SetQuizObject(QuizObject quizObjectValue)
    {
        quizObject = quizObjectValue;
        quizAcitve = true;
    }
}