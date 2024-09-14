using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SizeControl : MonoBehaviour
{
    public Slider slider;
    public GameObject scalingObject;

    public Rigidbody rb;
    public float minSize = 2;

    public float sizeScalingFactor = 4;

    public float minWeight = 2;

    public float weightScalingFactor = 4;

    public float minGrav = 2;

    public float gravityScalingFactor = 4;



    void Awake() {
        rb = scalingObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        float sizeSliderValue = minSize + slider.value * sizeScalingFactor;

        scalingObject.transform.localScale = Vector3.one * sizeSliderValue;

        float weightSliderValue = minWeight + slider.value * weightScalingFactor;

        rb.mass = weightSliderValue;

        float gravitySliderValue = minGrav + slider.value * gravityScalingFactor;

        rb.mass = gravityScalingFactor;
    }
}
