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
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, -controlRollFactor * movement.x);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
