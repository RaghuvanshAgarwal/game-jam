using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySystem : MonoBehaviour
{
    public Action<eKeyType> OnKeyAdded;
    [SerializeField]private int _keyCount;

    public void AddKey(eKeyType keyType)
    {
        _keyCount++;
        OnKeyAdded?.Invoke(keyType);
    }
    public int KeyCount { get { return _keyCount; } }
}

public enum eKeyType
{
    SILVER,
    GOLD,
    PLATINUM
}
