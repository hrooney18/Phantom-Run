using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFadeScript : MonoBehaviour
{
    private float fadeDiff = 0.01f;
    private float initialTimer = 3.1f;
    private float timer;
    private float initialDelay = 1.2f;
    private float delay;
    private bool fade;
    private SpriteRenderer render;
    private Color color;

    void Start()
    {
        render = this.gameObject.GetComponent<SpriteRenderer>();
        color = render.color;
        timer = initialTimer;
        delay = initialDelay;
        fade = true;
    }
    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.fixedDeltaTime;
        delay = delay - Time.fixedDeltaTime;
        if (timer <= 0)
        {
            fade = !fade;
            if (fade)
            {
                timer = initialTimer;
                delay = initialDelay;
            }
            else if (!fade)
            {
                timer = initialTimer - initialDelay;
            }
        }
        if (fade && timer > 0 && delay <= 0)
        {
            color.a = color.a - fadeDiff;
            render.color = new Color(color.r, color.g, color.b, color.a);
        }
        if (!fade && timer > 0)
        {
            color.a = color.a + fadeDiff;
            render.color = new Color(color.r, color.g, color.b, color.a);
        }
    }
}
