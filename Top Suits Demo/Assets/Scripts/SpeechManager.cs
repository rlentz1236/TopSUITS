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
            this.BroadcastMessage("OnShowDiagram");
        });

        keywords.Add("Hide Diagram", () =>
        {
            Debug.Log("entered hide diagram keyword");
            this.BroadcastMessage("OnHideDiagram");
        });

        keywords.Add("Show Procedure", () =>
        {
            Debug.Log("entered show diagram keyword");
            this.BroadcastMessage("OnShowProcedure");
        });

        keywords.Add("Hide Procedure", () =>
        {
            Debug.Log("entered hide diagram keyword");
            this.BroadcastMessage("OnHideProcedure");
        });

        keywords.Add("Start Disable Alarm Procedure", () =>
        {
            Debug.Log("entered start disable alarm procedure keyword");
            this.BroadcastMessage("OnStartDisableAlarm");
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
