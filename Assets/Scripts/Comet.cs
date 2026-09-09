using UnityEngine;

public class Comet : MonoBehaviour
{
    public Transform attractor;
    public float gravity = 10f;
    public Vector3 velocity = new Vector3(0f, -0.85f, 0f);

    public float impactDistance = 1.15f;
    public float escapeDistance = 30f;

    public GameObject impactEffectPrefab;

    void Update()
    {
        Vector3 offset = transform.position - attractor.position;
        float distance = offset.magnitude;

        if (distance < impactDistance)
        {
            if (impactEffectPrefab != null)
                Instantiate(impactEffectPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
            return;
        }

        if (distance > escapeDistance)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 acceleration = -gravity * offset / Mathf.Pow(distance, 3);

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}