using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CameraBackground : MonoBehaviour
{
    [SerializeField] private TypeBackground _typeBackground;
    [SerializeField] private Sprite[] _backgrounds;

    private Image _background;
    private TypeBackground _currentTypeBackground;
    private void Start()
    {
        FindBackgroundObject();
        _currentTypeBackground = _typeBackground;
    }

    private void Update()
    {
        ChangeBackground();
    }

    private void ChangeBackground()
    {
        if (_background == null) FindBackgroundObject();

        if (_currentTypeBackground != _typeBackground)
        {
            _currentTypeBackground = _typeBackground;
            switch (_currentTypeBackground)
            {
                case TypeBackground.Blue:
                    _background.sprite = _backgrounds[0];
                    break;
                case TypeBackground.Brown:
                    _background.sprite = _backgrounds[1];
                    break;
                case TypeBackground.Gray:
                    _background.sprite = _backgrounds[2];
                    break;
                case TypeBackground.Green:
                    _background.sprite = _backgrounds[3];
                    break;
                case TypeBackground.Pink:
                    _background.sprite = _backgrounds[4];
                    break;
                case TypeBackground.Purple:
                    _background.sprite = _backgrounds[5];
                    break;
                case TypeBackground.Yellow:
                    _background.sprite = _backgrounds[6];
                    break;
            }
        }
    }

    private void FindBackgroundObject()
    {
        _background = GameObject.Find("Background").GetComponent<Image>();
    }
}

public enum TypeBackground{
    Blue,
    Brown,
    Gray,
    Green,
    Pink,
    Purple,
    Yellow
}
