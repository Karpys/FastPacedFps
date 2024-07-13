using UnityEngine;

namespace KarpysDev.Fps.Bullet
{
    public class BaseBullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody m_Rigidbody = null;

        public Rigidbody Rigidbody => m_Rigidbody;

        private bool m_CanCollide = true;

        public bool CanCollide => m_CanCollide;
        public void ShootInDirection(Vector3 direction,float force)
        {
            transform.forward = direction.normalized;
            m_Rigidbody.AddForce(direction.normalized * force,ForceMode.Impulse);
        }

        public void DisableCollision()
        {
            m_CanCollide = false;
        }

        public void Explode()
        {
            Destroy(gameObject);
        }
    }
}