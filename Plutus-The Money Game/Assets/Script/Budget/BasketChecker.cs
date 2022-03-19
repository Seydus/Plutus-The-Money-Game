using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketChecker : MonoBehaviour
{
    #region Tags
    private const string _tagApple = "Apple";
    private const string _tagOrange = "Orange";
    private const string _tagBeer = "Beer";
    private const string _tagJunkfood = "Junkfood";
    #endregion

    #region Price
    private float _priceApple = 2f;
    private float _priceOrange = 5f;
    private float _priceBeer = 3f;
    private float _priceJunkfood = 4f;
    #endregion


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_tagApple))
            BudgetController.Instance.total += _priceApple;
        else if(other.CompareTag(_tagOrange))
            BudgetController.Instance.total += _priceOrange;
        else if (other.CompareTag(_tagBeer))
            BudgetController.Instance.total += _priceBeer;
        else if (other.CompareTag(_tagJunkfood))
            BudgetController.Instance.total += _priceJunkfood;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(_tagApple))
            BudgetController.Instance.total -= _priceApple;
        else if (other.CompareTag(_tagOrange))
            BudgetController.Instance.total -= _priceOrange;
        else if (other.CompareTag(_tagBeer))
            BudgetController.Instance.total -= _priceBeer;
        else if (other.CompareTag(_tagJunkfood))
            BudgetController.Instance.total -= _priceJunkfood;
    }
}

