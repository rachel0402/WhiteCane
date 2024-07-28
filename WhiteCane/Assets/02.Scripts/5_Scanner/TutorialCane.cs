using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialCane : MonoBehaviour
{
    //���� �ڵ�� set�̶� �ٸ������� scanner �� ����Ǹ� �ȵ�
    //�׷��� ������Ʈ�� ������ �����ΰ� scan�� ���� �ϴ� �������� �����

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
        //���ε�
        Debug.Log("��ƼŬ ��!");

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
