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
    public GameObject uiProcedureStepWarningDescript;
    public GameObject uiProcedureStepDescript;
    private ProcedureObject procedureObject = null;
    private Text txt;
    private Image diagram;

    // Use this for initialization
    void Start () {

    }

    void OnHide(string input)
    {
        Debug.Log("Entered On Hide input = " + input);

        switch (input)
        {
            case ("Procedure"):
                Debug.Log("Entered Case Procedure");
                uiProcedure.SetActive(false);
                break;
            case ("Telemetry"):
                Debug.Log("Entered Case Telemetry");
                uiTelemetry.SetActive(false);
                break;
            case ("Animation"):
                Debug.Log("Entered Case Animation");
                uiAnimation.SetActive(false);
                break;
            case ("FixedDisplay"):
                Debug.Log("Entered Case FixedDisplay");
                uiFixedDisplay.SetActive(false);
                break;
            case ("Diagram"):
                Debug.Log("Entered Case Diagram");
                uiDiagram.SetActive(false);
                break;
            case ("HUD"):
                Debug.Log("Entered Case HUD");
                uiDiagram.SetActive(false);
                uiFixedDisplay.SetActive(false);
                uiAnimation.SetActive(false);
                uiTelemetry.SetActive(false);
                uiProcedure.SetActive(false);
                break;
            default:

                Debug.Log("On Hide Failed Input = " + input);
                break;
        }
    }

    void OnShow(string input)
    {
        Debug.Log("Entered On Hide input = " + input);

        switch (input)
        {
            case ("Procedure"):
                Debug.Log("Entered Case Procedure");
                uiProcedure.SetActive(true);
                break;
            case ("Telemetry"):
                Debug.Log("Entered Case Telemetry");
                uiTelemetry.SetActive(true);
                break;
            case ("Animation"):
                Debug.Log("Entered Case Animation");
                uiAnimation.SetActive(true);
                break;
            case ("FixedDisplay"):
                Debug.Log("Entered Case FixedDisplay");
                uiFixedDisplay.SetActive(true);
                break;
            case ("Diagram"):
                Debug.Log("Entered Case Diagram");
                uiDiagram.SetActive(true);
                break;
            case ("HUD"):
                Debug.Log("Entered Case HUD");
                uiDiagram.SetActive(true);
                uiFixedDisplay.SetActive(true);
                uiAnimation.SetActive(true);
                uiTelemetry.SetActive(true);
                uiProcedure.SetActive(true);
                break;
            default:

                Debug.Log("On Hide Failed Input = " + input);
                break;
        }
    }

    void OnStartProcedure(string input)
    {
        Debug.Log("Entered On Start Procedure");
        uiProcedure.SetActive(true);

        procedureObject = new ProcedureObject(input);
        txt = uiProcedrueTitle.GetComponent<Text>();
        txt.text = procedureObject.GetTitle();

        string[] temp;

        temp = procedureObject.OnNextStep();

        txt = uiProcedureStepWarningDescript.GetComponent<Text>();
        txt.text = temp[2];

        txt = uiProcedureStepDescript.GetComponent<Text>();
        txt.text = temp[0] + "\n\n" + temp[1];

        diagram = uiDiagram.GetComponent<Image>();
        diagram.sprite = (Sprite)Resources.Load<Sprite>("PC_Diagrams/" + temp[3]);
    }

    void OnNextStep()
    {
        if (procedureObject != null)
        {
            if (procedureObject.GetNumberSteps() > procedureObject.GetStepIndex() + 1)
            {
                string[] temp;

                temp = procedureObject.OnNextStep();

                txt = uiProcedureStepWarningDescript.GetComponent<Text>();
                txt.text = temp[2];

                txt = uiProcedureStepDescript.GetComponent<Text>();
                txt.text = temp[0] + "\n\n" + temp[1];

                diagram = uiDiagram.GetComponent<Image>();
                diagram.sprite = (Sprite)Resources.Load<Sprite>("PC_Diagrams/" + temp[3]);
            }
            if (procedureObject.GetNumberSteps() == procedureObject.GetStepIndex() + 1)
            {
                //Show alert task has been completed
                procedureObject = null;
            }
        }
    }

    void OnPreviousStep()
    {
        if (procedureObject != null)
        {
            if (procedureObject.GetStepIndex() != 0)
            {
                string[] temp;

                temp = procedureObject.OnPreviousStep();

                txt = uiProcedureStepWarningDescript.GetComponent<Text>();
                txt.text = temp[2];

                txt = uiProcedureStepDescript.GetComponent<Text>();
                txt.text = temp[0] + "\n\n" + temp[1];

                diagram = uiDiagram.GetComponent<Image>();
                diagram.sprite = (Sprite)Resources.Load<Sprite>("PC_Diagrams/" + temp[3]);
            }
            if (procedureObject.GetStepIndex() == 0)
            {
                //show alert?
            }
        }
    }

}
