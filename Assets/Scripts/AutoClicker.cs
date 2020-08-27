using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    public float delay;
    public Script script;

    public AudioSource backgroundMusic;
    public AudioSource robloxOff;

    private bool ready = true;

    void Update()
    {
        if(delay != 0f && ready)
        {
            ready = false;
            StartCoroutine(autoclick(delay));
        }
    }

    IEnumerator autoclick(float time)
    {
        if (backgroundMusic.mute == false)
        {
            robloxOff.Play();
        }
        script.clicks++;
        script.source.texture = script.happy;
        yield return new WaitForSeconds(0.1f);
        script.source.texture = script.regular;
        yield return new WaitForSeconds(time);
        ready = true;
    }
}
