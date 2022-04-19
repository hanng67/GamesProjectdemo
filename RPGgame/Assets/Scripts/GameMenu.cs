using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _theMenu;

    [SerializeField]
    private GameObject[] _windows;

    private CharStats[] _playerStats;

    [SerializeField]
    private Text[] _nameText, _hpText, _mpText, _lvlText, _expText;

    [SerializeField]
    private Slider[] _expSlider;

    [SerializeField]
    private Image[] _charImage;

    [SerializeField]
    private GameObject[] _charStatHolder;

    [SerializeField]
    private GameObject[] _statusButton;

    [SerializeField]
    private Text _statusName, _statusHP, _statusMP, _statusStrengh, _statusDefence, _statusWpnEqpd, _statusWnpPwr, _statusArmrEqpd, _statusArmrPwr, _statusExp;

    [SerializeField]
    private Image _statusImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (_theMenu.activeInHierarchy)
            {
                CloseMenu();
            }
            else
            {
                _theMenu.SetActive(true);
                UpdateMainStat();
                GameManager.instance.gameMenuOpen = true;
            }
        }
    }

    void UpdateMainStat()
    {
        _playerStats = GameManager.instance.playerStats;

        for(int i = 0; i < _playerStats.Length; i++)
        {
            if (_playerStats[i].gameObject.activeInHierarchy)
            {
                _charStatHolder[i].SetActive(true);
                _nameText[i].text = _playerStats[i].charName;
                _hpText[i].text = "HP: " + _playerStats[i].currentHP + "/" + _playerStats[i].maxHP;
                _mpText[i].text = "MP: " + _playerStats[i].currentMP + "/" + _playerStats[i].maxMP;
                _lvlText[i].text = "Lvl: " + _playerStats[i].playerLevel;
                _expText[i].text = "" + _playerStats[i].currentExp + "/" + _playerStats[i].expToNextLevel[_playerStats[i].playerLevel];
                _expSlider[i].maxValue = _playerStats[i].expToNextLevel[_playerStats[i].playerLevel];
                _expSlider[i].value = _playerStats[i].currentExp;
                _charImage[i].sprite = _playerStats[i].charImage;
            }
            else
            {
                _charStatHolder[i].SetActive(false);
            }
        }
    }

    public void ToggleWindows(int windowNumber)
    {
        UpdateMainStat();

        for (int i = 0; i < _windows.Length; i++)
        {
            if(i == windowNumber)
            {
                _windows[i].SetActive(!_windows[i].activeInHierarchy);
            }
            else
            {
                _windows[i].SetActive(false);
            }
        }
    }

    public void CloseMenu()
    {
        for (int i = 0; i < _windows.Length; i++)
        {
            _windows[i].SetActive(false);
        }

        _theMenu.SetActive(false);
        GameManager.instance.gameMenuOpen = false;
    }

    public void OpenStatus()
    {
        UpdateMainStat();

        // update the information that is show
        StatusChar(0);

        for (int i = 0; i < _statusButton.Length; i++)
        {
            _statusButton[i].SetActive(_playerStats[i].gameObject.activeInHierarchy);

            _statusButton[i].GetComponentInChildren<Text>().text = _playerStats[i].charName;
        }
    }

    public void StatusChar(int selected)
    {
        _statusName.text = _playerStats[selected].charName;
        _statusHP.text = "" + _playerStats[selected].currentHP + "/" + _playerStats[selected].maxHP;
        _statusMP.text = "" + _playerStats[selected].currentMP + "/" + _playerStats[selected].maxMP;
        _statusStrengh.text = _playerStats[selected].strengh.ToString();
        _statusDefence.text = _playerStats[selected].defence.ToString();
        _statusWpnEqpd.text = _playerStats[selected].equippedWpn == "" ? "None" : _playerStats[selected].equippedWpn;
        _statusWnpPwr.text = _playerStats[selected].wpnPwr.ToString();
        _statusArmrEqpd.text = _playerStats[selected].equippedArmr == "" ? "None" : _playerStats[selected].equippedArmr;
        _statusArmrPwr.text = _playerStats[selected].armrPwr.ToString();
        _statusExp.text = (_playerStats[selected].expToNextLevel[_playerStats[selected].playerLevel] - _playerStats[selected].currentExp).ToString();
        _statusImage.sprite = _playerStats[selected].charImage;
    }
}
