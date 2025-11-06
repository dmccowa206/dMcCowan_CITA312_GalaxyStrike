using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedFX;
    [SerializeField] int hitPoints = 3;
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            Instantiate(destroyedFX, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
