using UnityEngine;
using UnityEngine.InputSystem;

public class BulletSpawner : MonoBehaviour
{
    public InputActionReference action;
    public GameObject bulletPrefab;
    public Transform controller;

    public float spawnOffset = 0.2f;
    public float speed = 8f;

    void Start()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            Vector3 dir = controller.forward;
            Vector3 pos = controller.position + dir * spawnOffset;

            GameObject b = Instantiate(bulletPrefab, pos, Quaternion.LookRotation(dir));
            b.GetComponent<Comet>().velocity = dir * speed;
        };
    }
}