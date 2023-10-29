using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private GameObject _finishCanvas;
    private bool _isFinish;
    private void Awake()
    {
        _finishCanvas = GameObject.Find("CanvasFinish");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isFinish) return;
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _isFinish = true;
            _finishCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "бш опнькх спнбемэ!";
            Invoke("RestartGame", 3f);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
