using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{

    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
        Debug.Log("speech manager on start entered");

        /*keywords.Add("", () =>
        {
            Debug.Log("");
            this.BroadcastMessage("");
        });*/

        keywords.Add("Show Diagram", () =>
        {
            Debug.Log("entered show diagram keyword");
            this.BroadcastMessage("OnShow", "Diagram");
        });

        keywords.Add("Hide Diagram", () =>
        {
            Debug.Log("entered hide diagram keyword");
            this.BroadcastMessage("OnHide", "Diagram");
        });

        keywords.Add("Show Procedure", () =>
        {
            Debug.Log("entered show Procedure keyword");
            this.BroadcastMessage("OnShow", "Procedure");
        });

        keywords.Add("Hide Procedure", () =>
        {
            Debug.Log("entered hide Procedure keyword");
            this.BroadcastMessage("OnHide", "Procedure");
        });

        keywords.Add("Show Telemetry", () =>
        {
            Debug.Log("entered show Telemetry keyword");
            this.BroadcastMessage("OnShow", "Telemetry");
        });

        keywords.Add("Hide Telemetry", () =>
        {
            Debug.Log("entered hide Telemetry keyword");
            this.BroadcastMessage("OnHide", "Telemetry");
        });

        keywords.Add("Show Animation", () =>
        {
            Debug.Log("entered show Animation keyword");
            this.BroadcastMessage("OnShow", "Animation");
        });

        keywords.Add("Hide Animation", () =>
        {
            Debug.Log("entered hide Animation keyword");
            this.BroadcastMessage("OnHide", "Animation");
        });

        keywords.Add("Show Fixed Display", () =>
        {
            Debug.Log("entered show Fixed Display keyword");
            this.BroadcastMessage("OnShow", "FixedDisplay");
        });

        keywords.Add("Hide Fixed Display", () =>
        {
            Debug.Log("entered hide Fixed Display keyword");
            this.BroadcastMessage("OnHide", "FixedDisplay");
        });

        keywords.Add("Kill HUD", () =>
        {
            Debug.Log("entered show kill hud keyword");
            this.BroadcastMessage("OnHide", "HUD");
        });

        keywords.Add("Restore HUD", () =>
        {
            Debug.Log("entered hide restore hud keyword");
            this.BroadcastMessage("OnShow", "HUD");
        });

        keywords.Add("Start Disable Alarm Procedure", () =>
        {
            Debug.Log("entered start disable alarm procedure keyword");
            this.BroadcastMessage("OnStartProcedure", "DisableAlarm");
        });

        keywords.Add("Start Build PC Procedure", () =>
        {
            Debug.Log("entered start build pc procedure keyword");
            this.BroadcastMessage("OnStartProcedure", "BuildPC");
        });

        keywords.Add("Next Step", () =>
        {
            Debug.Log("entered next step keyword");
            this.BroadcastMessage("OnNextStep");
        });

        keywords.Add("Previous Step", () =>
        {
            Debug.Log("entered previous step keyword");
            this.BroadcastMessage("OnPreviousStep");
        });

        keywords.Add("View Procedure", () =>
        {
            Debug.Log("");
            this.BroadcastMessage("OnViewObject","Procedure");
        });

        keywords.Add("View Telemetry", () =>
        {
            Debug.Log("");
            this.BroadcastMessage("OnViewObject","Telemetry");
        });

        keywords.Add("Dismiss Procedure", () =>
        {
            Debug.Log("");
            this.BroadcastMessage("OnDismissObject", "Procedure");
        });

        keywords.Add("Dismiss Telemetry", () =>
        {
            Debug.Log("");
            this.BroadcastMessage("OnDismissObject", "Telemetry");
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {

        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}
