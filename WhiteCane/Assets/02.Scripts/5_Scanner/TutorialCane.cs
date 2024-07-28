using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialCane : MonoBehaviour
{
    //현재 코드는 set이라 다른곳에서 scanner 가 실행되면 안됨
    //그래서 오브젝트를 여러개 만들어두고 scan을 재사용 하는 형식으로 만들기

    [SerializeField]
    private GameObject scannerPrefab;

    [SerializeField]
    private Transform scannerTransform;


    private Scanner scanner;

    [SerializeField]
    private UnityEvent endEvent;

    private bool isFirst = true;
    public void Start()
    {
        MainSystem.Instance.ObjectManager.SetobjectHit(this);
        SetScannner();

    }
    private void SetScannner()
    {
        scannerPrefab = Instantiate(scannerPrefab, scannerTransform);
        scanner = scannerPrefab.GetComponent<Scanner>();
        scannerPrefab.SetActive(false);

    }

    public void ParticleEndCheck()
    {
        //씬로드
        Debug.Log("파티클 끝!");

        endEvent?.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isFirst)
        {
            scanner.Set_Origin(this.transform.position);
            scannerPrefab.SetActive(true);

            isFirst = false;
        }
    }
}
