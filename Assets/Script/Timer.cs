using System.Collections;
using System.Linq;
using UnityEngine;

public class RandomShuffleExample : MonoBehaviour
{
    int[] rnd = { 0, 1, 2 };
    public GameObject[] plateObj;
    int tmp = 0;
    float time = 3f;
    public bool isAns = true;

    void Start()
    {

        for (int i = 0; i < plateObj.Length; i++)
        {
            plateObj[i].SetActive(false);
        }
        // ランダム化
        rnd = rnd.OrderBy(x => UnityEngine.Random.value).ToArray();

        foreach (int i in rnd)
        {
            Debug.Log(i);
        }
        tmp = 0;
        StartCoroutine(TimerUI());
    }


    /// <summary>
    /// n秒に一回UIを変更する
    /// </summary>
    /// <returns></returns>
    IEnumerator TimerUI()
    {
        
        for (int i = 0; i < plateObj.Length; i++)
        {
            yield return StartCoroutine(WaitForSurvey());

            ChangeUI();
            yield return new WaitForSeconds(time);
            FalseUI();
        }
    }

    /// <summary>
    /// アンケ終了まで待つやつ
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForSurvey()
    {
        // isAnsがtrueになるまで待機
        yield return new WaitUntil(() => isAns == true);
        isAns = false;
    }


    /// <summary>
    /// UIを変更する際に呼び出す処理
    /// </summary>
    void ChangeUI()
    {
        for (int i = 0; i < plateObj.Length; i++)
        {
            if (i == rnd[tmp])
            {
                plateObj[i].SetActive(true);
            }
            else
            {
                plateObj[i].SetActive(false);
            }
        }
        tmp++;
    }


    void FalseUI()
    {
        for (int i = 0; i < plateObj.Length; i++)
        {
            plateObj[i].SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            ChangeUI();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isAns = true;
        }
    }
}
