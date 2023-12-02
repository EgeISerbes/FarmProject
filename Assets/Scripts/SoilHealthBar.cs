using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoilHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;
    [SerializeField] List<Color> _listOfColors;
    [SerializeField] Image _image;

    [SerializeField] private int _minValueForGreen;
    [SerializeField] private int _minValueForYellow;

    public void SetBarScale( int value)
    {
        var scale = _healthBar.transform.localScale;
        scale.x = value / 100.0f;
        _healthBar.transform.localScale = scale;

        if (value >= _minValueForGreen)
        {
            _image.color = _listOfColors[0];

        }
        else if (value >= _minValueForYellow)
        {
            _image.color = _listOfColors[1];
        }
        else
        {
            _image.color = _listOfColors[2];
        }
    }

}
