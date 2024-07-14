using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 offset;
    public float followSpeed = 10.0f;

    void Update()
    {
        // 목표 위치 계산: 카메라 위치 + 약간의 오프셋
        Vector3 targetPosition = cameraTransform.position + cameraTransform.forward * offset.z + cameraTransform.up * offset.y + cameraTransform.right * offset.x;

        // 메뉴를 목표 위치로 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // 메뉴가 항상 플레이어를 바라보도록 조정
        transform.LookAt(transform.position + cameraTransform.rotation * Vector3.forward, cameraTransform.rotation * Vector3.up);
    }
}