using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Cinemachine;

public class Orbs : MonoBehaviour
{

    public bool Near = false;
    public bool open = false;

    MyScript myscript;
    public GameObject script;

    PlayerController_RB pp;
    public GameObject p;


    public GameObject canvasEN;
    public GameObject canvasPT;
    public GameObject Stars;
    public GameObject E;

    public GameObject Cam;

    public string S;
    public GameObject Leg;

    Manager manager;
    public GameObject man;

    public GameObject ButPT;
    public GameObject ButEN;

    public AudioSource Star;


    // Start is called before the first frame update
    void Start()
    {
        myscript = script.GetComponent<MyScript>();
        manager = man.GetComponent<Manager>();
        pp = p.GetComponent<PlayerController_RB>();
    }

    // Update is called once per frame
    void Update()
    {


        S = this.gameObject.name;
            
   

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {

            

            if (open == false)
            {


                if (Near == true)
                {
                    Debug.Log("Aberto");
                    open = true;

                    Star.Play();

                    pp.enabled = false;
                    myscript.enabled = false;

                    if (manager.PT == true) { canvasPT.gameObject.SetActive(true); }
                    else { canvasEN.gameObject.SetActive(true); }
                    
                    Invoke("Starss", 2.7f);

                    Cam.GetComponent<CinemachineBrain>().enabled = false;
                    Cam.GetComponent<Animator>().Play(S);

                    if(this.gameObject.name != "S1")
                    {
                        Leg.SetActive(false);
                    }
                }

            }

            else
            {

                Debug.Log("Fechado");
                open = false;

                pp.enabled = true;
                myscript.enabled = true;

                if (manager.PT == true) { canvasPT.gameObject.SetActive(false); }
                else { canvasEN.gameObject.SetActive(false); }

                Cam.GetComponent<CinemachineBrain>().enabled = true;

                Stars.GetComponent<Animator>().SetBool("Big", false);
                if (manager.PT == true) { ButPT.SetActive(false); ; }
                else { ButEN.SetActive(false); }

            }
        }
    }

    public void Starss()
    { 
    
        Stars.GetComponent<Animator>().SetBool("Big", true);


        if (manager.PT == true) { ButPT.SetActive(true); ; }
        else { ButEN.SetActive(true); }

    }


    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player")
        {
            E.GetComponent<Animator>().SetBool("Change", true);

        }

    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Player")
        {
            Near = true;
        }

    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "Player")
        {

            E.GetComponent<Animator>().SetBool("Change", false);

            Near = false;

        }

    }
}
