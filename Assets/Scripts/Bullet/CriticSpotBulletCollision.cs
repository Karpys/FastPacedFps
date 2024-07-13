using UnityEngine;

namespace KarpysDev.Fps.Bullet
{
    public class CriticSpotBulletCollision : MonoBehaviour,IBulletCollision
    {
        private CriticSpotCollisionGroup m_Group = null;
        public void OnCollide()
        {
            m_Group.RemoveSpot(this);
            Explode();
        }

        public void AssignGroup(CriticSpotCollisionGroup group)
        {
            m_Group = group;
        }

        private void Explode()
        {
            Destroy(gameObject);
        }
    }
}