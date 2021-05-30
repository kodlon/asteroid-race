using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    private float speedBackgroundMove;
    private float speedJetsParticleMove;

    [SerializeField] private GameObject dronePlayer;
    [SerializeField] private bl_Joystick joystick;
    [SerializeField] private ChangeSettings joystickActive;


    private static bool backgroundActive = false;
    public static bool BackgroundActive
    {
        set { backgroundActive = value; }
    }


    [SerializeField]
    private GameObject backgroundMove;
    [SerializeField]
    private GameObject backgroundMoveNext;

    [SerializeField]
    private ParticleSystem[] Jets;


    private void Update()
    {
        BackgroundSpeed();
        JetsParticleSpeed();
    }

    private void BackgroundSpeed()
    {
        if (backgroundActive)
        {
            backgroundMove.transform.position += new Vector3(0, -speedBackgroundMove * Time.deltaTime, 0);
            backgroundMoveNext.transform.position += new Vector3(0, -speedBackgroundMove * Time.deltaTime, 0);

            if (backgroundMove.transform.position.y <= -17.75f)
            {
                backgroundMove.transform.position = new Vector3(0, 12.75f, 2);
            }
            if (backgroundMoveNext.transform.position.y <= -17.75f)
            {
                backgroundMoveNext.transform.position = new Vector3(0, 12.75f, 2);
            }
        }


        speedBackgroundMove = (dronePlayer.transform.position.y - (-3.4f)) * 2.5f;
    }

    private void JetsParticleSpeed()
    {
        //TODO: Change because not good relatively to drone. Or change parameter, force for example
        float verticalAxis = joystick.Vertical;
        float verticalAxisAcceleration = Input.acceleration.y;

        if (joystickActive.Active)
            speedJetsParticleMove = (verticalAxis - (-2.4f)) * 3;
        else
            speedJetsParticleMove = (verticalAxisAcceleration + 0.5f) * 20;

        foreach (ParticleSystem jet in Jets)
        {
            var main = jet.main;
            main.gravityModifier = speedJetsParticleMove;
        }
    }
}
