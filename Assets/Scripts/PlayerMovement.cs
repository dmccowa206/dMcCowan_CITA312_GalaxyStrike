using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Update()
    {

    }
    public void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
    }
}
