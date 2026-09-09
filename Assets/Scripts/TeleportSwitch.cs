using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportSwitch : MonoBehaviour
{
    public InputActionReference action;
    public Transform rig;
    public Vector3 insidePosition = new Vector3(0f, 0f, 5f);
    public Vector3 outsidePosition = new Vector3(-40f, 0f, -15f);
    public Vector3 insideRotation = Vector3.zero;
    public Vector3 outsideRotation = new Vector3(0f, 75f, 0f);


    private bool outside = false;

    void Start()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            outside = !outside;
            rig.position = outside ? outsidePosition : insidePosition;

            rig.rotation = Quaternion.Euler(outside ? outsideRotation : insideRotation);
        };
    }
}