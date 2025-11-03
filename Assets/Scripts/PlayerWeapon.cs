using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;
    bool isFiring = false;
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
    }
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
    void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            ParticleSystem.EmissionModule emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }
    void MoveCrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }
    void MoveTargetPoint()
    {
        Vector3 targetPointPos = new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPos);
    }
}
