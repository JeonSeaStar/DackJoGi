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

    [SerializeField] GameObject elementPrefab;
    [SerializeField] List<Element> listElements = new List<Element>();

    [SerializeField] RectTransform highLight;

    [SerializeField] List<MachineGuide> guideList;
    public int advancedGuide;
    public int currentGuide;

    public float delay;
    int t = 0;

    public Transform player;
    public Transform playerParent;
    public Transform menuCanvas;
    public Vector3 menuPosition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            NextGuide();
        if (OVRInput.GetDown(OVRInput.Button.Two))
            NextGuide();

        playerParent.position = player.position;
        menuCanvas.position = player.position + menuPosition;
    }

    IEnumerator OutputText(string s)
    {
        guideTextBox.guideText.text += s[t];
        yield return new WaitForSeconds(delay);
        if (t < s.Length - 1)
        {
            t++;
            StartCoroutine("OutputText", s);
        }
        else
        {
            yield return new WaitForSeconds(5);
            guideTextBox.box.SetActive(false);
            StopCoroutine("OutputText");
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
        SetPartsIndex();
        ChangeContent();
    }

    public void SelectParts(int i)
    {
        selectedParts = i;
        ChangeContent();
        StartGuide();
    }

    public void SelectGuide(int i)
    {
        currentGuide = i;
        GuideTextBox(i);
    }

    void GuideTextBox(int i)
    {
        guideTextBox.box.SetActive(true);
        List<Guide> guide = guideList[selectedMachine].parts[selectedParts].guide;
        guideTextBox.guideTitle.text = guide[currentGuide].guideTitle;
        t = 0;
        guideTextBox.guideText.text = "";
        StopCoroutine("OutputText");
        StartCoroutine("OutputText", guide[currentGuide].guideText);

        GuideHighLight(i);
    }

    void GuideHighLight(int i)
    {
        foreach(Element highlight in listElements)
            highlight.highlight.SetActive(false);

        listElements[i].highlight.SetActive(true);
    }

    void StartGuide()
    {
        SetGuideIndex();
        advancedGuide = 0;
        currentGuide = 0;
        listElements[currentGuide].gameObject.SetActive(true);
        GuideTextBox(currentGuide);
    }

    void NextGuide()
    {
        advancedGuide++;
        currentGuide = advancedGuide;
        GuideTextBox(currentGuide);
        listElements[currentGuide].gameObject.SetActive(true);
    }

    void SetPartsIndex()
    {
        InitListElements();

        for (int i = 0; i < guideList[selectedMachine].parts.Count; i++)
        {
            GameObject partElement = Instantiate(elementPrefab, contentList[1].transform);
            partElement.name = "partElement[" + i + "]";
            Element element = partElement.GetComponent<Element>();
            element.title.text = guideList[selectedMachine].parts[i].parts;
            element.explain.text = guideList[selectedMachine].parts[i].explain;
            element.index = i;
            element.button.onClick.AddListener(() => SelectParts(element.index));
            listElements.Add(element);
        }
    }

    void SetGuideIndex()
    {
        InitListElements();
        List<Guide> guide = guideList[selectedMachine].parts[selectedParts].guide;

        for (int i = 0; i < guide.Count; i++)
        {
            GameObject partElement = Instantiate(elementPrefab, contentList[2].transform);
            partElement.name = "guideElement[" + i + "]";
            partElement.SetActive(false);
            Element element = partElement.GetComponent<Element>();
            element.title.text = guide[i].guideTitle;
            element.explain.text = guide[i].guideText;
            element.BoxSize();
            element.index = i;
            element.button.onClick.AddListener(() => SelectGuide(element.index));
            listElements.Add(element);
        }
    }

    void InitListElements()
    {
        foreach (var item in listElements)
            Destroy(item.gameObject);
        listElements = new List<Element>();
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
    public string explain;
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