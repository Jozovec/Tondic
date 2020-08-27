using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;
using TMPro;

public class Console : MonoBehaviour
{
    public TMP_InputField inputField;

    public Script script;
    public AudioSource robloxOff;

    // Start is called before the first frame update
    void Start()
    {
        inputField.text = "";
    }

    // Update is called once per frame
    public void getCommand()
    {
        string input = inputField.text.ToString().ToUpper();

        if (input.Contains("UWU@SETSCORE#"))
        {
            string number = input.Remove(0, 13);
            int value;
            if (int.TryParse(number, out value))
            {
                if (value <= 999999 && !script.won)
                {
                    script.clicks = value;
                    robloxOff.Play();
                    inputField.text = "";
                }
            }
        }

        if (input.Contains("UWU@ADDSCORE#"))
        {
            string number = input.Remove(0, 13);
            int value;
            if (int.TryParse(number, out value))
            {
                if (script.clicks + value <= 999999 && !script.won)
                {
                    script.clicks += value;
                    robloxOff.Play();
                    inputField.text = "";
                }
            }
        }

        if (input == "UWU@GAMERESET")
        {
            script.clicks = 0;
            script.won = false;
            inputField.text = "";
            robloxOff.Play();
        }
    }
}
