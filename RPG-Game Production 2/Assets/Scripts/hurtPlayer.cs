using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hurtPlayer : MonoBehaviour
{
    public Health Health;
    public Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        float fillValue = Health.currentHealth / Health.maxHealth;
        slider.value = fillValue;
       // slider.value = Health.currentHealth / Health.maxHealth;
    }

}
