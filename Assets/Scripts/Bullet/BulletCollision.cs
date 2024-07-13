using System;
using KarpysDev.KarpysUtils;
using UnityEngine;

namespace KarpysDev.Fps.Bullet
{
    public class BulletCollision : MonoBehaviour
    {
        [SerializeField] private BaseBullet m_BaseBullet = null;

        private void OnCollisionEnter(Collision other)
        {
            if (!m_BaseBullet.CanCollide)
                return;
            
            IBulletCollision bulletCollision = other.gameObject.GetComponent<IBulletCollision>();
            bulletCollision?.OnCollide();
            m_BaseBullet.Explode();
            m_BaseBullet.DisableCollision();
        }
    }
}