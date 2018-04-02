using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureObject {

    private string title;

    private string[,] steps;

    private int step_index;

    private int num_steps;

    public ProcedureObject(string input)
    {
        step_index = 0;

        switch (input)
        {
            case ("DisableAlarm"):
                Debug.Log("Entered DisableAlarm Procedure Switch");
                steps = disableAlarmProcedure();
                break;
            case ("BuildPC"):
                Debug.Log("Entered Build PC Procedure Switch");
                steps = buildPcProcedure();
                break;
            default:
                Debug.Log("Procedure Object switch failed input = " + input);
                break;
        }
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

    public string[] GetStep(int desired_step)
    {

        string[] temp_step = new string[steps.GetLength(1)];

        for (int x = 0; x < steps.GetLength(1); x++)
        {
            temp_step[x] = steps[desired_step, x];
        }

        return temp_step;
    }

    public int GetNumberSteps()
    {
        return steps.GetLength(0);
    }

    public int GetStepIndex()
    {
        return step_index;
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

    private string[,] buildPcProcedure()
    {
        string[,] temp = new string[,] {
            {"Step 1: Release CPU Latch","Push down and to the right on the CPU Latch. Once the Latch has been released pull the cover back to reveal the CPU Socket","CAUTION: Do not bend the pins located in the CPU Socket.","motherboardDiagramLabeledCPULatchStep","animation1"},
            {"Step 2: Locate CPU Chip","Locate the CPU chip and make note of the notches on the sides.","","motherboardCPU","animation1"},
            {"Step 3: Insert CPU Chip","Line the CPU chip notches up with the notches in the Socket. Then Gently Lay the CPU chip into the Socket.","Note: The golden arrow on the CPU chip should be at the bottom left corner.","motherboardInstallCPU","animation1"},
            {"Step 4: Secure CPU Latch","Lay the latches cover over the CPU chip. Then push the latch down and hook it on the cover.","Caution: Make sure the latch is securely hooked before releasing.","motherboardLatchCPU","animation1"},
            {"Step 5: Locate RAM Stick","Locate the RAM Stick and make note of the single notch on the bottom side.","","motherboardRAM","animation1"},
            {"Step 6: Locate RAM Slot","Locate the Right Most RAM slot on the Motherboard. Make note of the notch in the slot.","","motherboardDiagramLabeledInsertRamStep","animation1"},
            {"Step 7: Release RAM Slot Tabs","Push the White Tabs back away from the RAM slot.","","motherboardRamSlotTabs","animation1"},
            {"Step 8: Insert RAM Stick","Slide the RAM Stick into the RAM slot. Then firmly push down on each end of the RAM Stick until you hear a click.","CAUTION: The RAM Stick should not provide any resistance. If it does, check to make sure the notches line up.","motherboardRamNotSnapped","animation1"},
            {"Step 9: Double Check RAM","Look at each white Tab and make sure it has securely locked the RAM into place.","","motherboardRamInserted","animation1"},
            {"Step 10: Locate CPU Fan","Locate the CPU Fan and make note of the white plastic tabs at the bottom of the Fan.","","motherboardCPUFan","animation1"},
            {"Step 11: Install CPU Fan Part 1","Line up the 4 plastic tabs on the CPU Fan with the holes next to the CPU Socket.","","motherboardInstallCPUFan","animation1"},
            {"Step 12: Install CPU Fan Part 2","Press down on each black tab till it snaps into place. As shown in the diagram.","","motherboardInstallCPUFan2","animation1"},
            {"Step 13: Connect Fan Power","Locate the cable coming off of the CPU fan. Then plug the cable into the power port above the CPU Socket.","Note: Make sure to line up the slots on the connector and port.","motherboardDiagramLabeledCPUFanPowerStep","animation1"},
            {"Step 14: Locate Motherboard Power Connector","Locate the Motherboards Main Power Connector that is attached to the power supply.","","motherboardMainPowerConnector","animation1"},
            {"Step 15: Install Motherboard Power Connector","Plug Motherboard power connector into the Main Power Port.","","motherboardDiagramLabeledMotherboardPowerStep","animation1"},
            {"Step 16: Locate CPU Power Connector","Locate the CPU Power Connector that is attached to the power supply.","","motherboardCPUPowerConnector","animation1"},
            {"Step 17: Install CPU Power Connector","Plug CPU power connector into the CPU Power Port.","","motherboardDiagramLabeledCPUPowerStep","animation1"},
            {"Step 18: Final Step","Locate and press the Power button on the Motherboards right side","","motherboardDiagramLabeledPowerButtonStep","animation1"}
        };
        title = "Build a PC";

        return temp;
    }
}
