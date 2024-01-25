using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTrans : MonoBehaviour
{
    public GameObject targetObj;
    public GameObject toObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetObj = collision.gameObject;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(TeleportRoutine());
        }
    }

    IEnumerator TeleportRoutine()
    {
        yield return null;
        targetObj.transform.position = toObj.transform.position;
    }
    
    
    
    }
    /*
    public enum NextPositionType
    {
        IngitPosition,
        SomePosition,
    };
    public NextPositionType nextPositionType;

    public Transform NextPoint;

    private void OnTriggerEneter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (nextPositionType == NextPositionType.SomePosition)
            {
                collision.transform.position = NextPoint.position;
            }
        }*/
    
    
    
    /*
    public string transferMapName;
    public Transform target;

    //private MovingObject Player;
    private CameraFollow theCamera;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<MovingObject>();
        theCamera = FindObjectOfType<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Player.current = transferMapName;
            theCamera.transform.position = newVector3(target.transform.position.x, target.transform.position.y, theCamera.transform.position.z);
            Player.transform.position = target.transform.position;
                }
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

