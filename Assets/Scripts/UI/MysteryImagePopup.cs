
using UnityEngine;
using System.Collections;

public class MysteryImagePopup : MonoBehaviour
{
    public float animationDuration = 0.5f;
    public float startScale = 0.1f;

    private Vector3 targetScale;

    private void Start()
    {
        targetScale = transform.localScale;
        transform.localScale = Vector3.one * startScale;

        StartCoroutine(PopUp());
    }

    private IEnumerator PopUp()
    {
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;

            float progress = elapsedTime / animationDuration;
            float smoothProgress = Mathf.SmoothStep(0f, 1f, progress);

            transform.localScale = Vector3.Lerp(
                Vector3.one * startScale,
                targetScale,
                smoothProgress
            );

            yield return null;
        }

        transform.localScale = targetScale;
    }
}
