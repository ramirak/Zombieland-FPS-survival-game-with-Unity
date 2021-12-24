using UnityEngine;

public class WaterFloat : MonoBehaviour
{
    public Vector3 MovingDistances = new Vector3(0.002f, 0.001f, 0f);     //up and down distance of the wave
    public float speed = 1f;                                              //the speed of up and down

    public Vector3 WaveRotations;                                         //object side rotations
    public float WaveRotationsSpeed = 0.3f;                               //speed of rotations

    public Vector3 AxisOffsetSpeed;                                       //speed of moving object along an axis

    Transform actualPos;                                                  //save the actual transform



    void Start()
    {
        actualPos = transform;
    }

    
    void Update () 
    {
        //change axis
        Vector3 mov = new Vector3 (
            actualPos.position.x + Mathf.Sin(speed * Time.time) * MovingDistances.x,
            actualPos.position.y + Mathf.Sin(speed * Time.time) * MovingDistances.y, 
            actualPos.position.z + Mathf.Sin(speed * Time.time) * MovingDistances.z
        );
        
        //change rotations
        transform.rotation = Quaternion.Euler(
            actualPos.rotation.x + WaveRotations.x * Mathf.Sin(Time.time * WaveRotationsSpeed), 
            actualPos.rotation.y + WaveRotations.y * Mathf.Sin(Time.time * WaveRotationsSpeed), 
            actualPos.rotation.z + WaveRotations.z * Mathf.Sin(Time.time * WaveRotationsSpeed)
        );

        //inject the changes
        transform.position = mov;

        //offset
        var tran = transform.position;
        
        tran.x += AxisOffsetSpeed.x * Time.deltaTime;
        tran.y += AxisOffsetSpeed.y * Time.deltaTime;
        tran.z += AxisOffsetSpeed.z * Time.deltaTime;

        transform.position = tran;
    }
}
