using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private void LateUpdate() {
        Vector3 targetPosition = target.position + offset;
        targetPosition.x = 0;
        transform.position = targetPosition;
    }
}