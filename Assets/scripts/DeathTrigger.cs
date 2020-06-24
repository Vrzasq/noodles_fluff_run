using UnityEngine;

namespace Assets.scripts
{
    public class DeathTrigger : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            var killable = collision.gameObject.GetComponent<IKillableByDeathTrigger>();

            if (killable == null)
                killable = collision.gameObject.GetComponentInParent<IKillableByDeathTrigger>();

            killable?.KillOnDeathTrigger();
        }
    }
}
