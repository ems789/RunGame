using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetUI : MonoBehaviour
{
    public GameObject[] alphabet;

    public void CheckAlphabet(Alphabet alpha)
    {
        for (int i = 0; i < alphabet.Length; i++)
        {
            if (alphabet[i].CompareTag(alpha.tag)) // 받아온 알파벳의 태그가 UI의 태그와 일치하면
            {
                alphabet[i].SetActive(true); // 컬러 이미지 활성화
            }
        }
    }
}
