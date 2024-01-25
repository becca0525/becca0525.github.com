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
        // 게임 오버 상태를 참으로 변경
        //isGameover = true;
        // 게임 오버 UI를 활성화
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 }
