using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = PlayerController.VIDA_MAX;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GameObject.Find("Player").GetComponent<PlayerController>().getVida();
    }
}
