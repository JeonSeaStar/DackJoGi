using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabletScreen : MonoBehaviour
{
    [Header("태블릿 바탕화면")]
    [SerializeField] private GameObject tablet;
    [SerializeField] private GameObject[] applicationScreenArray = new GameObject[2];

    [Header("의뢰 화면")]
    [SerializeField] private GameObject requestScreen;
    [SerializeField] private List<RequestContents> requestButton = new List<RequestContents>();
    [SerializeField] private RequestContentsObject requestContentsObject;
    private int currentRequestIndex;

    [Header("연습 화면")]
    [SerializeField] private GameObject practiceScreen;
    [SerializeField] private float[] size = { 512, 1384 };
    [SerializeField] private float[] positionX = { 256, 692 };
    [SerializeField] private List<PracticeContents> practiceContents = new List<PracticeContents>();
    private int currentPracticeIndex;

    [Header("진행 상황 안내")]
    [SerializeField] private int currentStep;
    [SerializeField] private Transform progressParent;
    [SerializeField] private GameObject startStepPrefab;
    [SerializeField] private GameObject stepPrefab;
    [SerializeField] private List<RequestStep> requestList = new List<RequestStep>();
    [SerializeField] private List<GameObject> progressGameObjectList = new List<GameObject>();
    [SerializeField] private List<Step> progressList = new List<Step>();

    public void OpenApplication(GameObject applicationScreen) => applicationScreen.SetActive(true);
    public void CloseApplication()
    {
        CloseRequestContents();
        ClosePracticeContents();

        foreach (GameObject app in applicationScreenArray)
            app.SetActive(false);
    }

    public void CloseTablet()
    {
        CloseApplication();

        tablet.SetActive(false);
    }

    #region 의뢰화면
    private void OpenRequestContents()
    {
        if (!requestContentsObject.contentsObject.activeSelf)
            requestContentsObject.contentsObject.SetActive(true);
    }

    private void CloseRequestContents()
    {
        if (!requestContentsObject.contentsObject.activeSelf)
            requestContentsObject.contentsObject.SetActive(false);

        currentRequestIndex = -1;
    }

    public void SetContents(int index)
    {
        OpenRequestContents();

        requestContentsObject.modelName.text = requestButton[index].modelName;
        requestContentsObject.contents.text = requestButton[index].contents;
        requestContentsObject.reward.text = requestButton[index].reward + "만원";
        requestContentsObject.date.text = requestButton[index].date + "일";

        currentRequestIndex = index;
    }

    public void AcceptRequest()
    {
        CloseRequestContents();
    }
    #endregion
    #region 연습화면
    private void ClosePracticeContents()
    {
        practiceScreen.SetActive(false);

        foreach (var item in practiceContents)
            ChangeButtonState(item, 0);

        currentPracticeIndex = -1;
    }

    public void OpenPracticeContents(int index)
    {
        foreach (var item in practiceContents)
        {
            ChangeButtonState(item, 0);
            item.contents.SetActive(false);
        }

        ChangeButtonState(practiceContents[index], 1);
        practiceContents[index].contents.SetActive(true);

        currentPracticeIndex = index;
    }

    private void ChangeButtonState(PracticeContents target, int targetState)
    {
        target.buttonImage.sprite = target.buttonSprite[targetState];

        Vector2 size = target.buttonParent.GetComponent<RectTransform>().sizeDelta;
        Vector3 position = target.buttonParent.GetComponent<RectTransform>().localPosition;
        target.buttonParent.GetComponent<RectTransform>().sizeDelta = new Vector2(this.size[targetState], size.y);
        target.buttonParent.GetComponent<RectTransform>().localPosition = new Vector3(positionX[targetState], position.y, position.z);

        Vector2 size2 = target.button.GetComponent<RectTransform>().sizeDelta;
        target.button.GetComponent<RectTransform>().sizeDelta = new Vector2(this.size[targetState], size2.y);
    }

    public void StartPractice(int index)
    {
        ClosePracticeContents();
    }
    #endregion
    #region 진행 상황 안내
    private void SetProgressGuide(RequestStep requestStep)
    {
        Vector3 spawnPoint = progressParent.position;
        GameObject startStepGameObject = Instantiate(startStepPrefab, spawnPoint, Quaternion.identity, progressParent);
        Step startStep = startStepGameObject.GetComponent<Step>();
        startStep.count.text = "1";
        startStep.explain.text = requestStep.explain[0];
        progressGameObjectList.Add(startStepGameObject);
        progressList.Add(startStep);

        for (int i = 0; i < requestStep.explain.Count - 1; i++)
        {
            GameObject stepGameObject = Instantiate(stepPrefab, spawnPoint, Quaternion.identity, progressParent);
            stepGameObject.SetActive(false);
            Step step = stepGameObject.GetComponent<Step>();
            step.count.text = (i + 2).ToString();
            step.explain.text = requestStep.explain[i + 1];
            progressGameObjectList.Add(stepGameObject);
            progressList.Add(step);
        }
    }

    private void NextStep(int i)
    {
        progressList[currentStep].clearRoundImage.gameObject.SetActive(true);
        if(currentStep != 0)
        {
            progressList[currentStep].clearLineImage.gameObject.SetActive(true);
            StartCoroutine(FillImage(progressList[currentStep].clearLineImage));
        }
        currentStep++;
        progressGameObjectList[currentStep].SetActive(true);
    }

    private IEnumerator FillImage(Image fillImage)
    {
        yield return new WaitForSeconds(0.001f);

        if (fillImage.fillAmount != 1)
        {
            fillImage.fillAmount += 0.01f;
            StartCoroutine(FillImage(fillImage));
        }
    }

    private void InitializeStep()
    {
        currentStep = 0;
        foreach (var progressGameObject in progressGameObjectList)
            Destroy(progressGameObject);
        progressGameObjectList = new List<GameObject>();
        progressList = new List<Step>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SetProgressGuide(requestList[0]);
        if (Input.GetKeyDown(KeyCode.S))
            NextStep(currentStep);
    }
    #endregion
}

[System.Serializable]
public class RequestContentsObject
{
    public GameObject contentsObject;
    public TextMeshProUGUI modelName;
    public TextMeshProUGUI contents;
    public TextMeshProUGUI reward;
    public TextMeshProUGUI date;
}

[System.Serializable]
public class RequestContents
{
    public GameObject contentsObject;
    public string modelName;
    public string contents;
    public string reward;
    public string date;
}

[System.Serializable]
public class PracticeContents
{
    public Sprite[] buttonSprite = new Sprite[2];
    public Image buttonImage;
    public GameObject buttonParent;
    public GameObject button;
    public GameObject contents;
}

[System.Serializable]
public class RequestStep
{
    public string practiceName;
    public List<string> explain;
}
