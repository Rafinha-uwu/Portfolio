using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class Manager : MonoBehaviour
{
    public bool PT = false;
    public bool Open = false;
    public bool Game = false;

    MyScript myscript;
    public GameObject script;

    public GameObject fall;
    public GameObject Trails;

    public GameObject UI;
    public bool UION = false;

    public GameObject LG;
    public GameObject INTROPT;
    public GameObject INTROENG;

    public GameObject PTEsq;
    public GameObject EngEsq;

    public GameObject PTH;
    public GameObject EngH;

    public GameObject Leg;

    public GameObject typeOutGameObject;

    private TypeOutScript typeOutScript;

    public GameObject Cam;

    [SerializeField]
    private AudioSource Voice;

    [SerializeField]
    private AudioSource Fall;

    [SerializeField]
    private AudioSource Apear;

    [SerializeField]
    private AudioSource Bot;


    // Start is called before the first frame update
    void Start()
    {
        myscript = script.GetComponent<MyScript>();
        typeOutScript = typeOutGameObject.GetComponent<TypeOutScript>();

        Cam.AddComponent<CinemachineBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UION == true)
        {
            StartCoroutine(Intro());
            UION = false;
        }

        if (Game == true)
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                if (Open == false)
                {
                    
                    UI.gameObject.GetComponent<Animator>().SetTrigger("Show"); Open = true;

                    Invoke("EsqShow", .8f);
                    myscript.enabled = false;
                    myscript.gameObject.GetComponent<PlayerController_RB>().enabled = false;

                }
                else
                {
                    Invoke("EsqHide", .3f);
                   
                    UI.gameObject.GetComponent<Animator>().SetTrigger("Gone"); Open = false;
                    myscript.enabled = true;
                    myscript.gameObject.GetComponent<PlayerController_RB>().enabled = true;
                }
            }

        }

    }

    public void UIManager()
    {
        Bot.Play();
        UION = true;

        INTROPT.SetActive(false);
        INTROENG.SetActive(false);
    }

    public void EsqShow()
    {
        Bot.Play();
        if (PT) { PTEsq.SetActive(true); }
        else { EngEsq.SetActive(true); }
    }

    public void EsqHide()
    {
        Bot.Play();
        if (PT) { PTEsq.SetActive(false); }
        else { EngEsq.SetActive(false); }
    }

    public void No()
    {
        Bot.Play();
        INTROPT.SetActive(false);
        INTROENG.SetActive(false);

        myscript.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        myscript.gameObject.transform.position = new Vector3(3.119f, 2.34f, -8.17f);
        UI.gameObject.GetComponent<Animator>().SetTrigger("Gone");
        myscript.gameObject.GetComponent<Animator>().Play("Idle");
        myscript.enabled = true;
        myscript.gameObject.GetComponent<PlayerController_RB>().enabled = true;
        Game = true;

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        Bot.Play();
        UI.gameObject.GetComponent<Animator>().SetTrigger("Gone"); Open = false;
        Invoke("EsqHide", .3f);
        myscript.enabled = true;
        myscript.gameObject.GetComponent<PlayerController_RB>().enabled = true;

    }


    public void Tuga()
    {
        Bot.Play();
        PT = true;
        LG.SetActive(false);
        INTROPT.SetActive(true);
    }
    public void Eng()
    {
        Bot.Play();
        PT = false;
        LG.SetActive(false);
        INTROENG.SetActive(true);
    }


    public IEnumerator Intro()
    {
        if (PT == false)
        {

            EngH.SetActive(true);


            yield return new WaitForSeconds(6f);

            EngH.SetActive(false);

            UI.gameObject.GetComponent<Animator>().SetTrigger("Gone");
            myscript.gameObject.GetComponent<PlayerController_RB>().enabled = false;
            myscript.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            yield return new WaitForSeconds(6f);

            Voice.Play();

            yield return new WaitForSeconds(1f);

            Leg.SetActive(true);
            typeOutScript.Star();
            typeOutScript.FinalText = "Hello and welcome to the human mind.";

            yield return new WaitForSeconds(3f);
            typeOutScript.Star();
            typeOutScript.FinalText = "...";

            yield return new WaitForSeconds(1.6f);
            typeOutScript.Star();
            typeOutScript.FinalText = "A bit empty, isn't it? Let's change that!";

            yield return new WaitForSeconds(3.2f);

            fall.gameObject.SetActive(true);
            Trails.gameObject.SetActive(true);
            myscript.gameObject.GetComponent<Animator>().SetTrigger("Fall");

            yield return new WaitForSeconds(.3f);

            Apear.Play();
            

            yield return new WaitForSeconds(2.9f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Ah, much better! That little guy over there is you! ";

            yield return new WaitForSeconds(4.5f);
            typeOutScript.Star();
            typeOutScript.FinalText = "You were brought here to learn about the life and projects..";
            yield return new WaitForSeconds(3.5f);
            typeOutScript.Star();
            typeOutScript.FinalText = "..of the mind you're inside right now.";
            yield return new WaitForSeconds(3.5f);
            typeOutScript.Star();
            typeOutScript.FinalText = "They're very passionate about video games and space, hence why you look like that.";
            yield return new WaitForSeconds(5.5f);
            typeOutScript.Star();
            typeOutScript.FinalText = "In our reality, we all see and experience the world very differently..";
            yield return new WaitForSeconds(5f);
            typeOutScript.Star();
            typeOutScript.FinalText = "..which makes it hard for us to understand one another.";
            yield return new WaitForSeconds(3f);
            typeOutScript.Star();
            typeOutScript.FinalText = "But luckly for you, this isn't reality, this... is a video game!";

            yield return new WaitForSeconds(6f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Oh! We're arriving.";

            yield return new WaitForSeconds(1f);
            myscript.gameObject.GetComponent<Rigidbody>().isKinematic = false;

            yield return new WaitForSeconds(6f);
            Fall.Play();
            yield return new WaitForSeconds(.5f);
            fall.gameObject.SetActive(false);
            myscript.gameObject.GetComponent<Animator>().SetTrigger("Arrive");
            
            yield return new WaitForSeconds(1f);
            typeOutScript.Star();
            typeOutScript.FinalText = "This.. is Rafael's world!";

            Cam.GetComponent<CinemachineBrain>().enabled = false;
            Cam.GetComponent<Animator>().Play("World");

            yield return new WaitForSeconds(3f);
            typeOutScript.Star();
            typeOutScript.FinalText = "It reflects their peaceful personality and is filled with their projects.";

            yield return new WaitForSeconds(5f);
            typeOutScript.Star();
            typeOutScript.FinalText = "You are here to learn about said projects and have a good time while doing so.";

            yield return new WaitForSeconds(5f);
            typeOutScript.Star();
            typeOutScript.FinalText = "You can follow the Yellow Road for a chronological journey..";

            yield return new WaitForSeconds(4f);
            typeOutScript.Star();
            typeOutScript.FinalText = "..or simply explore on your own. It's up to you.";

            yield return new WaitForSeconds(4f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Start by pressing E next to the Info sign over there.";

            Cam.GetComponent<CinemachineBrain>().enabled = true;

            yield return new WaitForSeconds(4f);
            typeOutScript.Star();
            typeOutScript.FinalText = "That's all. Thank you for listening, and enjoy!";

            yield return new WaitForSeconds(5f);
            myscript.enabled = true;
            myscript.gameObject.GetComponent<PlayerController_RB>().enabled = true;
            Game = true;
            Leg.SetActive(false);

            yield return new WaitForSeconds(25f);
            Leg.SetActive(true);
            typeOutScript.Star();
            typeOutScript.FinalText = "Look and interact with the white statues to see the projects";


        }


        else
        {

            PTH.SetActive(true);


            yield return new WaitForSeconds(6f);

            PTH.SetActive(false);

            UI.gameObject.GetComponent<Animator>().SetTrigger("Gone");
            myscript.gameObject.GetComponent<PlayerController_RB>().enabled = false;
            myscript.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            yield return new WaitForSeconds(6f);

            Voice.Play();

            yield return new WaitForSeconds(1f);

            Leg.SetActive(true);
            typeOutScript.Star();
            typeOutScript.FinalText = "Olá e bem-vindo à mente humana.";

            yield return new WaitForSeconds(3f);
            typeOutScript.Star();
            typeOutScript.FinalText = "...";

            yield return new WaitForSeconds(1.6f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Um pouco vazio, não é? Vamos mudar isso";

            yield return new WaitForSeconds(3.2f);
            fall.gameObject.SetActive(true);
            Trails.gameObject.SetActive(true);
            myscript.gameObject.GetComponent<Animator>().SetTrigger("Fall");

            yield return new WaitForSeconds(.3f);

            Apear.Play();


            yield return new WaitForSeconds(2.9f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Ah, muito melhor! Aquele pequenino ali és tu! ";

            yield return new WaitForSeconds(4.5f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Foste trazido aqui para aprender sobre a vida e os projetos..";
            yield return new WaitForSeconds(3.5f);
            typeOutScript.Star();
            typeOutScript.FinalText = "..da mente em que estás agora.";
            yield return new WaitForSeconds(3.5f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Ele é apaixonado por videojogos e pelo espaço, daí teres este aspeto.";
            yield return new WaitForSeconds(5.5f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Na nossa realidade, todos vemos e experienciamos o mundo de forma muito diferente..";
            yield return new WaitForSeconds(5f);
            typeOutScript.Star();
            typeOutScript.FinalText = "..o que torna difícil entendermo-nos uns aos outros.";
            yield return new WaitForSeconds(3f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Mas por sorte tua, isto não é a realidade, isto... é um videojogo!";

            yield return new WaitForSeconds(6f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Oh! Estamos a chegar.";

            yield return new WaitForSeconds(1f);
            myscript.gameObject.GetComponent<Rigidbody>().isKinematic = false;

            yield return new WaitForSeconds(6f);
            Fall.Play();
            yield return new WaitForSeconds(.5f);
            fall.gameObject.SetActive(false);
            myscript.gameObject.GetComponent<Animator>().SetTrigger("Arrive");

            yield return new WaitForSeconds(1f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Isto.. é o mundo do Rafael!";

            Cam.GetComponent<CinemachineBrain>().enabled = false;
            Cam.GetComponent<Animator>().Play("World");

            yield return new WaitForSeconds(3f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Este reflete a sua personalidade calma e está repleto dos seus projetos.";

            yield return new WaitForSeconds(5f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Tu estas aqui para aprender sobre esses projetos e divertir-te enquanto o fazes.";

            yield return new WaitForSeconds(5f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Podes escolher seguir a Estrada Amarela para uma jornada cronológica..";

            yield return new WaitForSeconds(4f);
            typeOutScript.Star();
            typeOutScript.FinalText = "..ou simplesmente explorar por tua conta. A escolha é tua.";

            yield return new WaitForSeconds(4f);
            typeOutScript.Star();
            typeOutScript.FinalText = "Começa por pressionar E ao lado do sinal de Informação ali.";

            Cam.GetComponent<CinemachineBrain>().enabled = true;

            yield return new WaitForSeconds(4f);
            typeOutScript.Star();
            typeOutScript.FinalText = "É tudo. Obrigado por ouvires e diverte-te!";
            
            yield return new WaitForSeconds(5f);
            myscript.enabled = true;
            myscript.gameObject.GetComponent<PlayerController_RB>().enabled = true;
            Game = true;
            Leg.SetActive(false);

            yield return new WaitForSeconds(25f);
            Leg.SetActive(true);
            typeOutScript.Star();
            typeOutScript.FinalText = "Procura e interage com as estatuas brancas para ver os projetos";


        }

    }

}
