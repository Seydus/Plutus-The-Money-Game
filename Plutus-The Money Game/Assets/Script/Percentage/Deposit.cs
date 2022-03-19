using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : MonoBehaviour
{
    private const string _zeroPercent = "0%";
    private const string _fiftyFivePercent = "50%";
    private const string _oneHundredPercent = "100%";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_zeroPercent))
            PercentageController.Instance.percent = 25;
        else if (other.CompareTag(_fiftyFivePercent))
            PercentageController.Instance.percent = 50;
        else if (other.CompareTag(_oneHundredPercent))
            PercentageController.Instance.percent = 100;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(_zeroPercent))
            PercentageController.Instance.percent = 0;
        else if (other.CompareTag(_fiftyFivePercent))
            PercentageController.Instance.percent = 0;
        else if (other.CompareTag(_oneHundredPercent))
            PercentageController.Instance.percent = 0;
    }
}
