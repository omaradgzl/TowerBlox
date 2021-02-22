using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingCube : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    public static MovingCube CurrentCube { get; private set; }
    public static MovingCube LastCube { get; private set; }
    public MoveDirection MoveDirection { get; set; }


    private void OnEnable()
    { 
        
        if (LastCube == null)
        {
            LastCube = GameObject.Find("Start").GetComponent<MovingCube>();
        }

        CurrentCube = this;
        CurrentCube.GetComponent<Rigidbody>().useGravity = false;
        
    }

    void Update()
    {
        if (MoveDirection==MoveDirection.Z)
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;    
        }else
            transform.position += transform.right * Time.deltaTime * moveSpeed;
    }

    public void Stop()
    {
        moveSpeed = 0;
        float hangover = GetHangover();
        Debug.Log(hangover);
        if (MoveDirection==MoveDirection.Z)
            SetPosCubeOnZ(hangover);
        else
            SetPosCubeOnX(hangover);
    }

    private float GetHangover()
    {
        if (MoveDirection==MoveDirection.Z)
            return transform.position.z - LastCube.transform.position.z;    
        else
            return transform.position.x - LastCube.transform.position.x;
        
    }

    private void SetPosCubeOnX(float hangover)
    {
        if (Mathf.Abs(hangover)>0.6f)
        { 
            CurrentCube.GetComponent<Rigidbody>().useGravity = true;
            /*LastCube = null;    DEATH
            CurrentCube = null;
            SceneManager.LoadScene(0);*/
        }
        else
        { 
            transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z);
            Destroy(CurrentCube.GetComponent<Rigidbody>());
            LastCube = this;
        }
        
    }
    
    private void SetPosCubeOnZ(float hangover)
    {
        if (Mathf.Abs(hangover)>0.6f)
        { 
            CurrentCube.GetComponent<Rigidbody>().useGravity = true;
            /*LastCube = null;    DEATH
            CurrentCube = null;
            sceneManager.LoadScene(0);*/
        }
        else
        { 
            transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z);
            Destroy(CurrentCube.GetComponent<Rigidbody>());
            LastCube = this;
        }
        
    }

    
}
