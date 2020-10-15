using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    int[,] table;
    int currentState=0;
    int[] prices =new int[] { 20, 30, 40, 50 };
    public GameObject[] chipsPacks;
    public GameObject money;
    public Transform ProductTargetDrop;
    public Transform MoneyTargetDrop;
    public InputField input;
    public Text infoStatus;
    public GameObject[] chipsButtons;

    private void Awake()
    {
        table = new int[9, 8];
        table[0, 0] = 1;
        for (int i = 1; i < 5; i++)
        {
            table[i, 1] = i + 1;
        }
        table[5, 1] = 7;
        for (int i = 2; i < 6; i++)
        {
            table[6, i] = 7;
            table[7, i] = 6;
        }
        table[8, 6] = 8;
        table[8, 7] = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        TurnToStartState();
        //var temp = "";
        //for (int i = 0; i < table.GetLength(0); i++)
        //{
        //    for (int j = 0; j < table.GetLength(1); j++)
        //    {
        //        temp += table[i, j].ToString();
        //    }
        //    Debug.Log(temp);
        //    temp = "";
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChoseProduct1()
    {
        chipsButtons[0].GetComponent<Animator>().SetTrigger("Pressed");
        if (currentState == 1)
        {
            if (int.Parse(input.text) > prices[0])
            {
                currentState = 6;
                infoStatus.text = "выдача товара 1, выдача сдачи";
                GenerateChips(chipsPacks[0], ProductTargetDrop);
                StartCoroutine(ReturnMoney());
            }
            else if (int.Parse(input.text) == prices[0])
            {
                currentState = 6;
                infoStatus.text = "выдача товара 1";
                GenerateChips(chipsPacks[0], ProductTargetDrop);
            }
            else
            {
                infoStatus.text = "не хватает денег, возврат средств";
                StartCoroutine(ReturnMoney());
            }
            currentState = 7;
            currentState = 0;
            TurnToStartState();
        }
    }

    public void ChoseProduct2()
    {
        chipsButtons[1].GetComponent<Animator>().SetTrigger("Pressed");
        if (currentState == 1)
        {
            if (int.Parse(input.text) > prices[1])
            {
                currentState = 6;
                infoStatus.text = "выдача товара 2, выдача сдачи";
                GenerateChips(chipsPacks[1], ProductTargetDrop);
                StartCoroutine(ReturnMoney());
            }
            else if (int.Parse(input.text) == prices[1])
            {
                currentState = 6;
                infoStatus.text = "выдача товара 2";
                GenerateChips(chipsPacks[1], ProductTargetDrop);
            }
            else
            {
                infoStatus.text = "не хватает денег, возврат средств";
                StartCoroutine(ReturnMoney());
            }
            currentState = 7;
            currentState = 0;
            TurnToStartState();
        }
    }

    public void ChoseProduct3()
    {
        chipsButtons[2].GetComponent<Animator>().SetTrigger("Pressed");
        if (currentState == 1)
        {
            if (int.Parse(input.text) > prices[2])
            {
                currentState = 6;
                infoStatus.text = "выдача товара 3, выдача сдачи";
                GenerateChips(chipsPacks[2], ProductTargetDrop);
                StartCoroutine(ReturnMoney());
            }
            else if(int.Parse(input.text) == prices[2])
            {
                currentState = 6;
                infoStatus.text = "выдача товара 3";
                GenerateChips(chipsPacks[2], ProductTargetDrop);
            }
            else
            {
                infoStatus.text = "не хватает денег, возврат средств";
                StartCoroutine(ReturnMoney());
            }
            currentState = 7;
            currentState = 0;
            TurnToStartState();
        }
    }

    public void ChoseProduct4()
    {
        chipsButtons[3].GetComponent<Animator>().SetTrigger("Pressed");
        if (currentState == 1)
        {
            if (int.Parse(input.text) > prices[3])
            {
                currentState = 6;
                infoStatus.text = "выдача товара 4, выдача сдачи";
                GenerateChips(chipsPacks[3], ProductTargetDrop);
                StartCoroutine(ReturnMoney());
            }
            else if (int.Parse(input.text) == prices[3])
            {
                currentState = 6;
                infoStatus.text = "выдача товара 4";
                GenerateChips(chipsPacks[3], ProductTargetDrop);
            }
            else
            {
                infoStatus.text = "не хватает денег, возврат средств";
                StartCoroutine(ReturnMoney());
            }
            currentState = 7;
            currentState = 0;
            TurnToStartState();
        }
    }

    public void Confirm()
    {
        if (currentState == 0 && int.Parse(input.text) > 0)
        {
            StopAllCoroutines();
            currentState = 1;
            infoStatus.text = "у вас на счету " + input.text + " рублей";
        }
    }

    public void Cancel()
    {
        if (currentState == 1 && int.Parse(input.text) > 0)
        {
            currentState = 7;
            infoStatus.text = "отмена операции, выдача сдачи " + input.text + " рублей";
            input.text = "0";
            StartCoroutine(ReturnMoney());
            currentState = 0;
        }
    }

    public void TurnToStartState()
    {
        input.text = "0";
        infoStatus.text = "у вас на счету 0 рублей";
    }

    IEnumerator ReturnMoney()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.25f);
            Instantiate(money, MoneyTargetDrop.position, Quaternion.identity);
            Debug.Log("Returning Money!!!");        
        }
    }

    void GenerateChips(GameObject obj, Transform target)
    {
        Instantiate(obj, target.position, Quaternion.identity);
    }    
}
