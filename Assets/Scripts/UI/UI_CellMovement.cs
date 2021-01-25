using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CellMovement : MonoBehaviour
{

    private Vector3 startPosition=Vector3.zero;
    
    private Vector3 movementVector=Vector3.zero;
    private float maxDistance=1f;
    
    public float movementSpeed = 1.0f;
    public Transform ui_cellsObject;

    public bool canMove=true;
    
    void Start()
    {
        movementVector = GetRandomVector();
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(canMove)
        {
            float distance = Vector3.Distance(ui_cellsObject.position, startPosition );
            if(distance >= maxDistance)
            {
                movementVector=GetRandomVector();
            }
            ui_cellsObject.Translate(movementVector*movementSpeed * Time.deltaTime,Space.World);
        }
    }

    Vector3 GetRandomVector()
    {
        return new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f),0f);
    }

    public void StartMovement()
    {
        canMove=true;
    }
    public void StopMovement()
    {
        canMove=false;
    }
}
