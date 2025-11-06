using TMPro;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] float comboTime = 3f;
    [SerializeField] int comboMult = 1;
    [SerializeField] int comboIncrement = 1;
    [SerializeField] TextMeshProUGUI scoreText;
    float timeCheck = 0;
    void Update()
    {
        timeCheck += Time.deltaTime;
        if (timeCheck >= comboTime)
        {
            comboMult = 1;
            timeCheck = 0f;
        }
        scoreText.SetText($"Score: {score}");
    }
    public void GainScore(int enemyHealth)
    {
        score += enemyHealth * comboMult;
        comboMult += comboIncrement;
        timeCheck = 0;
    }
}
