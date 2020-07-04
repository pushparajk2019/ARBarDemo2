using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
public class GraphController : MonoBehaviour
{
    [SerializeField]
    API api;
    [SerializeField]
    TextMeshPro title;
    [SerializeField]
    List<BarBehaviour> bars = new List<BarBehaviour>();
    public float waitTime=1;
    public float barScale=5000;
    void Start()
    {
        api.GetTimeData(OnDataReceived);
    }

    void OnDataReceived(List<TimeData> dataList)
    {
        StartCoroutine(CycleDataRoutine(dataList));
    }

    IEnumerator CycleDataRoutine(List<TimeData> dataList)
    {
        while (true)
        {

        
            foreach (TimeData data in dataList)
            {
                title.text = data.date.ToString("MMMM dd, yyyy");
                bars[0].SetScale(data.tested / barScale);
                bars[1].SetScale(data.positives / barScale);
                bars[2].SetScale(data.deaths / barScale);
                yield return new WaitForSeconds(waitTime);
            }
            
            foreach(BarBehaviour bar in bars)
            {
                bar.Reset();
            }
        }
    }
}
