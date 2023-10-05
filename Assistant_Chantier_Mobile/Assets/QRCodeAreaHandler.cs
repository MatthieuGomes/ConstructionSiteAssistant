using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QRCodeAreaHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject QRCodeArea;
    public GameObject QrCodeButton;
    public void PanelClicked()
    {
        QRCodeArea.SetActive(false);
        QrCodeButton.SetActive(true);
    }
    public void ButtonClicked()
    {
        QRCodeArea.SetActive(true);
        QrCodeButton.SetActive(false);
    }
        
}
