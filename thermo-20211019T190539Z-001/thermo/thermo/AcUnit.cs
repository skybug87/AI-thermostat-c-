using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temperature;

namespace HVAC
{
    class HVACUnit
    {
       public bool ACactive;
        public static HVACUnit HVACobj = new HVACUnit();
        public int NewTemp;
        public int TurnOn(int goalTemp, int currentTemp)
        {
            //Start AC timer
            //decrease temp until with 2 degrees
            HVACobj.ACactive = true;
           currentTemp = ThermoIO.Thermostatobj.currentTemp;

            bool ACtriggered=false;
            //grab current temp difference

            //check to see if temp needs to be adjusted

            ACtriggered = ThermoIO.Thermostatobj.CheckTemp(goalTemp,currentTemp);

            while (!ACtriggered)
            {

                //adjust temp
                currentTemp = ThermoIO.Thermostatobj.AdjustTemp(goalTemp,currentTemp);
                //check temp
                ACtriggered = ThermoIO.Thermostatobj.CheckTemp(goalTemp, currentTemp);

            }

            //stop HVAC timer
            NewTemp = currentTemp;
            

            //turn off
           
            return NewTemp;
        }

        public  void TurnOff()
        {
            //Stop AC timer
            HVACobj.ACactive = false;
            ThermoIO.Thermostatobj.istempselected = false;
            //set unit to off
        }

    }
}
