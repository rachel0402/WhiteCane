using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 offset;
    public float followSpeed = 10.0f;

    void Update()
    {
        // ��ǥ ��ġ ���: ī�޶� ��ġ + �ణ�� ������
        Vector3 targetPosition = cameraTransform.position + cameraTransform.forward * offset.z + cameraTransform.up * offset.y + cameraTransform.right * offset.x;

        // �޴��� ��ǥ ��ġ�� �ε巴�� �̵�
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // �޴��� �׻� �÷��̾ �ٶ󺸵��� ����
        transform.LookAt(transform.position + cameraTransform.rotation * Vector3.forward, cameraTransform.rotation * Vector3.up);
    }
}