﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();
    private Transform parent;

    public void InitPool(GameObject _obj, int poolSize)
    {
        parent = new GameObject(_obj.name).transform;

        for (int i=0; i<poolSize; i++)
        {
            GameObject obj = Instantiate(_obj);
            obj.name += i;            
            obj.SetActive(false);
            obj.transform.SetParent(parent);

            list.Add(obj);
        }
    }

    // 대기중인 오브젝트를 꺼내온다
    public void GetObject(float posX, float posY)
    {
        GameObject obj = list.Find(item => item.activeSelf == false);
        
        if (obj == null)
            return;

        obj.transform.position = new Vector3(posX, posY, 0f);
        obj.SetActive(true);
    }

    // 대기중인 오브젝트가 있는지 확인만 함
    public GameObject PeekObject()
    {
        GameObject obj = list.Find(item => item.activeSelf == false);
        return obj;
    }


}