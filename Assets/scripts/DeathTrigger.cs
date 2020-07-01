using UnityEngine;

namespace Assets.scripts
{
    public class DeathTrigger : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            var killable = collision.attachedRigidbody.GetComponent<IKillableByDeathTrigger>();

            killable?.KillOnDeathTrigger();
        }
    }
}
