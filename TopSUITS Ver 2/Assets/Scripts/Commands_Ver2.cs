using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Commands_Ver2 : MonoBehaviour
{

    public GameObject uiDiagram;
    public GameObject uiFixedDisplay;
    //public GameObject uiAnimation;
    public GameObject uiTelemetry;
    public GameObject uiProcedure;
    public GameObject uiProcedrueTitle;
    public GameObject uiProcedureStepWarningDescript;
    public GameObject uiProcedureStepDescript;
    public GameObject uiStep_1_Title;
    public GameObject uiStep_2_Title;
    public GameObject uiStep_3_Title;
    public GameObject uiStep_4_Title;
    public GameObject uiStep_5_Title;
    public GameObject uiStep_1_Box;
    public GameObject uiStep_2_Box;
    public GameObject uiStep_3_Box;
    public GameObject uiStep_4_Box;
    public GameObject uiStep_5_Box;
    public GameObject uiFixedTimer;
    public GameObject uiFixedWarning_Bar;
    public GameObject uiFixedWarning_Descript;
    public GameObject uiProcedureCanvas;
    public GameObject uiTelemetryCanvas;

    private ProcedureObject procedureObject = null;
    private Text txt;
    private Image diagram;
    private Vector3 telemetryPos;
    private Vector3 procedurePos;
    private Quaternion telemetryRotation;
    private Quaternion procedureRotation;

    // Use this for initialization
    void Start()
    {
        uiFixedWarning_Bar.SetActive(false);

        telemetryPos = uiTelemetryCanvas.transform.position;
        procedurePos = uiProcedureCanvas.transform.position;
        telemetryRotation = uiTelemetryCanvas.transform.rotation;
        procedureRotation = uiProcedureCanvas.transform.rotation;
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
                //uiAnimation.SetActive(false);
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
                //uiAnimation.SetActive(false);
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
                //uiAnimation.SetActive(true);
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
                // uiAnimation.SetActive(true);
                uiTelemetry.SetActive(true);
                uiProcedure.SetActive(true);
                break;
            default:

                Debug.Log("On Hide Failed Input = " + input);
                break;
        }
    }

    void OnViewObject(string input)
    {
        Debug.Log("Entered On View Object input = " + input);

        Vector3 playerPos = Camera.main.transform.position;
        Vector3 playerDirection = Camera.main.transform.forward;
        Quaternion playerRotation = Camera.main.transform.rotation;
        float spawnDistance = 1.5F;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        switch (input)
        {
            case ("Procedure"):
                procedurePos = uiProcedureCanvas.transform.position;
                procedureRotation = uiProcedureCanvas.transform.rotation;
                uiProcedureCanvas.transform.position = spawnPos;
                uiProcedureCanvas.transform.rotation = playerRotation;
                break;
            case ("Telemetry"):
                Debug.Log("Entered Case Telemetry");
                telemetryPos = uiTelemetryCanvas.transform.position;
                telemetryRotation = uiTelemetryCanvas.transform.rotation;
                uiTelemetryCanvas.transform.position = spawnPos;
                uiTelemetryCanvas.transform.rotation = playerRotation;
                break;
            case ("HUD"):
                Debug.Log("Entered Case HUD");
               
                break;
            default:

                Debug.Log("On Hide Failed Input = " + input);
                break;
        }

    }

    void OnDismissObject(string input)
    {
        Debug.Log("Entered On View Object input = " + input);

        Vector3 playerPos = Camera.main.transform.position;
        Vector3 playerDirection = Camera.main.transform.forward;
        Quaternion playerRotation = Camera.main.transform.rotation;
        float spawnDistance = 1.5F;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        switch (input)
        {
            case ("Procedure"):
                uiProcedureCanvas.transform.position = procedurePos;
                uiProcedureCanvas.transform.rotation = procedureRotation;
                break;
            case ("Telemetry"):
                Debug.Log("Entered Case Telemetry");
                uiTelemetryCanvas.transform.position = telemetryPos;
                uiTelemetryCanvas.transform.rotation = telemetryRotation;
                break;
            case ("HUD"):
                Debug.Log("Entered Case HUD");

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

        UpdateTaskList();

        string[] temp;

        temp = procedureObject.OnNextStep();

        txt = uiProcedureStepWarningDescript.GetComponent<Text>();
        txt.text = temp[2];

        txt = uiProcedureStepDescript.GetComponent<Text>();
        txt.text = temp[1];

        diagram = uiDiagram.GetComponent<Image>();
        diagram.sprite = (Sprite)Resources.Load<Sprite>("PC_Diagrams/" + temp[3]);

    }

    void OnNextStep()
    {
        Debug.Log("Entered On Next Step");
        if (procedureObject != null)
        {
            if (procedureObject.GetNumberSteps() > procedureObject.GetStepIndex())
            {
                Debug.Log("Step Index = " + procedureObject.GetStepIndex() + " Num of Steps = " + procedureObject.GetNumberSteps());

                UpdateTaskList();

                string[] temp;

                temp = procedureObject.OnNextStep();

                txt = uiProcedureStepWarningDescript.GetComponent<Text>();
                txt.text = temp[2];

                txt = uiProcedureStepDescript.GetComponent<Text>();
                txt.text = temp[1];

                diagram = uiDiagram.GetComponent<Image>();
                diagram.sprite = (Sprite)Resources.Load<Sprite>("PC_Diagrams/" + temp[3]);

            }
            else
            {
                //Show alert task has been completed
                procedureObject = null;
            }
        }
    }

    void OnPreviousStep()
    {
        Debug.Log("Entered On Previous Step");
        if (procedureObject != null)
        {
            if (procedureObject.GetStepIndex() != 0)
            {
               
                string[] temp;

                temp = procedureObject.OnPreviousStep();

                txt = uiProcedureStepWarningDescript.GetComponent<Text>();
                txt.text = temp[2];

                txt = uiProcedureStepDescript.GetComponent<Text>();
                txt.text = temp[1];

                diagram = uiDiagram.GetComponent<Image>();
                diagram.sprite = (Sprite)Resources.Load<Sprite>("PC_Diagrams/" + temp[3]);

                UpdateTaskList();
            }
            if (procedureObject.GetStepIndex() == 0)
            {
                //show alert?
            }
        }
    }

    private void DisplayTaskList(int temp_step)
    {
        string[] temp_step_title = new string[5];
        int temp_step_index = 0;

        for (int x = temp_step; x < 5 + temp_step; x++)
        {
            string[] temp = procedureObject.GetStep(x);
            temp_step_title[temp_step_index] = temp[0];
            temp_step_index++;
        }

        txt = uiStep_1_Title.GetComponent<Text>();
        txt.text = temp_step_title[0];
        txt = uiStep_2_Title.GetComponent<Text>();
        txt.text = temp_step_title[1];
        txt = uiStep_3_Title.GetComponent<Text>();
        txt.text = temp_step_title[2];
        txt = uiStep_4_Title.GetComponent<Text>();
        txt.text = temp_step_title[3];
        txt = uiStep_5_Title.GetComponent<Text>();
        txt.text = temp_step_title[4];
    }

    private void UpdateTaskList()
    {
        if(procedureObject.GetStepIndex() == 0)
        {
            txt = uiStep_1_Title.GetComponent<Text>();
            txt.color = Color.red;
            txt = uiStep_2_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_3_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_4_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_5_Title.GetComponent<Text>();
            txt.color = Color.black;

            diagram = uiStep_1_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");
            diagram = uiStep_2_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");
            diagram = uiStep_3_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");
            diagram = uiStep_4_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");
            diagram = uiStep_5_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");

            DisplayTaskList(0);
        }
        else if (procedureObject.GetStepIndex() == 1)
        {
            txt = uiStep_1_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_2_Title.GetComponent<Text>();
            txt.color = Color.red;
            txt = uiStep_3_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_4_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_5_Title.GetComponent<Text>();
            txt.color = Color.black;

            diagram = uiStep_1_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/checkedBox");
            diagram = uiStep_2_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");
            diagram = uiStep_3_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");
            diagram = uiStep_4_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");
            diagram = uiStep_5_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");

            DisplayTaskList(0);
        }
        else if (procedureObject.GetStepIndex() == 2)
        {
            txt = uiStep_1_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_2_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_3_Title.GetComponent<Text>();
            txt.color = Color.red;
            txt = uiStep_4_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_5_Title.GetComponent<Text>();
            txt.color = Color.black;

            diagram = uiStep_1_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/checkedBox");
            diagram = uiStep_2_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/checkedBox");
            diagram = uiStep_3_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");
            diagram = uiStep_4_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");
            diagram = uiStep_5_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");

            DisplayTaskList(0);
        }
        else if (procedureObject.GetStepIndex() == 3)
        {
            txt = uiStep_1_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_2_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_3_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_4_Title.GetComponent<Text>();
            txt.color = Color.red;
            txt = uiStep_5_Title.GetComponent<Text>();
            txt.color = Color.black;

            diagram = uiStep_1_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/checkedBox");
            diagram = uiStep_2_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/checkedBox");
            diagram = uiStep_3_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/checkedBox");
            diagram = uiStep_4_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");
            diagram = uiStep_5_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");

            DisplayTaskList(0);
        }
        else if(procedureObject.GetStepIndex() == procedureObject.GetNumberSteps() - 1)
        {
            txt = uiStep_1_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_2_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_3_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_4_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_5_Title.GetComponent<Text>();
            txt.color = Color.red;

            diagram = uiStep_1_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/checkedBox");
            diagram = uiStep_2_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/checkedBox");
            diagram = uiStep_3_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/checkedBox");
            diagram = uiStep_4_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/checkedBox");
            diagram = uiStep_5_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");

            DisplayTaskList(procedureObject.GetStepIndex()-4);
        }
        else
        {
            txt = uiStep_1_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_2_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_3_Title.GetComponent<Text>();
            txt.color = Color.black;
            txt = uiStep_4_Title.GetComponent<Text>();
            txt.color = Color.red;
            txt = uiStep_5_Title.GetComponent<Text>();
            txt.color = Color.black;

            diagram = uiStep_1_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/checkedBox");
            diagram = uiStep_2_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/checkedBox");
            diagram = uiStep_3_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/checkedBox");
            diagram = uiStep_4_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");
            diagram = uiStep_5_Box.GetComponent<Image>();
            diagram.sprite = (Sprite)Resources.Load<Sprite>("PNG/uncheckedBox");

            DisplayTaskList(procedureObject.GetStepIndex() - 3);
        }
    }

  
    
}
