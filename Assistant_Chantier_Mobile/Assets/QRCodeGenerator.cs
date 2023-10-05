using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;
using TMPro;

public class QRCodeGenerator : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImageQRCode;
    [SerializeField]
    private Button _QRCodeGenerator;
    private Texture2D _storeEncodedTexture;
    // This variable is temporary and should be replaced by the function that takes the GPS coordinates instead  
    // Start is called before the first frame update
    void Start()
    {
        _storeEncodedTexture = new Texture2D(256, 256); 
    }
    private Color32[] Encode(string coordinateToEncode, int width, int height)
    {
        BarcodeWriter writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width,
            }
        };
        return writer.Write(coordinateToEncode);
    }
    public void OnClickEncode(string Coordinates)
    {
        EncodeCoordinateToQRCode(Coordinates);
    }

    private void EncodeCoordinateToQRCode(string Coordinates)
    {
        string coordinates = string.IsNullOrEmpty(Coordinates) ? "Empty  !" : Coordinates;

        Color32[] _convertPixelToTexture = Encode(Coordinates, _storeEncodedTexture.width, _storeEncodedTexture.height);
        _storeEncodedTexture.SetPixels32(_convertPixelToTexture);
        _storeEncodedTexture.Apply();
        _rawImageQRCode.texture = _storeEncodedTexture;
    }   
}
