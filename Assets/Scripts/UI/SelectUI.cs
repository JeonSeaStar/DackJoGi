using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectUI : MonoBehaviour
{
    [SerializeField] ScrollRect scrollRect;

    [SerializeField] List<GameObject> contentList;
    [SerializeField] int currentContent;

    [SerializeField] int selectedMachine;
    [SerializeField] int selectedParts;
    [SerializeField] GuideBox guideTextBox;

    [SerializeField] List<MachineGuide> guideList;
    public int advancedGuide;
    public int currentGuide;

    public float delay;
    int t = 0;

    IEnumerator OutputText(string s)
    {
        guideTextBox.guideText.text += s[t];
        yield return new WaitForSeconds(delay);
        if (t < s.Length - 1)
        {
            t++;
            StartCoroutine(OutputText(s));
        }
    }

    void InitContent()
    {
        scrollRect.content.gameObject.SetActive(false);
        scrollRect.content = contentList[0].GetComponent<RectTransform>();
        contentList[0].SetActive(true);
        currentContent = 0;
    }

    public void ChangeContent()
    {
        contentList[currentContent].SetActive(false);

        if (currentContent == contentList.Count - 1)
            currentContent = 0;
        else
            currentContent++;

        scrollRect.content = contentList[currentContent].GetComponent<RectTransform>();
        contentList[currentContent].SetActive(true);
    }

    public void ReturnContent()
    {
        ChangeContent();
        advancedGuide = -1;
        currentGuide = -1;
    }

    public void SelectMachine(int i)
    {
        selectedMachine = i;
        ChangeContent();
    }

    public void SelectParts(int i)
    {
        selectedParts = i;
        ChangeContent();
        StartGuide();
    }

    void GuideTextBox()
    {
        guideTextBox.box.SetActive(true);
        List<Guide> guide = guideList[selectedMachine].parts[selectedParts].guide;
        guideTextBox.guideTitle.text = guide[currentGuide].guideTitle;
        StartCoroutine(OutputText(guide[currentGuide].guideText));
    }

    void StartGuide()
    {
        advancedGuide = 0;
        currentGuide = 0;
        GuideTextBox();
    }

    void NextGuide()
    {
        currentGuide++;
        GuideTextBox();
    }

    void SetGuideIndex()
    {

    }
}

[System.Serializable]
class MachineGuide
{
    public string machine;
    public List<PartsList> parts;
}

[System.Serializable]
class PartsList
{
    public string parts;
    public List<Guide> guide;
}

[System.Serializable]
class GuideBox
{
    public GameObject box;
    public TextMeshProUGUI guideTitle;
    public TextMeshProUGUI guideText;
}

[System.Serializable]
class Guide
{
    [TextArea] public string guideTitle;
    [TextArea] public string guideText;
}