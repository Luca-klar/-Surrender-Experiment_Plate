using System.Linq;
using UnityEngine;

public class RandomShuffleExample : MonoBehaviour
{
    int[] rnd = { 0, 1, 2 };
    public GameObject[] plateObj;
    int tmp = 0;
    void Start()
    {

        for (int i = 0; i < plateObj.Length; i++)
        {
            plateObj[i].SetActive(false);
        }
        // ƒ‰ƒ“ƒ_ƒ€‰»
        rnd = rnd.OrderBy(x => UnityEngine.Random.value).ToArray();

        foreach (int i in rnd)
        {
            Debug.Log(i);
        }
        tmp = 0;
    }


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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            ChangeUI();
        }
    }
}
