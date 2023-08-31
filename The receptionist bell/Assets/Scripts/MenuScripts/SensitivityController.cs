using UnityEngine;
using UnityEngine.UI;

public class SensitivityController : MonoBehaviour
{
    public MouseLook mouseLookScript;
    public Slider sensitivitySlider;
    public float minSensitivity = 50f; // Set your minimum sensitivity here
    public float maxSensitivity = 1000f; // Set your maximum sensitivity here

    private void OnValidate()
    {
        sensitivitySlider.minValue = minSensitivity;
        sensitivitySlider.maxValue = maxSensitivity;
    }

    private void Start()
    {
        sensitivitySlider.value = mouseLookScript.mouseSensitivity;
        sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
    }

    private void UpdateSensitivity(float newSensitivity)
    {
        float clampedSensitivity = Mathf.Clamp(newSensitivity, minSensitivity, maxSensitivity);
        mouseLookScript.mouseSensitivity = clampedSensitivity;
        sensitivitySlider.value = clampedSensitivity;
    }
}