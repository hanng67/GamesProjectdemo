using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private Text _dialogText;

    [SerializeField]
    private Text _nameText;

    [SerializeField]
    private GameObject _dialogBox;

    [SerializeField]
    private GameObject _nameBox;

    [SerializeField]
    private string[] _dialogLines;

    private int _currentLine;

    private bool _justStarted;

    public static DialogManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (_dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!_justStarted)
                {
                    _currentLine++;
                    if (_currentLine >= _dialogLines.Length)
                    {
                        _dialogBox.SetActive(false);
                        PlayerController.instance.canMove = true;
                    }
                    else
                    {
                        CheckIfName();
                        _dialogText.text = _dialogLines[_currentLine];
                    }
                }
                else
                {
                    _justStarted = false;
                }
            }
        }   
    }

    public void ShowDialog(string[] newlines, bool isPerson)
    {
        _dialogLines = newlines;

        _currentLine = 0;
        CheckIfName();
        _dialogText.text = _dialogLines[_currentLine];
        _dialogBox.SetActive(true);
        _nameBox.SetActive(isPerson);

        PlayerController.instance.canMove = false;

        _justStarted = true;
    }

    public void CheckIfName()
    {
        if (_dialogLines[_currentLine].StartsWith("n-"))
        {
            _nameText.text = _dialogLines[_currentLine].Replace("n-", "");
            _currentLine++;
        }
    }

    public bool GetActiveDialogBox()
    {
        return _dialogBox.activeInHierarchy;
    }
}
