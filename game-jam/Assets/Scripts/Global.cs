using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global Instance { get; private set; }
    [SerializeField] private PlayerController playerController;
    private void Awake()
    {
        Instance = this;
    }

    public PlayerController GetPlayerController() => playerController;
}
