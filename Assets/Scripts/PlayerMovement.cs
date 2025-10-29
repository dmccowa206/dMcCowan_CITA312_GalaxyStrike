using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 20f;
    [SerializeField] float xClampRange = 25f;
    [SerializeField] float yClampRange = 15f;
    [SerializeField] float yClampBuffer = 10f;

    [SerializeField] float controlRollFactor = 30f;
    [SerializeField] float rotationSpeed = 4f;
    [SerializeField] float controlPitchFactor = 25f;

    [SerializeField] float controlBoost = 10f;

    Vector2 movement;
    float currentSpeed;
    void Start()
    {
        currentSpeed = controlSpeed;
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
    public void OnBoost(InputValue value)
    {
        if (value.Get() != null)
        {
            currentSpeed = controlSpeed + controlBoost;
        }
        else
        {
            currentSpeed = controlSpeed;
        }
        Debug.Log(value.Get());
    }
    void ProcessTranslation()
    {
        float xOffset = movement.x * currentSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * currentSpeed * Time.deltaTime;
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
