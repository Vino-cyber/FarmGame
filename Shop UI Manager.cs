using UnityEngine;

public class ShopUIManager : MonoBehaviour {
    public GameObject categoryPanel;
    public GameObject cropsPanel;
    public GameObject schemesPanel;
    public GameObject pesticidesPanel;
    public GameObject fertilizersPanel;

    public void OpenCategoryPanel() {
        categoryPanel.SetActive(true);
        CloseAllItemPanels();
    }

    public void OpenCropsPanel() {
        CloseAllItemPanels();
        cropsPanel.SetActive(true);
    }

    public void OpenSchemesPanel() {
        CloseAllItemPanels();
        schemesPanel.SetActive(true);
    }

    public void OpenPesticidesPanel() {
        CloseAllItemPanels();
        pesticidesPanel.SetActive(true);
    }

    public void OpenFertilizersPanel() {
        CloseAllItemPanels();
        fertilizersPanel.SetActive(true);
    }

    void CloseAllItemPanels() {
        cropsPanel.SetActive(false);
        schemesPanel.SetActive(false);
        pesticidesPanel.SetActive(false);
        fertilizersPanel.SetActive(false);
    }
    public void CloseCropsPanel(){
        cropsPanel.SetActive(false);
    }

    public void CloseFertilizersPanel(){
        fertilizersPanel.SetActive(false);
    }

    public void ClosePesticidesPanel(){
        pesticidesPanel.SetActive(false);
    }

    public void CloseSchemesPanel(){
        schemesPanel.SetActive(false);
    }

    public void CloseCategoryPanel(){
        categoryPanel.SetActive(false);
    }
}
