using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponentInChildren<Text>();
        SetCurrentCore(0);
    }

    void OnEnable()
    {
        CrystalCollector.ScoreChanged += CrystalCollector_ScoreChanged;
    }


    void OnDisable()
    {
        CrystalCollector.ScoreChanged -= CrystalCollector_ScoreChanged;
    }

    private void CrystalCollector_ScoreChanged(int currentScore) =>
        SetCurrentCore(currentScore);

    private void SetCurrentCore(int currentScore) =>
        scoreText.text = $"x {currentScore}";
}
