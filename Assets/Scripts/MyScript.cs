using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MyScript : MonoBehaviour
{


    // Reference to the Particle System component

    public GameObject trail;


    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     


        if (Keyboard.current.wKey.isPressed || Keyboard.current.aKey.isPressed || Keyboard.current.sKey.isPressed || Keyboard.current.dKey.isPressed || Keyboard.current.upArrowKey.isPressed || Keyboard.current.downArrowKey.isPressed || Keyboard.current.leftArrowKey.isPressed || Keyboard.current.rightArrowKey.isPressed)

        {
            //Animation Walking

            this.GetComponent<Animator>().SetBool("Walkin", true);




            //Trail

            ParticleSystem particleSystem2 = trail.GetComponent<ParticleSystem>();

            // Access the main module of the ParticleSystem
            var mainModule2 = particleSystem2.main;

            // Get the start lifetime as a MinMaxCurve
            ParticleSystem.MinMaxCurve startLifetimeCurve2 = mainModule2.startLifetime;

            // If the start lifetime is a random between two numbers
            if (startLifetimeCurve2.mode == ParticleSystemCurveMode.TwoConstants)
            {

                mainModule2.startLifetime = new ParticleSystem.MinMaxCurve(1f, 2f);

            }


        }
        else
        {
            this.GetComponent<Animator>().SetBool("Walkin", false);


            //Trail

            ParticleSystem particleSystem2 = trail.GetComponent<ParticleSystem>();

            // Access the main module of the ParticleSystem
            var mainModule2 = particleSystem2.main;

            // Get the start lifetime as a MinMaxCurve
            ParticleSystem.MinMaxCurve startLifetimeCurve2 = mainModule2.startLifetime;

            // If the start lifetime is a random between two numbers
            if (startLifetimeCurve2.mode == ParticleSystemCurveMode.TwoConstants)
            {

                mainModule2.startLifetime = new ParticleSystem.MinMaxCurve(0.01f, 0.01f);
            }

        }
    }

   
}
