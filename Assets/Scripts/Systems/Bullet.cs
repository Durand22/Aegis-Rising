using System.Collections; // Required for IEnumerator
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float speed = 20f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float lifetime = 3f;

    private Vector2 moveDirection;
    private Coroutine lifetimeRoutine;

    public void Initialize(Vector2 direction)
    {
        moveDirection = direction.normalized;

        // Rotate sprite towards flight direction
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Start lifetime countdown timer
        lifetimeRoutine = StartCoroutine(LifetimeTimer());
    }

    private void Update()
    {
        transform.position += (Vector3)moveDirection * (speed * Time.deltaTime);
    }

    private IEnumerator LifetimeTimer()
    {
        yield return new WaitForSeconds(lifetime);
        DestroyBullet();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            DestroyBullet();
        }
        else if (other.CompareTag("Obstacle"))
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        if (lifetimeRoutine != null)
        {
            StopCoroutine(lifetimeRoutine);
        }

        Destroy(gameObject);
    }


  
}