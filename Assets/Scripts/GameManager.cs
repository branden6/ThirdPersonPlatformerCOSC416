using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = $"Score: {score}";
    }

    // Update is called once per frame
    public void IncrementScore(){
        score++;
        scoreText.text = $"Score: {score}";
    }
}
