using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CANVAORB : MonoBehaviour
{

    public float current = 1;

    public float S = 1;

    public GameObject C1;
    public GameObject C2;
    public GameObject C3;
    public GameObject C4;

    public GameObject Buttt;

    public GameObject Text;

    [SerializeField]
    private AudioSource Bot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (current)
        {
            case 1:

                C1.SetActive(true);
                C2.SetActive(false);
                C3.SetActive(false);
                C4.SetActive(false);

                Buttt.SetActive(true);

                Text.GetComponent<TextMeshProUGUI>().text = "1/4";

                break;
            case 2:

                C1.SetActive(false);
                C2.SetActive(true);
                C3.SetActive(false);
                C4.SetActive(false);

                Buttt.SetActive(false);

                Text.GetComponent<TextMeshProUGUI>().text = "2/4";

                break;
            case 3:

                C1.SetActive(false);
                C2.SetActive(false);
                C3.SetActive(true);
                C4.SetActive(false);

                Buttt.SetActive(false);

                Text.GetComponent<TextMeshProUGUI>().text = "3/4";

                break;
            case 4:

                C1.SetActive(false);
                C2.SetActive(false);
                C3.SetActive(false);
                C4.SetActive(true);

                Buttt.SetActive(false);

                Text.GetComponent<TextMeshProUGUI>().text = "4/4";

                break;
        }
    }



    public void Right ()

    {
        Bot.Play();
        Debug.Log("AAAA");


        switch (current)
        {
            case 1:

                current = 2;

                break;
            case 2:

                current = 3;

                break;
            case 3:

                current = 4;

                break;
            case 4:

                current = 1;

                break;
        }
    }

    public void Left()
    {
        Bot.Play();
        switch (current)
        {
            case 1:

                current = 4;

                break;
            case 2:

                current = 1;

                break;
            case 3:

                current = 2;

                break;
            case 4:

                current = 3;

                break;
        }
    }

    public void Play()
    {

        Debug.Log("Teste");
        switch (S)
        {
            case 1:

                Application.OpenURL("https://rafinha-uwu.itch.io/");

                break;
            case 2:

                Application.OpenURL("https://drive.google.com/file/d/1Hwct40OmeTFiALBDsg0fbwA4n3Ln2CBd/view");

                break;
            case 3:

                Application.OpenURL("https://rafinha-uwu.itch.io/constelations");

                break;
            case 4:

                Application.OpenURL("https://rafinha-uwu.itch.io/dream-demon-escape-room");

                break;
            case 5:

                Application.OpenURL("https://rafinha-uwu.itch.io/anniear");

                break;
            case 6:

                Application.OpenURL("https://rafinha-uwu.itch.io/child");

                break;
            case 7:

                Application.OpenURL("https://rafinha-uwu.itch.io/qquack");

                break;
            case 8:

                Application.OpenURL("https://rafinha-uwu.itch.io/");

                break;
        }
    }


}
