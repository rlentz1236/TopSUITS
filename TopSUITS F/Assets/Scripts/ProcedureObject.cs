using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureObject {

    private string title;

    private string[,] steps;

    private int step_index;

    public ProcedureObject()
    {
        step_index = 0;
        steps = disableAlarmProcedure();
    }

    public string GetTitle()
    {
        return title;
    }

    public string[] OnNextStep()
    {
        
            string[] temp_step = new string[steps.GetLength(1)];

            for (int x = 0; x < steps.GetLength(1); x++)
            {
                temp_step[x] = steps[step_index, x];
            }

            step_index += 1;

            return temp_step;
       
    }

    public string[] OnPreviousStep()
    {
        if (step_index > 0)
        {
            string[] temp_step = new string[steps.GetLength(1)];

            step_index -= 1;

            for (int x = 0; x < steps.GetLength(1); x++)
            {
                temp_step[x] = steps[step_index, x];
            }

            return temp_step;
        }
        else
        {
            return null;
        }
    }

    public string[] GetCurrentStep()
    {
       
            string[] temp_step = new string[steps.GetLength(1)];

            for (int x = 0; x < steps.GetLength(1); x++)
            {
                temp_step[x] = steps[step_index, x];
            }

            return temp_step;
    }

    private string[,] disableAlarmProcedure()
    {
        string[,] temp = new string[,] { 
            {"Step 1:","On the RIGHT side of the EVA Kit, locate and use the PANEL ACCESS KEY to unlock the PANEL ACCESS DOOR LOCKS.","CAUTION: The keys are on a tension-spring cable.","disableAlarmDiagram1","disableAlarmAnimation1"}, 
            {"Step 2:","Carefully return keys to the side of the EVA kit.","","disableAlarmDiagram2","disableAlarmAnimation2"},
            {"Step 3:","Insert your fingers in the CENTER OPENING and secure the PANEL ACCESS DOOR in an OPEN position.","WARNING: Door can accidentally close.","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 4:","On your belt, use the BLUE CARABINEER to securely tether to the TETHER CABLE inside the STORAGE.","CAUTION: Notice the TETHER CABLE is adjustable","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 5:","Locate the E-STOP button and gently press down to temporarily disable the alarm.","","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 6:","Locate the FUSIBLE DISCONNECT box and tether the BLUE CARABINEER to the TETHER CABLE.","","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 7:","Remove the BLUE CARABINEER from the FUSIBLE DISCONNECT box and transfer it to STORAGE.","","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 8:","Open the FUSIBLE DISCONNECT box and secure the lid in the open position.","CAUTION: Pull the locking tab toward STORAGE with the index finger while lifting the cover with the thumb.","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 9:","Locate the BLACK DISCONNECT and tether it to the TETHER CABLE.","","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 10:","Remove the DISCONNECT and place it in STORAGE.","CAUTION: Pull up with the index and middle fingers while pushing down on the FUSE ACCESS PANEL with the thumb.","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 11:","Tether the FUSE ACCESS PANEL to the TETHER CABLE.","","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 12:","Remove the FUSE ACCESS PANEL by pulling straight up.","","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 13:","Place the FUSE ACCESS PANEL into STORAGE.","","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 14:","Tether the ALARM FUSE to the TETHER CABLE.","","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 15:","In Storage, locate the BLUE FUSE PULLER.","","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 16:","Use the BLUE FUSE PULLER to remove ONLY the ALARM FUSE.","CAUTION: Rock the ALARM FUSE with the FUSE PULLER when pulling up.","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 17:","Return the ALARM FUSE and the FUSE PULLER to STORAGE.","","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 18:","In STORAGE, locate the FUSE ACCESS PANEL and reinstall it into the FUSIBLE DISCONNECT box.","","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 19:","Remove the FUSE ACCESS PANEL tether from the TETHER CABLE and stow inside.","WARNING: All tethers are under spring tension and can retract quickly.","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 20:","In STORAGE, locate the DISCONNECT and reinstall it into the FUSIBLE DISCONNECT box.","CAUTION: The DISCONNECT must read ON in the upper right corner to restore conductivity.","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 21:","Remove the DISCONNECT tether from the TETHER CABLE.","WARNING: All tethers are under spring tension and can retract quickly.","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 22:","Close the FUSIBLE DISCONNECT box cover.","","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 23:","In STORAGE, use the BLUE CARABINEER to clip and lock the FUSIBLE DISCONNECT box cover.","","disableAlarmDiagram3","disableAlarmAnimation3"},
            {"Step 24:","Remove the BLUE CARABINEER’s tether from the TETHER CABLE.","WARNING: All tethers are under spring tension and can retract quickly.","disableAlarmDiagram3","disableAlarmAnimation3"},
        };
        title = "Disable Alarm";
   
        return temp;
    }
}
