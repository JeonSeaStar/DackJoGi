using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TabletScreen : MonoBehaviour
{
    [SerializeField] private Transform canvasCenter;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 canvasPosition;
    [SerializeField] private Animator tabletAnimator;

    [Header("태블릿 바탕화면")]
    [SerializeField] private GameObject tablet;
    [SerializeField] private List<GameObject> applicationScreenArray = new List<GameObject>();
    [SerializeField] private Animator[] applicationAnimatorArray = new Animator[2];

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

    [Header("결과 팝업")]
    [SerializeField] private TextMeshProUGUI[] resultText = new TextMeshProUGUI[6];

    [SerializeField] private int pocket;
    [SerializeField] private int profit;
    [SerializeField] private int maintenanceCost;
    [SerializeField] private int bought;
    [SerializeField] private int tips;
    [SerializeField] private int total;

    public void OpenApplication(GameObject applicationScreen)
    {
        applicationAnimatorArray[applicationScreenArray.IndexOf(applicationScreen)].SetTrigger("Active");
        StartCoroutine(ActiveGameObject(applicationScreen, 0.5f));
    }

    public void CloseApplication()
    {
        CloseRequestContents();
        ClosePracticeContents();

        foreach (GameObject app in applicationScreenArray)
            app.SetActive(false);
    }

    public void OpenTablet()
    {
        CloseApplication();
        tablet.SetActive(true);
        tabletAnimator.SetTrigger("Open");
    }

    public void CloseTablet()
    {
        CloseApplication();
        tabletAnimator.SetTrigger("Close");

        Invoke("OffTablet", 1f);
    }

    private void OffTablet()
    {
        tablet.SetActive(false);
    }

    public void HomeButton()
    {
        CloseApplication();
    }

    public void SetActiveFlase(GameObject target) => target.SetActive(false);

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
        if (currentStep != progressList.Count)
        {
            progressList[currentStep].clearLineImage.gameObject.SetActive(true);
            StartCoroutine(FillImage(progressList[currentStep]));
            currentStep++;
        }
    }

    private IEnumerator ActiveGameObject(GameObject target, Animator animator, string trigger, float time)
    {
        yield return new WaitForSeconds(time);
        target.SetActive(true);
        animator.SetTrigger(trigger);
    }

    private IEnumerator ActiveGameObject(GameObject target, float time)
    {
        yield return new WaitForSeconds(time);
        target.SetActive(true);
    }

    private IEnumerator FillImage(Step step)
    {
        yield return new WaitForSeconds(0.001f);

        if (step.clearLineImage.fillAmount != 1)
        {
            step.clearLineImage.fillAmount += 0.01f;
            StartCoroutine(FillImage(step));
        }
        else
        {
            StartCoroutine(ActiveGameObject(step.clearRoundImage.gameObject, step.anime, "Clear", 0.3f));
            if (currentStep != 0 && currentStep != progressList.Count)
                StartCoroutine(ActiveGameObject(progressGameObjectList[currentStep], 0.4f));
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
    #endregion
    #region 결과창
    private IEnumerator ScoreCalculate(int targetIndex)
    {
        yield return new WaitForSeconds(0.01f);
        if (int.Parse(resultText[targetIndex].text) != 0)
        {
            resultText[targetIndex].text = (int.Parse(resultText[targetIndex].text) - 1).ToString();
            resultText[resultText.Length - 1].text = (int.Parse(resultText[resultText.Length - 1].text) + 1).ToString();
            StartCoroutine(ScoreCalculate(targetIndex));
        }
        else if (int.Parse(resultText[targetIndex].text) != 0 && targetIndex != resultText.Length - 1)
            StartCoroutine(ScoreCalculate(targetIndex + 1));
    }

    private IEnumerator OpenResultPopup()
    {
        float delay = 0;
        foreach (var text in resultText)
        {
            StartCoroutine(ActiveGameObject(text.gameObject, delay));
            delay += 0.5f;
        }

        yield return new WaitForSeconds(delay + 1f);

        StartCoroutine(ScoreCalculate(0));
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
