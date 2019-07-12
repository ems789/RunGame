﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alphabet : MonoBehaviour
{
    public AlphabetUI alphabetUI;

    private void Start()
    {      
        alphabetUI = GameObject.Find("Alphabet").GetComponent<AlphabetUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        alphabetUI.CheckAlphabet(this); // 알파벳을 넘김
        gameObject.SetActive(false);
    }
}