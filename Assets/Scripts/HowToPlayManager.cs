using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayManager : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Sprite[] sprites;

    int index = 0;

    public void Next()
    {
        index++;
        if (index >= sprites.Length)
        {
            index = 0;
        }
        image.sprite = sprites[index];
    }

    public void Previous()
    {
        index--;
        if (index < 0)
        {
            index = sprites.Length - 1;
        }
        image.sprite = sprites[index];
    }
}
