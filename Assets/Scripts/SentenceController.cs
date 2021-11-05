using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentenceController : MonoBehaviour
{
    public Transform[] options = new Transform[5];
    private Bounds bounds;
    private Vector3[] originalPosition;

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
                        Debug.Log("Correct");
                        options[i].GetComponent<OptionController>().enabled = false;
                        SoundManager._instance.GoodJobPlay();
                        this.GetComponent<SentenceController>().enabled = false;
                    }
                    else
                    {
                        options[i].position = new Vector3(originalPosition[i].x, originalPosition[i].y, originalPosition[i].z);
                        SoundManager._instance.TryAgainPlay();
                    }
                }

            }

        }
    }
}
