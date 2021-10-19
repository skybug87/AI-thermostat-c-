using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Temperature;
using System.Threading;
using HVAC;
namespace thermo
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();

            //intialize the timer to run GenerateTemperatureIO every 5 second to check the temp
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();

            //initialize temp selection drop down
            comboBox1.BeginUpdate();
            for (int i = 30; i < 100; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
            comboBox1.EndUpdate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;
            Object selectedItem = comboBox1.SelectedItem;
            string selectedItemstring;
            selectedItemstring=selectedItem.ToString();
           
            
            try
            {
                ThermoIO.Thermostatobj.goalTemp = Int32.Parse(selectedItemstring);
                
                
                ThermoIO.Thermostatobj.istempselected = true;

                //if temp selected is has 1 degree differnce run AC
                //pass goalTemp so it can be compared to current temp

                if (!ThermoIO.Thermostatobj.CheckTemp(ThermoIO.Thermostatobj.goalTemp, ThermoIO.Thermostatobj.currentTemp))
                {
                    //run AC until temp is within 1 degrees
                    ThermoIO.Thermostatobj.currentTemp=HVACUnit.HVACobj.TurnOn(ThermoIO.Thermostatobj.goalTemp, ThermoIO.Thermostatobj.currentTemp);
                }

                //if temp is no good pause timer start HAVC

            }
            catch (FormatException)
            {
                Console.WriteLine("wrong input type");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {



        }
        

        private void displayTemp_TextChanged(object sender, EventArgs e)
        {

          
        }

        private void OnorOff_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            bool selected = true;

            //while Off selected disable AC. 
            if (OnorOff.GetSelected(1) == selected)
            {
                HVACUnit.HVACobj.TurnOff();

            }
            //while On selected enable AC... 
            if (OnorOff.GetSelected(0) == selected)
            {
                int selectedIndex = comboBox1.SelectedIndex;
                Object selectedItem = comboBox1.SelectedItem;
                string selectedItemstring;
                
                //if a desired temperature was previously selected then revert back to that temp
                if (selectedItem != null)
                {
                    ThermoIO.Thermostatobj.istempselected = true;
                    selectedItemstring = selectedItem.ToString();
                    ThermoIO.Thermostatobj.goalTemp = Int32.Parse(selectedItemstring);
                    HVACUnit.HVACobj.TurnOn(ThermoIO.Thermostatobj.goalTemp, ThermoIO.Thermostatobj.currentTemp);
                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {

            //if user selected a temp, continuusly adjust to that temp
            //run AC until temp is within 1 degrees and temp is outside of 1 degree window
            if (ThermoIO.Thermostatobj.istempselected) 
            {
                //variable to evaluate if temp is good
                bool goalTemptimer = false;

                //generate updated temp and check it for 1 degree margin
                ThermoIO.Thermostatobj.currentTemp = ThermoIO.Thermostatobj.GenerateTemperatureIO();
                //check the temp
                goalTemptimer=ThermoIO.Thermostatobj.CheckTemp(ThermoIO.Thermostatobj.goalTemp, ThermoIO.Thermostatobj.currentTemp);

                //update current temp 
                if(goalTemptimer == false)
                ThermoIO.Thermostatobj.currentTemp = HVACUnit.HVACobj.TurnOn(ThermoIO.Thermostatobj.goalTemp, ThermoIO.Thermostatobj.currentTemp);
                ThermoIO.Thermostatobj.TempString = ThermoIO.Thermostatobj.currentTemp.ToString();
            }

            //if HVAC unit is  not running grab new temp and run idle
            if (!HVACUnit.HVACobj.ACactive || !ThermoIO.Thermostatobj.istempselected)
            {
                ThermoIO.Thermostatobj.currentTemp = ThermoIO.Thermostatobj.GenerateTemperatureIO();
                ThermoIO.Thermostatobj.TempString = ThermoIO.Thermostatobj.currentTemp.ToString();
            }

            //if HVAC is running use that temp
            //if User has selected a temp
           /* if (HVACUnit.HVACobj.ACactive)
            {
                
                ThermoIO.Thermostatobj.TempString = ThermoIO.Thermostatobj.currentTemp.ToString();
                HVACUnit.HVACobj.ACactive = false;
            }

    */
            this.displayTemp.Text = ThermoIO.Thermostatobj.TempString;

            //check if temp is within 2 degrees
            //if not pause timer and run AC



        }
    }
}
