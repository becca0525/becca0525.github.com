using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Clear : MonoBehaviour
{
    public GameObject clear;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
        clear.SetActive(true);
        }
    }
        // ���� ���� ���¸� ������ ����
        //isGameover = true;
        // ���� ���� UI�� Ȱ��ȭ
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 }