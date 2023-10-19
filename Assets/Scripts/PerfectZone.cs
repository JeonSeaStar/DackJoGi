using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerfectZone : MonoBehaviour
{
    [SerializeField] private Color[] ringColour = new Color[3];
    [SerializeField] private float[] section = new float[3];
    [SerializeField] private bool[] colourChanged = new bool[2];
    [SerializeField] private Image fill;
    [SerializeField] private float t = 0;
    [SerializeField] private Animator anime;

    public IEnumerator FillRing()
    {
        fill.fillAmount += 0.001f;
        yield return new WaitForSeconds(0.01f);
        if (fill.fillAmount != 1)
        {
            StartCoroutine(FillRing());

            if (fill.fillAmount > section[0] && fill.fillAmount < section[1] && !colourChanged[0])
            {
                StartCoroutine(RingColourChange());
                anime.SetTrigger("ColourChange");
                colourChanged[0] = true;
            }
            else if (fill.fillAmount > section[1] && !colourChanged[1])
            {
                StartCoroutine(RingColourChange());
                anime.SetTrigger("ColourChange");
                colourChanged[1] = true;
            }
        }
    }

    private IEnumerator RingColourChange()
    {
        int colourIndex = CurrentColour();
        fill.color = Color.Lerp(ringColour[colourIndex], ringColour[colourIndex + 1], t);

        t += 0.01f;
        yield return new WaitForSeconds(0.001f);
        if (t < 1)
            StartCoroutine(RingColourChange());
        else
            t = 0;
    }

    private int CurrentColour()
    {
        int index = -1;

        if (fill.fillAmount > section[0] && fill.fillAmount < section[1])
            index = 0;
        else if (fill.fillAmount > section[1])
            index = 1;

        return index;
    }

    private void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back, Camera.main.transform.rotation * Vector3.up);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(FillRing());
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(RingColourChange());
        }
    }
}
