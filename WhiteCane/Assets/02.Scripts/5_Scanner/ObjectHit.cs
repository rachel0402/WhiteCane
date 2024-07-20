using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectHit : MonoBehaviour
{
    //���� �ڵ�� set�̶� �ٸ������� scanner �� ����Ǹ� �ȵ�
    //�׷��� ������Ʈ�� ������ �����ΰ� scan�� ���� �ϴ� �������� �����

    [SerializeField]
    private GameObject scannerPrefab;

    [SerializeField]
    private Transform scannerTransform;

    [SerializeField]
    private List<Scanner> scannerList = new List<Scanner>();
    [SerializeField]
    private List<GameObject> scannerObjectList = new List<GameObject>();

    private int maxScanner = 5;
    private int currentIndex = 0;

    [SerializeField]
    private UnityEvent activeEvent;

    public void Start()
    {
        SetScannner();
    }


    public void SetScannner()
    {
        for (int i = 0; i < maxScanner; i++)
        {
            GameObject scannerObject = Instantiate(scannerPrefab, scannerTransform);
            Scanner scanner = scannerObject.GetComponent<Scanner>();
            scannerObject.SetActive(false);
            scannerObjectList.Add(scannerObject);
            scannerList.Add(scanner);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currentIndex < maxScanner)
        {
            Debug.Log(currentIndex);

            scannerObjectList[currentIndex].SetActive(true);
            scannerList[currentIndex].Set_Origin(this.transform.position);

            currentIndex++;

        }
        else
        {
            Debug.Log(currentIndex);

            ////�ʱ�ȭ, �� ���ֱ�
            //for (int i = 0; i < maxScanner; i++)
            //{
            //    scannerObjectList[i].SetActive(false);
            //}
            
            currentIndex = 0;

            scannerList[currentIndex].Set_Origin(this.transform.position);

        }
        activeEvent?.Invoke();
    }
}
