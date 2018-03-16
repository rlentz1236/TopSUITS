using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Commands : MonoBehaviour {

    public GameObject uiDiagram;
    public GameObject uiFixedDisplay;
    public GameObject uiAnimation;
    public GameObject uiTelemetry;
    public GameObject uiProcedure;
    public GameObject uiProcedrueTitle;
    public GameObject uiProcedureStepTitle;
    public GameObject uiProcedureStepDescript;
    private ProcedureObject procedureObject;
    private Text txt;

    // Use this for initialization
    void Start () {

        uiDiagram.SetActive(true);
        uiProcedure.SetActive(true);
    }

    void OnHideProcedure()
    {
        Debug.Log("Entered On Hide Procedure");
        uiProcedure.SetActive(false);
    }

    void OnShowProcedure()
    {
        Debug.Log("Entered On Show Procedure");
        uiProcedure.SetActive(true);
    }

    void OnShowDiagram()
    {
        Debug.Log("Entered On Show Diagram");
        uiDiagram.SetActive(true);
    }

    void OnHideDiagram()
    {
        Debug.Log("Entered On Hide Diagram");
        uiDiagram.SetActive(false);
    }
    void OnShowTelemetry()
    {
        Debug.Log("Entered On Show Telemetry");
        uiTelemetry.SetActive(true);
    }

    void OnHideTelemetry()
    {
        Debug.Log("Entered On Hide Telemetry");
        uiTelemetry.SetActive(false);
    }

    void OnShowAnimation()
    {
        Debug.Log("Entered On Show animation");
        uiAnimation.SetActive(true);
    }

    void OnHideAnimation()
    {
        Debug.Log("Entered On Hide animation");
        uiAnimation.SetActive(false);
    }

    void OnShowFixedDisplay()
    {
        Debug.Log("Entered On Show fixed display");
        uiFixedDisplay.SetActive(true);
    }

    void OnHideFixedDisplay()
    {
        Debug.Log("Entered On Hide fixed display");
        uiFixedDisplay.SetActive(false);
    }

    void OnRestoreHUD()
    {
        Debug.Log("Entered restore hud");
        uiDiagram.SetActive(true);
        uiFixedDisplay.SetActive(true);
        uiAnimation.SetActive(true);
        uiTelemetry.SetActive(true);
        uiProcedure.SetActive(true);
    }

    void OnKillHUD()
    {
        Debug.Log("Entered kill hud");
        uiDiagram.SetActive(false);
        uiFixedDisplay.SetActive(false);
        uiAnimation.SetActive(false);
        uiTelemetry.SetActive(false);
        uiProcedure.SetActive(false);
}

    void OnStartDisableAlarm()
    {
        Debug.Log("Entered On Start Disbale Alarm");
        uiProcedure.SetActive(true);

        procedureObject = new ProcedureObject();
        txt = uiProcedrueTitle.GetComponent<Text>();
        txt.text = procedureObject.GetTitle();

        string[] temp;

        temp = procedureObject.OnNextStep();

        txt = uiProcedureStepTitle.GetComponent<Text>();
        txt.text = temp[0];

        txt = uiProcedureStepDescript.GetComponent<Text>();
        txt.text = temp[1] + "\n" + temp[2];
    }

    void OnNextStep()
    {
        string[] temp;

        temp = procedureObject.OnNextStep();

        txt = uiProcedureStepTitle.GetComponent<Text>();
        txt.text = temp[0];

        txt = uiProcedureStepDescript.GetComponent<Text>();
        txt.text = temp[1] + "\n" + temp[2];
    }

    void OnPreviousStep()
    {
        string[] temp;

        temp = procedureObject.OnPreviousStep();

        txt = uiProcedureStepTitle.GetComponent<Text>();
        txt.text = temp[0];

        txt = uiProcedureStepDescript.GetComponent<Text>();
        txt.text = temp[1] + "\n" + temp[2];
    }

}
