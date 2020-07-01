using Assets.scripts.collectibles;
using System;
using UnityEngine;

public class CrystalCollector : MonoBehaviour
{
    public static event Action<int> ScoreChanged;
    public static event Func<ICollectible> CollectibleCollected;

    public int Score { get; private set; } = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectible"))
        {
            int? points = CollectibleCollected?.Invoke().Points;

            if (points.HasValue)
            {
                Score += points.Value;
                OnScoreChanged();
            }
        }
    }

    private void OnScoreChanged()
    {
        ScoreChanged?.Invoke(Score);
        Debug.Log(Score);
    }
}
