using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTint : MonoBehaviour
{
    [SerializeField] Color unTintedColor;
    [SerializeField] Color tintedColor;

    float f;
    [SerializeField] float speed = 0.5f;
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();

    }
    private void Start()
    {
        Tint();
    }
    public void Tint()
    {
        f = 0f;
        StartCoroutine(TintScreen());
    }

    public void UnTint()
    {
        f = 0f;
        StartCoroutine(UnTintScreen());
    }

    private IEnumerator TintScreen()
    {
        while(f < 1f)
        {
            f += Time.deltaTime * speed;
            f = Mathf.Clamp(f, 0, 1f);

            Color c = image.color;
            c = Color.Lerp(unTintedColor, tintedColor,f);
            image.color = c;

            yield return new WaitForEndOfFrame();

        }
        UnTint();
    }
    private IEnumerator UnTintScreen()
    {
        while (f < 1f)
        {
            f += Time.deltaTime * speed;
            f = Mathf.Clamp(f, 0, 1f);

            Color c = image.color;
            c = Color.Lerp(tintedColor, unTintedColor, f);
            image.color = c;

            yield return new WaitForEndOfFrame();

        }
    }
}
