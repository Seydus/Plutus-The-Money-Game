using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class SpellingController : MonoBehaviour
{
    public static SpellingController Instance { get; set; }

    [Space]
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Slider timerSlider;

    [Space]
    [Header("Components")]
    [SerializeField] private Transform[] targetPos;
    [SerializeField] private Transform[] objectIndex;
    [SerializeField] private GameObject[] textLetterObject;
    [SerializeField] private GameObject[] letterObject;
    private Vector2[] origPos = new Vector2[6];

    [Space]
    [Header("Variables")]
    [SerializeField] private int[] randomValue = new int[6];
    [SerializeField] private int[] _seletectedValue = new int[6];
    [SerializeField] private int _selectedValueAdded;
    private int _letterIndex;
    [SerializeField] private int _fixedLetterValue;
    private int _letterDispense;

    private bool _getLevel;

    [Space]
    [Header("Events")]
    public UnityEvent<SpellingController> onLetterPressed;

    void Awake()
    {
        Instance = this;
        ScrambleLetters();
    }
    void Start()
    {
        origPos[0] = letterObject[0].transform.position;
        origPos[1] = letterObject[1].transform.position;
        origPos[2] = letterObject[2].transform.position;
        origPos[3] = letterObject[3].transform.position;
        origPos[4] = letterObject[4].transform.position;
        origPos[5] = letterObject[5].transform.position;
    }
    void Update()
    {
        if (!GameUIController.Instance.stopUpdate)
        {
            Status();

            if (Input.GetKeyDown("s") || Input.GetKeyDown("w"))
            {
                ResetSpellingData();
            }

            if (Input.GetKeyDown("e"))
            {
                ResetSelectedValue();
            }      
        }

        if(gameObject != null && !_getLevel)
        {
            LevelNumber();
            _getLevel = false;
        }
        else
        {
            _getLevel = true;
        }
    }
    public void Status()
    {
        //Increases the timer of the slide
        if (timerSlider.value <= 0f)
        {
            if (_fixedLetterValue >= _selectedValueAdded)
            {
                ResultManager.Instance.StartCoroutine(ResultManager.Instance.WinResult());
                ResultManager.Instance.isWin = true;
                GameUIController.Instance.stopUpdate = true;
                ResetSelectedValue();
            }
            else
            {
                ResultManager.Instance.StartCoroutine(ResultManager.Instance.LoseResult());
                ResultManager.Instance.isWin = false;
                GameUIController.Instance.stopUpdate = true;
                ResetSelectedValue();
            }
        }
        else
        {
            if (_fixedLetterValue >= _selectedValueAdded)
            {
                ResultManager.Instance.StartCoroutine(ResultManager.Instance.WinResult());
                ResultManager.Instance.isWin = true;
                GameUIController.Instance.stopUpdate = true;
                ResetSelectedValue();
            }
        }
    }
    public void PlaceLetter(string letter)
    {
        switch (letter)
        {
            case "D":
                _letterDispense = _seletectedValue[0];
                _letterIndex = 0;
                break;
            case "O":
                _letterDispense = _seletectedValue[1];
                _letterIndex = 1;
                break;
            case "N":
                _letterDispense = _seletectedValue[2];
                _letterIndex = 2;
                break;
            case "A":
                _letterDispense = _seletectedValue[3];
                _letterIndex = 3;
                break;
            case "T":
                _letterDispense = _seletectedValue[4];
                _letterIndex = 4;
                break;
            case "E":
                _letterDispense = _seletectedValue[5];
                _letterIndex = 5;
                break;
        }

        //If the player matches the "numberToPlace" then place the letter else then they're wrong.
        if (_letterDispense == _fixedLetterValue)
        {
            letterObject[_letterIndex].transform.position = targetPos[_letterIndex].transform.position;
            _fixedLetterValue++;
        }
        else
        {
            //Wrong
        }
    }
    public void ScrambleLetters()
    {
        //Shuffles the index of an array
        Shuffle(randomValue);

        //Randomly selects and enables letter gameObject
        for (int i = 0; i < randomValue.Length; i++)
        {
            objectIndex[i].SetSiblingIndex(randomValue[i]);

            if (Random.Range(0, 2) == 1)
            {
                letterObject[i].SetActive(true);
                textLetterObject[i].SetActive(false);

                _seletectedValue[i] = _selectedValueAdded++;
            }
            else
            {
                textLetterObject[i].SetActive(true);
                letterObject[i].SetActive(false);
            }
        }
    }
    public void ResetSpellingData()
    {
        #region Letters Gameobject / Transform
        textLetterObject[0].SetActive(false);
        textLetterObject[1].SetActive(false);
        textLetterObject[2].SetActive(false);
        textLetterObject[3].SetActive(false);
        textLetterObject[4].SetActive(false);
        textLetterObject[5].SetActive(false);

        letterObject[0].SetActive(false);
        letterObject[1].SetActive(false);
        letterObject[2].SetActive(false);
        letterObject[3].SetActive(false);
        letterObject[4].SetActive(false);
        letterObject[5].SetActive(false);

        ScrambleLetters();
        #endregion
    }
    public void ResetSelectedValue()
    {
        for (int i = 0; i < _seletectedValue.Length; i++)
        {
            _seletectedValue[i] = 0;
        }

        _selectedValueAdded = 0;
        _fixedLetterValue = 0;
        _letterDispense = 0;
    }

    public void Shuffle(int[] a)
    {
        for (int i = a.Length - 1; i > 0; i--)
        {
            int random = Random.Range(0, i);

            int temp = a[i];

            a[i] = a[random];
            a[random] = temp;
        }
    }

    public void LevelNumber()
    {
        GameUIController.Instance.level = 2;
    }
}
