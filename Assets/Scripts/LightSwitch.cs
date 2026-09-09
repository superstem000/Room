using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public InputActionReference action;

    private Light pointLight;
    private Color[] colors = { Color.white, Color.red, Color.green, Color.blue, Color.yellow };
    private int index = 0;

    void Start()
    {
        pointLight = GetComponent<Light>();

        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            index = (index + 1) % colors.Length;
            pointLight.color = colors[index];
        };
    }
}