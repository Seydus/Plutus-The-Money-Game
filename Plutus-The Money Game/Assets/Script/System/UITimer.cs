using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    public static UITimer Instance { get; set; }

    #region Variables
    [SerializeField] private Slider timerSlider;
    [SerializeField] private float timerValue;

    [SerializeField] private float timeToDeduct;

    public float timerSpeed = 2.1f;
    #endregion

    #region Built-in Methods
    private void Awake()
    {
        Instance = this;
        timerSpeed = 2.1f;
    }

    private void Start()
    {
        timerSlider.value = timerValue;
    }

    private void Update()
    {
        if(!GameUIController.Instance.stopUpdate)
        {
            timerSlider.value -= timeToDeduct * timerSpeed * Time.deltaTime;
        }
    }

    public void AddTimerSpeed()
    {
        timerSpeed += 0.5f;
    }
    #endregion
}
