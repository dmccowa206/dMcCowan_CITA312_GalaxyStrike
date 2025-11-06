using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] GameObject player;
    Scorer scorer;
    int startingHP;
    void Start()
    {
        scorer = player.GetComponent<Scorer>();
        startingHP = hitPoints;
    }
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
            scorer.GainScore(startingHP);
        }
    }
}
