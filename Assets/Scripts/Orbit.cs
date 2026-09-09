using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float degreesPerSecond = 30f;

    void Update()
    {
        transform.Rotate(Vector3.up, degreesPerSecond * Time.deltaTime);
    }
}