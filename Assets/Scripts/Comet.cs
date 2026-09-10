using UnityEngine;

public class Comet : MonoBehaviour
{
    public Transform attractor;
    public bool useGravity = true;
    public float gravity = 10f;
    public Vector3 velocity = new Vector3(0f, -0.85f, 0f);

    public float impactDistance = 1.15f;
    public float escapeDistance = 30f;
    public float lifetime = 0f;

    public GameObject impactEffectPrefab;

    private float age = 0f;

    void Update()
    {
        if (lifetime > 0f)
        {
            age += Time.deltaTime;
            if (age >= lifetime)
            {
                Explode(transform.position);
                return;
            }
        }

        if (useGravity && attractor != null)
        {
            Vector3 offset = transform.position - attractor.position;
            float distance = offset.magnitude;

            if (distance < impactDistance)
            {
                Explode(transform.position);
                return;
            }

            if (distance > escapeDistance)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 acceleration = -gravity * offset / Mathf.Pow(distance, 3);
            velocity += acceleration * Time.deltaTime;
        }

        transform.position += velocity * Time.deltaTime;
    }

    void Explode(Vector3 position)
    {
        if (impactEffectPrefab != null)
            Instantiate(impactEffectPrefab, position, Quaternion.identity);

        Destroy(gameObject);
    }
}