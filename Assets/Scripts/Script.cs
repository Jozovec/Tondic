using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using BayatGames.SaveGameFree;
using System.Runtime.InteropServices.WindowsRuntime;

public class Script : MonoBehaviour
{
    public Texture2D regular;
    public Texture2D happy;

    public RawImage source;
    public TMP_Text counter;
    public TMP_Text rank;
    public GameObject victory;

    public string[] ranks;

    public int clicks;

    public float x;
    public bool won;

    public Sprite mute;
    public Sprite sound;

    public Image muteIcon;
    public bool muted;

    public AudioSource backgroundMusic;
    public AudioSource robloxOff;

    void Start()
    {
        muted = !SaveGame.Load<bool>("muted");
        toggleMute();

        won = SaveGame.Load<bool>("won");
        clicks = SaveGame.Load<int>("score");
    }

    void Update()
    {
        if(clicks > 999999)
        {
            won = true;
            SaveGame.Save<bool>("won", won);
            SaveGame.Save<int>("score", clicks);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (backgroundMusic.mute == false)
            {
                robloxOff.Play();
            }
            source.texture = happy;
            clicks++;
        }
        if (Input.GetMouseButtonUp(0))
        {
            source.texture = regular;
        }

        if (!won)
        {
            victory.SetActive(false);
            x = 1f + ((clicks - 0f) * (0f - 1f)) / (999999f - 0f);
            source.color = new Color(1f, x, x, 1f);
            rank.text = ranks[clicks.ToString().Length - 1];
            counter.text = clicks.ToString("D6");
        }
        else
        {
            victory.SetActive(true);
            source.color = new Color(1f, 0.725f, 0f, 1f);
            rank.text = "winner winner\nchicken dinner";
            counter.text = "infinite";
        }

        SaveGame.Save<int>("score", clicks);
        SaveGame.Save<bool>("won", won);
    }


    public void toggleMute()
    {
        if (!muted)
        {
            backgroundMusic.mute = true;
            robloxOff.mute = true;
            muteIcon.sprite = mute;
            muted = true;
            SaveGame.Save<bool>("muted", muted);
        }
        else
        {
            backgroundMusic.mute = false;
            robloxOff.mute = false;
            muteIcon.sprite = sound;
            muted = false;
            SaveGame.Save<bool>("muted", muted);
        }
    }
}
