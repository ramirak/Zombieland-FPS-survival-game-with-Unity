using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotion : MonoBehaviour
{
    public AudioSource walkAudio, runAudio;
    private const int regSpeed = 8, topSpeed = 15;
    private float speed = regSpeed, angularSpeed = 200, stamina = 100;
    private bool run = false;
    private CharacterController controller;
    private float rotationAboutY = 0, rotationAboutX = 0;
    public GameObject camera, info; // publics must be initialized in Unity
    public Text staminaText;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
       // Cursor.visible = false;
    }

    // Update is called once per frame

    void simulateStaminaRun()
    {
        staminaText.text = "Stamina " + (int)stamina;
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 1)
        {
            speed = topSpeed;
            stamina -= 0.1f;
            run = true;
        }
        else
        {
            speed = regSpeed;
            if (stamina < 100 && !Input.GetKey(KeyCode.LeftShift))
                stamina += 0.05f;
            run = false;
        }
    }

    void Update()
    {
        float dx, dy = -1/*kind of a gravity*/, dz;
        simulateStaminaRun();
        // rotation about Y
        rotationAboutY += Input.GetAxis("Mouse X") * angularSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, rotationAboutY, 0);

        // rotation about X
        rotationAboutX -= Input.GetAxis("Mouse Y") * angularSpeed * Time.deltaTime;
        camera.transform.localEulerAngles = new Vector3(rotationAboutX, 0, 0);

        // moving forward/backward/left/right
        dz = Input.GetAxis("Vertical"); // can be -1, 0 , 1
        dz *= speed * Time.deltaTime;

        dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        Vector3 motion = new Vector3(dx, dy, dz); // in Local coordinates
        motion = transform.TransformDirection(motion);// change to Global coordinates
        controller.Move(motion);//in Global coordinates

        if (dz < -0.05 || dz > 0.05 || dx < -0.05 || dx > 0.05)
        {
            if (info.activeSelf && !Input.GetKey(KeyCode.Tab))
                info.SetActive(false);
            if (!walkAudio.isPlaying && !runAudio.isPlaying)
                if (!run)
                    walkAudio.Play();
                else
                    runAudio.Play();
        }
    }

}
