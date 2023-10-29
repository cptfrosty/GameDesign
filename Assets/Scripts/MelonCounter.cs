using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MelonCounter : MonoBehaviour
{
    private TextMeshProUGUI _textMelon;
    private int _count;
    
    private void Start()
    {
        FindMelonText();
        FindMelons();
    }

    public void DestroyMelon(Melon melon)
    {
        if (_textMelon == null) FindMelonText();

        _count--;
        _textMelon.text = _count.ToString();
        Destroy(melon.gameObject);
    }

    private void FindMelonText()
    {
        _textMelon = GameObject.Find("MelonText").GetComponent<TextMeshProUGUI>();
    }

    private void FindMelons()
    {
        _count = GameObject.FindObjectsOfType<Melon>().Length;
        _textMelon.text = _count.ToString();
    }
}
