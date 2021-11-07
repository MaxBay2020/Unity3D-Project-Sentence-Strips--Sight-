using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentenceController : MonoBehaviour
{
    public Transform[] options = new Transform[5];
    private Bounds bounds;
    private Vector3[] originalPosition;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        bounds = this.GetComponent<BoxCollider2D>().bounds;
        originalPosition = new Vector3[] { options[0].position, options[1].position, options[2].position, options[3].position, options[4].position };
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < options.Length; i++)
        {
            Vector3 optionPosition = options[i].position;
            bool inside = bounds.Contains(optionPosition);
            if (inside)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    if(this.name.Contains(options[i].name))
                    {
                        // correct
                        Debug.Log("Correct");
                        options[i].GetComponent<OptionController>().WholeSentencePlay();
                        options[i].GetComponent<OptionController>().enabled = false;
                        //SoundManager._instance.GoodJobPlay();
                        //this.GetComponent<SentenceController>().enabled = false;

                        float seconds = options[i].GetComponent<OptionController>().wordWithSentenceClip.length + 0.5f;
                        StartCoroutine(PlayGoodJobClipAfterSec(seconds));
                    }
                    else
                    {
                        // wrong
                        //SoundManager._instance.TryAgainPlay();
                        //options[i].position = new Vector3(originalPosition[i].x, originalPosition[i].y, originalPosition[i].z);
                        options[i].GetComponent<OptionController>().WholeSentencePlay();
                        options[i].GetComponent<OptionController>().enabled = false;
                        float seconds = options[i].GetComponent<OptionController>().wordWithSentenceClip.length + 0.5f;
                        StartCoroutine(PlayTryAgainClipAfterSec(seconds, i));
                    }
                }

            }

        }
    }

    IEnumerator PlayGoodJobClipAfterSec(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SoundManager._instance.GoodJobPlay();
        this.GetComponent<SentenceController>().enabled = false;
    }

    IEnumerator PlayTryAgainClipAfterSec(float seconds, int i)
    {
        yield return new WaitForSeconds(seconds);
        SoundManager._instance.TryAgainPlay();
        options[i].position = new Vector3(originalPosition[i].x, originalPosition[i].y, originalPosition[i].z);
        options[i].GetComponent<OptionController>().enabled = true;
    }
}
