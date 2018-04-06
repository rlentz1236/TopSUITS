using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
public struct Telemetry
{
    public string id;
    public string p_suit; //internal suit pressure
    public string t_batt; //time life battery
    public string t_o2; // time life oxygen
    public string t_h2o; // time life water
    public string p_sub; // external environment pressure
    public string t_sub; // external environment temperature
    public string v_fan; // speed of cooling fan
    public string t_eva; // eva time
    public string p_o2; // oxygen presure
    public string rate_o2; // oxygen rate
    public string cap_battery; // battery capacity
    public string p_h2o_g; // h2o gas pressure
    public string p_h2o_l; // h2o liquid pressure
    public string p_sop; // sop pressure
    public string rate_sop; // sop rate
}

public class TelemetryStream : MonoBehaviour
{
    public Telemetry currentTelemetry;

    public GameObject timeLifeOxygen;
    public GameObject timeLifeBattery;
    public GameObject timeLifeWater;
    public GameObject internalSuitPressure;
    public GameObject subPressure;
    public GameObject evaTime;
    public GameObject subTemp;
    public GameObject fanSpeed;
    public GameObject oxyPress;
    public GameObject oxyRate;
    public GameObject battCap;
    public GameObject h20GasPressure;
    public GameObject h20LiqPress;
    public GameObject sopPress;
    public GameObject sopRate;
    public GameObject fixedTime;
    private Text txt;
    private int run_num = 0;

    void Start()
    {
        StartCoroutine(GetText());
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        if (run_num == 0 || run_num > 60)
        {

            UnityWebRequest www = UnityWebRequest.Get("http://telemetry-sim-telemetry-sim.a3c1.starter-us-west-1.openshiftapps.com/api/telemetry/recent");
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {

                currentTelemetry = JsonUtility.FromJson<Telemetry>(www.downloadHandler.text);

                txt = timeLifeOxygen.GetComponent<Text>();
                txt.text = currentTelemetry.t_o2;

                txt = timeLifeBattery.GetComponent<Text>();
                txt.text = currentTelemetry.t_batt;

                txt = timeLifeWater.GetComponent<Text>();
                txt.text = currentTelemetry.t_h2o;

                txt = internalSuitPressure.GetComponent<Text>();
                txt.text = currentTelemetry.p_suit;

                txt = subPressure.GetComponent<Text>();
                txt.text = currentTelemetry.p_sub;

                txt = evaTime.GetComponent<Text>();
                txt.text = currentTelemetry.t_eva;

                txt = fixedTime.GetComponent<Text>();
                txt.text = currentTelemetry.t_eva;

                txt = subTemp.GetComponent<Text>();
                txt.text = currentTelemetry.t_sub;

                txt = fanSpeed.GetComponent<Text>();
                txt.text = currentTelemetry.v_fan;

                txt = oxyPress.GetComponent<Text>();
                txt.text = currentTelemetry.p_o2;

                txt = oxyRate.GetComponent<Text>();
                txt.text = currentTelemetry.rate_o2;

                txt = battCap.GetComponent<Text>();
                txt.text = currentTelemetry.cap_battery;

                txt = h20GasPressure.GetComponent<Text>();
                txt.text = currentTelemetry.p_h2o_g;

                txt = h20LiqPress.GetComponent<Text>();
                txt.text = currentTelemetry.p_h2o_l;

                txt = sopPress.GetComponent<Text>();
                txt.text = currentTelemetry.p_sop;

                txt = sopRate.GetComponent<Text>();
                txt.text = currentTelemetry.rate_sop;

            }
        }

        run_num++;
    }
}
