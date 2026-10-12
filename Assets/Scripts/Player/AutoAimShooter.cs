using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class AutoAimShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 0.25f;
    [SerializeField] private bool requireButtonToShoot = true; // Set to false if you want auto-fire only when enemies are present

    [Header("Targeting Settings")]
    [SerializeField] private float targetingRadius = 8f;
    [SerializeField] private LayerMask enemyLayer;

    private float fireTimer;

    private void Update()
    {
        fireTimer -= Time.deltaTime;

        Transform target = FindClosestEnemy();
        Vector2 aimDirection;

        // 1. Determine aim direction
        if (target != null)
        {
            aimDirection = (target.position - transform.position).normalized;
        }
        else
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            aimDirection = (mouseWorldPos - transform.position).normalized;
        }

        // 2. Rotate ONLY this WeaponPivot object (leaves player body untouched)
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // 3. Fire conditions check
        bool wantsToShoot = !requireButtonToShoot || Input.GetMouseButton(0) || Input.GetMouseButton(1);

        if (wantsToShoot && fireTimer <= 0f)
        {
            Shoot(aimDirection);
            fireTimer = fireRate;
        }
    }

    private Transform FindClosestEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, targetingRadius, enemyLayer);
        Transform closestEnemy = null;
        float closestDistanceSqr = float.PositiveInfinity;

        foreach (Collider2D enemyCollider in enemies)
        {
            Vector2 directionToEnemy = enemyCollider.transform.position - transform.position;
            float distanceSqr = directionToEnemy.sqrMagnitude;

            if (distanceSqr < closestDistanceSqr)
            {
                closestDistanceSqr = distanceSqr;
                closestEnemy = enemyCollider.transform;
            }
        }

        return closestEnemy;
    }

    private void Shoot(Vector2 direction)
    {
        if (bulletPrefab == null) return;

        Vector3 spawnPosition = firePoint != null ? firePoint.position : transform.position;

        GameObject newBullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        if (newBullet.TryGetComponent<Bullet>(out Bullet bulletComponent))
        {
            bulletComponent.Initialize(direction);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetingRadius);
    }
}