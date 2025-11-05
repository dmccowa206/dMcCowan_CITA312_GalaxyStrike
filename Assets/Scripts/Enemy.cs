using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedFX;
    void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyedFX, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
