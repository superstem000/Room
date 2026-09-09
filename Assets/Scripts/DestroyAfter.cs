using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float seconds = 3f;
    void Start() { Destroy(gameObject, seconds); }
}