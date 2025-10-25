using UnityEngine;

public class InfoPanelController : MonoBehaviour
{
    [Header("Scheme Info")]
    public GameObject schemeInfoPanel;

    [Header("Crop Info")]
    public GameObject cropInfoPanel;

    [Header("Fertilizer Info")]
    public GameObject oFertilizerInfoPanel;
    public GameObject chFertilizerInfoPanel;

    [Header("Pesticide Info")]
    public GameObject oPesticidesInfoPanel;
    public GameObject chPesticidesInfoPanel;

    // Scheme Info
    public void OpenSchemeInfoPanel()
    {
        Debug.Log("Scheme Info Button Clicked");
        schemeInfoPanel.SetActive(true);
    }

    public void CloseSchemeInfoPanel()
    {
        schemeInfoPanel.SetActive(false);
    }

    // Crop Info
    public void OpenCropInfoPanel()
    {
        Debug.Log("Crop Info Button Clicked");
        cropInfoPanel.SetActive(true);
    }

    public void CloseCropInfoPanel()
    {
        cropInfoPanel.SetActive(false);
    }

    // Organic Fertilizer Info
    public void OpenOFertilizerInfoPanel()
    {
        Debug.Log("Organic Fertilizer Info Button Clicked");
        oFertilizerInfoPanel.SetActive(true);
    }

    public void CloseOFertilizerInfoPanel()
    {
        oFertilizerInfoPanel.SetActive(false);
    }

    // Chemical Fertilizer Info
    public void OpenChFertilizerInfoPanel()
    {
        Debug.Log("Chemical Fertilizer Info Button Clicked");
        chFertilizerInfoPanel.SetActive(true);
    }

    public void CloseChFertilizerInfoPanel()
    {
        chFertilizerInfoPanel.SetActive(false);
    }

    // Organic Pesticide Info
    public void OpenOPesticidesInfoPanel()
    {
        Debug.Log("Organic Pesticide Info Button Clicked");
        oPesticidesInfoPanel.SetActive(true);
    }

    public void CloseOPesticidesInfoPanel()
    {
        oPesticidesInfoPanel.SetActive(false);
    }

    // Chemical Pesticide Info
    public void OpenChPesticidesInfoPanel()
    {
        Debug.Log("Chemical Pesticide Info Button Clicked");
        chPesticidesInfoPanel.SetActive(true);
    }

    public void CloseChPesticidesInfoPanel()
    {
        chPesticidesInfoPanel.SetActive(false);
    }
}
