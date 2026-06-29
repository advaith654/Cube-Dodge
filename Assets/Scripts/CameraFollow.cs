using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Camera")]
    public Vector3 offset = new Vector3(0f, 25f, -18f);
    public float smoothSpeed = 6f;

    [Header("Dead Zone")]
    public float deadZoneX = 3f;
    public float deadZoneZ = 2f;

    private Vector3 focusPoint;
    private Quaternion startRotation;

    private void Start()
    {
        if (player == null)
            return;

        focusPoint = player.position;
        startRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        if (player == null)
            return;

        Vector3 playerPos = player.position;

        // Horizontal dead zone
        if (playerPos.x > focusPoint.x + deadZoneX)
            focusPoint.x = playerPos.x - deadZoneX;
        else if (playerPos.x < focusPoint.x - deadZoneX)
            focusPoint.x = playerPos.x + deadZoneX;

        // Vertical dead zone
        if (playerPos.z > focusPoint.z + deadZoneZ)
            focusPoint.z = playerPos.z - deadZoneZ;
        else if (playerPos.z < focusPoint.z - deadZoneZ)
            focusPoint.z = playerPos.z + deadZoneZ;

        Vector3 desiredPosition = focusPoint + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime);

        transform.rotation = startRotation;
    }
}