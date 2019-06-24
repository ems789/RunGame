using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform SpawnPoint;

    private void Awake()
    {
        Screen.SetResolution(800, 480, false);
    }
}
