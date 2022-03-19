using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellingController : MonoBehaviour
{

    #region UI
    [Space]
    [Header("Heads-up Display")]
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Slider timerSlider;
    [SerializeField] private Slider sliderProgress;
    [SerializeField] private GameObject[] costumers;
    #endregion

    #region Variables
    [Space]
    [Header("Variables")]
    [SerializeField] private float m_numbersToAdd;
    public bool stopUpdate;

    private bool _getLevel;
    #endregion

    private void Awake()
    {
        sliderProgress.value = 0;
    }

    private void Update()
    {
        if (!GameUIController.Instance.stopUpdate)
        {
            SellingStatus();
            ProgressBar();
        }

        if (gameObject != null && !_getLevel)
        {
            LevelNumber();
            _getLevel = false;
        }
        else
        {
            _getLevel = true;
        }
    }

    private void SellingStatus()
    {
        if (timerSlider.value <= 0f)
        {
            if (sliderProgress.value >= 1f)
            {
                ResultManager.Instance.StartCoroutine(ResultManager.Instance.WinResult());
                ResultManager.Instance.isWin = true;
                GameUIController.Instance.stopUpdate = true;
            }
            else if (sliderProgress.value < 1f)
            {
                ResultManager.Instance.StartCoroutine(ResultManager.Instance.LoseResult());
                ResultManager.Instance.isWin = false;
                GameUIController.Instance.stopUpdate = true;
            }
        }
        else
        {
            if (sliderProgress.value >= 1f)
            {
                ResultManager.Instance.StartCoroutine(ResultManager.Instance.WinResult());
                ResultManager.Instance.isWin = true;
                GameUIController.Instance.stopUpdate = true;
            }
        }
    }

    public void ButtonPressToProgress()
    {
        sliderProgress.value += m_numbersToAdd;
    }

    private void ProgressBar()
    {
        if (sliderProgress.value >= 1f)
        {
            sliderProgress.value = 1f;
        }
        else
        {
            sliderProgress.value -= 0.15f * Time.deltaTime;
        }

        if (sliderProgress.value >= 0.3f)
        {
            costumers[0].SetActive(true);
        }
        if (sliderProgress.value >= 0.5f)
        {
            costumers[1].SetActive(true);
        }
        if (sliderProgress.value >= 0.7f)
        {
            costumers[2].SetActive(true);
        }
        if (sliderProgress.value >= 0.9f)
        {
            costumers[3].SetActive(true);
        }

        if (sliderProgress.value < 0.3f)
        {
            costumers[0].SetActive(false);
        }
        if (sliderProgress.value < 0.5f)
        {
            costumers[1].SetActive(false);
        }
        if (sliderProgress.value < 0.7f)
        {
            costumers[2].SetActive(false);
        }
        if (sliderProgress.value < 0.9f)
        {
            costumers[3].SetActive(false);
        }
    }

    public void LevelNumber()
    {
        GameUIController.Instance.level = 4;
    }
}
