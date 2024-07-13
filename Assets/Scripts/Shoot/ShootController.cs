using KarpysDev.Fps.Bullet;

namespace KarpysDev.Fps.Shoot
{
    using UnityEngine;

    public class ShootController : MonoBehaviour
    {
        [SerializeField] private Camera m_AimCamera = null;
        [SerializeField] private Transform m_SpawnPoint = null;
        [SerializeField] private BaseBullet m_BulletPrefab = null;
        [SerializeField] private float m_BulletForce = 0;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShootBullet();
            }
        }

        private void ShootBullet()
        {
            Vector3 hitPoint = GetHitPoint();
            Vector3 spawnPosition = m_SpawnPoint.position;
            Vector3 direction = hitPoint - spawnPosition;

            BaseBullet bullet = Instantiate(m_BulletPrefab, spawnPosition, Quaternion.identity);
            bullet.ShootInDirection(direction.normalized, m_BulletForce);
        }

        private Vector3 GetHitPoint()
        {
            Ray ray = m_AimCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(ray, out RaycastHit hit))
                return hit.point;

            return ray.GetPoint(100);
        }
    }
}