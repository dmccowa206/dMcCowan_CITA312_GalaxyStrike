using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject laser;
    bool isFiring = false;
    void Update()
    {
        ProcessFiring();
    }
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
    void ProcessFiring()
    {
        ParticleSystem.EmissionModule emissionModule = laser.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isFiring;
    }
}
