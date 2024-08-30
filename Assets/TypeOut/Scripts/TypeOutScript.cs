using TMPro;
using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class TypeOutScript : MonoBehaviour
{
    public bool On = true;
    public bool reset = true;
    public string FinalText;

    public float TotalTypeTime = -1f;

    public float TypeRate;
    private float LastTime;

    public string RandomCharacter;
    public float RandomCharacterChangeRate = 0.1f;
    private float RandomCharacterTime;

    public int i;

    private string RandomChar()
    {
        byte value = (byte)UnityEngine.Random.Range(41f, 128f);

        string c = System.Text.Encoding.ASCII.GetString(new byte[] { value });

        return c;

    }

    public void Skip()
    {
        GetComponent<TextMeshProUGUI>().text = FinalText;
        On = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TotalTypeTime != -1f)
        {
            TypeRate = TotalTypeTime / (float)FinalText.Length;
        }

        if (On == true)
        {

            if (Time.time - RandomCharacterTime >= RandomCharacterChangeRate)
            {
                RandomCharacter = RandomChar();
                RandomCharacterTime = Time.time;
            }

            try
            {
                GetComponent<TextMeshProUGUI>().text = FinalText.Substring(0, i) + RandomCharacter;
            }
            catch (ArgumentOutOfRangeException)
            {
                On = false;
            }

            if (Time.time - LastTime >= TypeRate)
            {
                i++;
                LastTime = Time.time;
            }

            bool isChar = false;

            while (isChar == false)
            {
                if ((i + 1) < FinalText.Length)
                {
                    if (FinalText.Substring(i, 1) == " ")
                    {
                        i++;
                    }
                    else
                    {
                        isChar = true;
                    }
                }
                else
                {
                    isChar = true;
                }
            }

            if (GetComponent<TextMeshProUGUI>().text.Length == FinalText.Length + 1)
            {
                RandomCharacter = RandomChar();
                GetComponent<TextMeshProUGUI>().text = FinalText;
                On = false;
            }

        }

        if (reset == true)
        {
            GetComponent<TextMeshProUGUI>().text = "";
            i = 0;
            reset = false;
        }
    }

    public void Star() { StartCoroutine(Type()); }

    public IEnumerator Type()
    {
        reset = true;
        yield return new WaitForSeconds(0.2f);
        On = true;
    }
}
