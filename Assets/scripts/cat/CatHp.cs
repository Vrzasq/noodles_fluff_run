using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHp : MonoBehaviour
{
    public static event Action<int> HpChange;

    [SerializeField] int hp = 3;

    void Awake()
    {
        var hpBar = FindObjectOfType<HpBar>();

        if (hpBar != null)
            hpBar.SetStartHp(hp);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hp--;
            OnHpChange();
        }
        if (Input.GetMouseButtonDown(1))
        {
            hp++;
            OnHpChange();
        }
    }

    private void OnHpChange()
    {
        HpChange?.Invoke(hp);
    }
}
