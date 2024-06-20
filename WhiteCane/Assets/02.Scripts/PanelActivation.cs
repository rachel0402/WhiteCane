using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivation : MonoBehaviour
{
    public GameObject panel;  // panel GameObject�� Inspector���� �Ҵ��ؾ� �մϴ�.
    private float activationTime = 3f;  // Ȱ��ȭ �ð� 3��

    private float timer;

    void Start()
    {
        panel.SetActive(true);  // ���� ���� �� panel�� Ȱ��ȭ�մϴ�.
        timer = 0f;  // Ÿ�̸� �ʱ�ȭ
    }

    void Update()
    {
        timer += Time.deltaTime;  // ��� �ð��� �����մϴ�.

        if (timer >= activationTime)
        {
            panel.SetActive(false);  // activationTime�� ������ panel�� ��Ȱ��ȭ�մϴ�.
        }
    }
}
