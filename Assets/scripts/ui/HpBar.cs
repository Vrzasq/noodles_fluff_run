﻿using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private int hearthNumber = 3;

    private GameObject[] hearths;

    void Start()
    {
        hearths = new GameObject[hearthNumber];

        for (int i = 0; i < hearths.Length; i++)
            hearths[i] = Instantiate(heartPrefab, this.transform);
    }

    void OnEnable()
    {
        CatHp.HpChange += CatHp_HpLoss;
    }

    void OnDisable()
    {
        CatHp.HpChange -= CatHp_HpLoss;
    }


    public void SetStartHp(int hearthNumber)
        => this.hearthNumber = hearthNumber;

    public void CatHp_HpLoss(int currentHp)
    {
        for (int i = 0; i < hearths.Length; i++)
        {
            hearths[i].SetActive(currentHp > 0);
            currentHp--;
        }
    }
}
