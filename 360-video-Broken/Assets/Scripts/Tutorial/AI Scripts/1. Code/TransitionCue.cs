using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionCue : MonoBehaviour
{
    public Canvas canvas;
    public float scaleDuration = 0.5f;

    private float timer = 0;

    public void StartTransition()
    {
        timer = 0;
        canvas.GetComponent<RectTransform>().localScale = Vector3.zero;
        StartCoroutine(StartTransitionCoroutine());
    }

    public void EndTransition()
    {
        timer = 0;
        StartCoroutine(EndTransitionCoroutine());
    }

    private IEnumerator StartTransitionCoroutine()
    {
        while (timer < scaleDuration)
        {
            float t = timer / scaleDuration;
            canvas.GetComponent<RectTransform>().localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            timer += Time.deltaTime;
            yield return null;
        }
        canvas.GetComponent<RectTransform>().localScale = Vector3.one;
    }

    private IEnumerator EndTransitionCoroutine()
    {
        while (timer < scaleDuration)
        {
            float t = timer / scaleDuration;
            canvas.GetComponent<RectTransform>().localScale = Vector3.Lerp(Vector3.one, Vector3.zero, t);
            timer += Time.deltaTime;
            yield return null;
        }
        canvas.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
