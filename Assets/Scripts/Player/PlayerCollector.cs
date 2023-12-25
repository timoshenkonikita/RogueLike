using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats stats;
    public CircleCollider2D collector;
    public float pullSpeed;

    private void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        collector = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        collector.radius = stats.currentMagnet;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //проверяет gameObject на наличие интерфейса ICollectable и вызывает метод сбора если условие совпадает
        if (col.gameObject.TryGetComponent(out ICollectable collectable))
        {
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            Vector2 forceDirection = (transform.position - col.transform.position).normalized;
            rb.AddForce(forceDirection * pullSpeed);

            collectable.Collect();
        }
    }
}
