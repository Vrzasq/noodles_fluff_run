using Assets.scripts.collectibles;
using UnityEngine;

public class CollectibleCrystal : MonoBehaviour, ICollectible
{
    [SerializeField] int points;
    public int Points => points;

    void OnEnable()
    {
        CrystalCollector.CollectibleCollected += OnCollect;
    }

    void OnDisable()
    {
        CrystalCollector.CollectibleCollected -= OnCollect;
    }

    private ICollectible OnCollect()
    {
        gameObject.SetActive(false);
        return this;
    }
}
