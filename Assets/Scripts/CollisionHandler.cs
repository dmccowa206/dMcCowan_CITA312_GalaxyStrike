using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedFX;
    void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyedFX, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
