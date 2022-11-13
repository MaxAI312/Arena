using UnityEngine;

public class HealthBarLookAtCameraRotator : MonoBehaviour
{
    private Transform _cameraTransform;

    private void Start()
    {
        if (Camera.main != null) _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        transform.rotation = _cameraTransform.rotation;
    }
}
