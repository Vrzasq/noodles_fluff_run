using Assets.scripts.collectibles;
using UnityEngine;

public class CollectibleCrystal : MonoBehaviour, ICollectible
{
    [SerializeField] int points;
    public int Points => points;

    void ICollectible.Collect() =>
        gameObject.SetActive(false);
}
