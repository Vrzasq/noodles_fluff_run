using System;
using UnityEngine;

namespace Assets.scripts.cat
{
    public class CatController : MonoBehaviour, IKillableByDeathTrigger
    {
        public static event Action OnDeath;

        public void KillOnDeathTrigger()
        {
            Debug.Log("Killed by death trigger");
            OnDeath?.Invoke();
        }
    }
}
