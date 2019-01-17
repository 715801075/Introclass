using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{


    public float Acceleration = 100.0f;
    public float MaxVelocity;

    public bool IsSprinting;
    private float MaxWalkVelocity = 10;
    public float MaxSprintVelocity

    private Rigidbody RB;


    Vector3 InputVector;


    void Start()
    {
        RB = GetComponent<Rigidbody>();


    }
    void Movement(Rigidbody rb, Vector3 IPVector, float Speed, float MaxVel, float MaxVelSpr)
    {
        IPVector.x = Input.GetAxisRaw("Horizontal");
        IPVector.z = Input.GetAxisRaw("Vertical");
        rb.AddForce(IPVector * Acceleration * Time.deltaTime);
        rb.velocity = VectorClamp(rb.velocity, -MaxVel, MaxVel, true, false, true);

    }




    Vector3 VectorClamp(Vector3 CurrentVector, float Min, float Max, bool ClampX = true, bool ClampY = true, bool ClampZ = true)
    {

     Vector3 Result = CurrentVector;

    if (ClampX == true)
        {
        Result.x = Mathf.Clamp(CurrentVector.x, Min, Max);
        }
  if (ClampY == true)
        {
        Result.y = Mathf.Clamp(CurrentVector.y, Min, Max);
        }
   if (ClampZ == true)
        {
        Result.z = Mathf.Clamp(CurrentVector.z, Min, Max);
        }

 
        return Result; 
 }
    

    void Update()
    {
        IsSprinting = Input.GetKey(KeyCode.LeftShift);


        Movement(RB, InputVector, Acceleration, MaxVelocity);

    }
}
 
