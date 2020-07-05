using Assets.scripts.collectibles;
using System;
using UnityEngine;

public class CrystalCollector : MonoBehaviour
{
    public static event Action<int> ScoreChanged;

    public int Score { get; private set; } = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        var collectible = collision.GetComponent<ICollectible>();

        if (collectible != null)
        {
            Score += collectible.Points;
            collectible.Collect();
            OnScoreChanged();
        }
    }

    private void OnScoreChanged() =>
        ScoreChanged?.Invoke(Score);
}
