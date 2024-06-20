using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivation : MonoBehaviour
{
    public GameObject panel;  // panel GameObject를 Inspector에서 할당해야 합니다.
    private float activationTime = 3f;  // 활성화 시간 3초

    private float timer;

    void Start()
    {
        panel.SetActive(true);  // 게임 시작 시 panel을 활성화합니다.
        timer = 0f;  // 타이머 초기화
    }

    void Update()
    {
        timer += Time.deltaTime;  // 경과 시간을 누적합니다.

        if (timer >= activationTime)
        {
            panel.SetActive(false);  // activationTime이 지나면 panel을 비활성화합니다.
        }
    }
}
