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
    //��� �ҷ��ö� �׳� �ڱ� ������ ���� 
    public void Active()
    {
        if (isExit == false)
        {
            //�̰� �׳� �ð�ȭ �ҷ��� �־�� �ڵ�
            meshRenderer.material = selectMaterial;
           // SetProblem("Test__Quiz_01");

            isPathActive = true;
            activeEvent?.Invoke();
        }
        else
        {
            Debug.Log("�������̿���");
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
            //�갡 false�������� active �ϱ�
            //�Դ��ֶ�� �ٽ� ���ʿ���� ������

            if (nextPathObjectList[i].isPathActive ==false)
            {
                nextPathObjectList[i].Active();
            }
        }
    }
}
