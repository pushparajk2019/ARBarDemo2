using System.Collections; 
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using System.Linq;
using System;

public class API : MonoBehaviour
{
    const string ENDPOINT = "http://coronavirusapi.com/time_series.csv";

    public void GetTimeData(UnityAction<List<TimeData>> callback)
    {
        StartCoroutine(GetTimeDataRoutine(callback));
    }

    IEnumerator GetTimeDataRoutine(UnityAction<List<TimeData>> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(ENDPOINT);
        yield return request.SendWebRequest();
        if (request.isNetworkError)
        {
            UnityEngine.Debug.Log("Network Error");
        } else
        {
            callback(ParseData(request.downloadHandler.text));
        }

        List<TimeData> ParseData(string data)
        {
            // date,time,seconds_since_Epoch,tested,positive,deaths
            //UnityEngine.Debug.Log("data = " + data);
            List<string> lines = data.Split('\n').ToList();
            UnityEngine.Debug.Log("First lines.count= " + lines.Count.ToString());
            lines.RemoveAt(0);
            lines.RemoveAt(lines.Count - 1);
            UnityEngine.Debug.Log("final lines.count= " + lines.Count.ToString());
            List<TimeData> dataList = new List<TimeData>();
            String debugStr;
            foreach(string line in lines)
            {
                List<string> lineData = line.Split(',').ToList();
                UnityEngine.Debug.Log("line = "+line);
                debugStr = "Date = "+lineData[0]+"--- "+"tested = "+lineData[3]+"--- "+"positives = "+lineData[4] +"--- " + "Deaths= "+ lineData[5];
                UnityEngine.Debug.Log(debugStr);
                TimeData timeData = new TimeData
                {
                    date = DateTime.Parse(lineData[0]),
                    tested = int.Parse(lineData[3]),
                    positives = int.Parse(lineData[4]),
                    deaths = int.Parse(lineData[5]),
                };
                dataList.Add(timeData);
                
            }

            return dataList;
        }
    }
}
