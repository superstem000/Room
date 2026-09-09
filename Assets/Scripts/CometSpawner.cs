using UnityEngine;
using UnityEngine.InputSystem;

public class CometSpawner : MonoBehaviour
{
    public InputActionReference action;
    public GameObject cometPrefab;
    public Transform planet;

    public Vector3 baseOffset = new Vector3(0f, 0f, 5f);
    public Vector3 baseVelocity = new Vector3(0f, -0.85f, 0f);

    void Start()
    {
        action.action.Enable();
        action.action.performed += (ctx) => Spawn();
    }

    void Spawn()
    {
        float angle = Random.Range(0f, 360f);
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);

        Vector3 offset = rot * baseOffset;
        Vector3 vel = rot * baseVelocity;

        GameObject comet = Instantiate(cometPrefab, planet.position + offset, Quaternion.identity);

        Comet c = comet.GetComponent<Comet>();
        c.attractor = planet;
        c.velocity = vel;
    }
}