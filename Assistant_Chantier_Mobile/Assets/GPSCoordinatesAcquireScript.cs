using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Android;
using Unity.VisualScripting;

public class GPSCoordinatesAcquireScript : MonoBehaviour
{
    // Start is called before the first frame update

    public string CurrentStatus; 
    public TMP_Text CurrentX;
    public float CurrentXvalue;
    public TMP_Text CurrentY;
    public float CurrentYvalue;
    public TMP_Text CurrentZ;
    public float CurrentZvalue;
    public string OnClickStatus;
    public TMP_Text OnClickX;
    public float OnClickXvalue;
    public TMP_Text OnClickY;
    public float OnClickYvalue;
    public TMP_Text OnClickZ;
    public float OnClickZvalue;
    void Start()
    {
        StartCoroutine(GPSLoc());
    }

    // Update is called once per frame
    IEnumerator GPSLoc()
    {
        if (!Input.location.isEnabledByUser) {
            CurrentX.text = "Activate location";
            CurrentY.text = "Activate location";
            CurrentZ.text = "Activate location";
            yield break; 
        }
        else
        {
            if(Permission.HasUserAuthorizedPermission(Permission.FineLocation)){
                Permission.RequestUserPermission(Permission.FineLocation);
                Permission.RequestUserPermission(Permission.CoarseLocation);
            }
        }
            

        Input.location.Start();

        float maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(0.5f);
            maxWait=maxWait-0.5f;
        }
        if (maxWait < 1)
        {
            CurrentStatus = "Time Out";
            CurrentX.text = CurrentStatus;
            CurrentY.text = CurrentStatus;
            CurrentZ.text = CurrentStatus;
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Failed) {
            CurrentStatus = "Location Not Found";
            CurrentX.text = CurrentStatus;
            CurrentY.text = CurrentStatus;
            CurrentZ.text = CurrentStatus;
            yield break;
        }
        else
        {
            CurrentStatus = "Running";
            InvokeRepeating("UpdateGPSData", 0.5f, 0.5f);
        }
    }

    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            CurrentStatus = "Running";
            CurrentXvalue = float.Parse(Input.location.lastData.latitude.ToString());
            CurrentYvalue = float.Parse(Input.location.lastData.longitude.ToString());
            CurrentZvalue = float.Parse(Input.location.lastData.altitude.ToString());
            CurrentX.text = CurrentXvalue.ToString();
            CurrentY.text = CurrentYvalue.ToString();
            CurrentZ.text = CurrentZvalue.ToString();
        }
        else
        {
            CurrentStatus = "Wait...";
            CurrentX.text = CurrentStatus;
            CurrentY.text = CurrentStatus;
            CurrentZ.text = CurrentStatus;
        }
    }
    public void GenerateQRCode(QRCodeGenerator QRCodeGeneratorScript)
    {
        OnClickXvalue = float.Parse(Input.location.lastData.latitude.ToString());
        OnClickYvalue = float.Parse(Input.location.lastData.longitude.ToString());
        OnClickZvalue = float.Parse(Input.location.lastData.altitude.ToString());
        OnClickX.text = OnClickXvalue.ToString();
        OnClickY.text = OnClickYvalue.ToString();
        OnClickZ.text = OnClickZvalue.ToString();
        string Coordinates = OnClickXvalue.ToString()+";"+ OnClickYvalue + ";"+ OnClickZvalue;
        QRCodeGeneratorScript.OnClickEncode(Coordinates);
    }

}
