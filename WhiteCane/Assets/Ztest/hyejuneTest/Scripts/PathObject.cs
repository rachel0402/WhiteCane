using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class PathObject : MonoBehaviour
{
    [SerializeField]
    private bool isExit = false;

    [SerializeField]
    private bool isPathActive = false;

    [SerializeField]
    private List<PathObject> nextPathObjectList = new List<PathObject>();

    [SerializeField]
    private UnityEvent activeEvent;
    [SerializeField]
    private UnityEvent deactiveEvent;
    [SerializeField]
    private UnityEvent finishEvent;

    [SerializeField]
    MeshRenderer meshRenderer;

    [SerializeField]
    Material selectMaterial;
}
public partial class PathObject : MonoBehaviour
{
    //퀴즈를 불러올때 그냥 자기 문제에 대한 
    public void Active()
    {
        if (isExit == false)
        {
            //이건 그냥 시각화 할려구 넣어둔 코드
            meshRenderer.material = selectMaterial;
           // SetProblem("Test__Quiz_01");

            isPathActive = true;
            activeEvent?.Invoke();
        }
        else
        {
            Debug.Log("마지막이에열");
            Finish();
        }
    }
    public void Deactive()
    {
        deactiveEvent?.Invoke();
    }

    public void Finish()
    {
        finishEvent?.Invoke();
    }

   // QuizData.QuizDataInformation QuizDataobj;

  //  public void SetProblem(string myindex)
 //   {
      //  QuizDataobj = MainSystem.Instance.DataManager.QuizData.GetQuizObjectInformation(myindex);
 //   }
    public void NextPathObjectActive()
    {


        for (int i = 0; i < nextPathObjectList.Count; i++)
        {
            //얘가 false여야지만 active 하기
            //왔던애라면 다시 갈필요없기 떄문에

            if (nextPathObjectList[i].isPathActive ==false)
            {
                nextPathObjectList[i].Active();
            }
        }
    }
}
