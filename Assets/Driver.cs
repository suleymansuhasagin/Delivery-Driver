using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float currentMoveSpeed = 15f;
    [SerializeField] float slowSpeed = 12f;
    [SerializeField] float boostSpeed = 22f;
    [SerializeField] float effectTime = 3f;
    [SerializeField] float timer = 0;
    bool isSlow=false;
    bool isFast=false;

    void Start()
    {
        
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * currentMoveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

        if (isSlow==true || isFast==true)
        {
            timer += Time.deltaTime;
        }
        if (timer >= effectTime)
        {
            isSlow = false;
            isFast = false;
            currentMoveSpeed = moveSpeed;
            timer = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            currentMoveSpeed = boostSpeed;
            isFast=true;
        }
        else if (other.tag == "Bump")
        {
            currentMoveSpeed = slowSpeed;
            isSlow=true;
        }
    } 
}
