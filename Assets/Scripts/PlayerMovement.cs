using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 25f;
    [SerializeField] float yClampRange = 15f;
    [SerializeField] float yClampBuffer = 10f;

    [SerializeField] float controlRollFactor = 30f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float controlPitchFactor = 25f;

    Vector2 movement;
    void Start()
    {
    }
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange + yClampBuffer, yClampRange + yClampBuffer);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
    void ProcessRotation()
    {
        float pitch = -controlPitchFactor * movement.y;
        float roll = -controlRollFactor * movement.x;
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
