using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private bool isInverted;

    private void LateUpdate()
    {
        if (isInverted)
        {
            Vector3 directionToTheCamera = (cameraTransform.position - transform.position).normalized;
            transform.LookAt(transform.position + directionToTheCamera * -1);
        }
        else
        {
            transform.LookAt(cameraTransform);
        }
    }
}
