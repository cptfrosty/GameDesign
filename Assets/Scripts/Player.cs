using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _beginPos;

    private void Awake()
    {
        _beginPos = transform.position;
    }

    /// <summary>
    /// Вернуться на стартовую позицию
    /// </summary>
    public void BackToStartPosition()
    {
        transform.position = _beginPos;
    }

    public void SaveNewPos(Vector3 pos)
    {
        _beginPos = pos;
    }
}
