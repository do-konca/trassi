using System;
using System.Collections.Generic;
using System.Text;

namespace trassi
{
    class methods_for_computing
    {
       
        public static string[] Get_Train_Seismorgrams(int number_of_trace, int number_of_seismograms, double[] signal, int Time,bool strong_amplitude_noize,double V_1,double V_2,double h)
        {
            tochka[] trace = new tochka[150];

            string[] for_file = new string[Time * number_of_trace * number_of_seismograms];
            for (int k = 0; k < number_of_seismograms; k++)
            {
                int[] first_arrival = new int[number_of_trace];
                int[] second_arrival = new int[number_of_trace];
                int[] third_arrival = new int[number_of_trace];
                //if (k == 0)
                //{
                //    for_file[k] = "Number Time Trace Amplitude Target_pryamaya Target_golovnaya Target_otrazhennaya";
                //}
                for (int i = 0; i < number_of_trace; i++)
                {
                    first_arrival[i] =2+Convert.ToInt32(Math.Round(Math.Abs(k-i)/V_1));
                }
                for (int i = 0; i < number_of_trace; i++)
                {
                    second_arrival[i] = 2+Convert.ToInt32(Math.Round(Math.Abs(k - i) / V_2+2*h/(V_1*Math.Sqrt(1-(V_1*V_1)/(V_2*V_2)))));
                }
                for (int i = 0; i < number_of_trace; i++)
                {
                    third_arrival[i] = 2+Convert.ToInt32(Math.Round(Math.Sqrt((k-i)*(k-i)+4*h*h) / V_1));
                }

                for (int i = 0; i < number_of_trace; i++)
                {

                    trace = tochka.Return_Trace(Time, signal, 0.3, first_arrival[i],second_arrival[i],third_arrival[i], i, 2,true, strong_amplitude_noize);

                    for (int j = 0; j < trace.Length; j++)
                    {
                        for_file[j + i * Time + k * number_of_trace * Time ] = (j + i * Time + Time * number_of_trace * k).ToString() + " " + trace[j].Time.ToString() + " " + trace[j].Number_Trace.ToString() + " " + trace[j].Amplitude.ToString().Replace(',', '.') + " " + trace[j].Target.ToString();
                        
                    }

                }
            }

            return for_file;
        }


        public static string[] Get_Test_Seismorgrams(int number_of_trace, int number_of_seismograms, double[] signal, int Time, bool strong_amplitude_noize, double V_1, double V_2, double h)
        {
            tochka[] trace = new tochka[150];

            string[] for_file = new string[ Time * number_of_trace * number_of_seismograms];
            for (int k = 0; k < number_of_seismograms; k++)
            {
                int[] first_arrival = new int[number_of_trace];
                int[] second_arrival = new int[number_of_trace];
                int[] third_arrival = new int[number_of_trace];
                
                for (int i = 0; i < number_of_trace; i++)
                {
                    first_arrival[i] = 2 + Convert.ToInt32(Math.Round(Math.Abs(k - i) / V_1));
                }
                for (int i = 0; i < number_of_trace; i++)
                {
                    second_arrival[i] = 2 + Convert.ToInt32(Math.Round(Math.Abs(k - i) / V_2 + 2 * h / (V_1 * Math.Sqrt(1 - (V_1 * V_1) / (V_2 * V_2)))));
                }
                for (int i = 0; i < number_of_trace; i++)
                {
                    third_arrival[i] = 2 + Convert.ToInt32(Math.Round(Math.Sqrt((k - i) * (k - i) + 4 * h * h) / V_1));
                }

                for (int i = 0; i < number_of_trace; i++)
                {

                    trace = tochka.Return_Trace(Time, signal, 0.3, first_arrival[i], second_arrival[i], third_arrival[i], i, 2, false, strong_amplitude_noize);

                    for (int j = 0; j < trace.Length; j++)
                    {
                        for_file[j + i * Time + k * number_of_trace * Time] = (j + i * Time + Time * number_of_trace * k).ToString() + " " + trace[j].Time.ToString() + " " + trace[j].Number_Trace.ToString() + " " + trace[j].Amplitude.ToString().Replace(',', '.') + " " + trace[j].Target.ToString();
                        
                    }

                }
            }

            return for_file;
        }


        public static string[] Get_Seismorgram_for_radex(int number_of_trace, int number_of_seismograms, double[] signal, int Time, bool strong_amplitude_noize, double V_1, double V_2, double h)
        {
            tochka[] trace = new tochka[150];

            string[] for_file = new string[ Time * number_of_trace * number_of_seismograms];
            for (int k = 0; k < number_of_seismograms; k++)
            {
                int[] first_arrival = new int[number_of_trace];
                int[] second_arrival = new int[number_of_trace];
                int[] third_arrival = new int[number_of_trace];
                
                for (int i = 0; i < number_of_trace; i++)
                {
                    first_arrival[i] = 2 + Convert.ToInt32(Math.Round(Math.Abs(k - i) / V_1));
                }
                for (int i = 0; i < number_of_trace; i++)
                {
                    second_arrival[i] = 2 + Convert.ToInt32(Math.Round(Math.Abs(k - i) / V_2 + 2 * h / (V_1 * Math.Sqrt(1 - (V_1 * V_1) / (V_2 * V_2)))));
                }
                for (int i = 0; i < number_of_trace; i++)
                {
                    third_arrival[i] = 2 + Convert.ToInt32(Math.Round(Math.Sqrt((k - i) * (k - i) + 4 * h * h) / V_1));
                }

                for (int i = 0; i < number_of_trace; i++)
                {

                    trace = tochka.Return_Trace(Time, signal, 0.3, first_arrival[i], second_arrival[i], third_arrival[i], i, 2, true, strong_amplitude_noize);

                    for (int j = 0; j < trace.Length; j++)
                    {
                        for_file[j + i * 150 ] =  trace[j].Amplitude.ToString().Replace(',','.');
                    }

                }
            }

            return for_file;
        }

        public static string[] make_five_signs(string[] for_file,int Time,int number_of_trace,int number_of_seismograms) 
        {
            for (int i = 0; i < for_file.Length; i++) 
            {
                //right
                if ((i % (number_of_trace * Time) / Time) != (number_of_trace - 1))
                {
                    string[] auxiliary_line = for_file[i + Time].Split(" ");
                    for_file[i] += " " + auxiliary_line[3] + " ";
                }
                else
                {
                    for_file[i] += " " + "0" + " ";
                }

                // right top point
                if ((i % (number_of_trace * Time) / Time) != (number_of_trace - 1) & (i % (number_of_trace * Time) % Time != 0))
                {
                    string[] auxiliary_line = for_file[i + Time - 1].Split(" ");
                    for_file[i] +=auxiliary_line[3] + " ";
                }
                else 
                {
                    for_file[i] += "0" + " ";
                }

                //top
                if ((i % (number_of_trace * Time) % Time != 0))
                {
                    string[] auxiliary_line = for_file[i-1].Split(" ");
                    for_file[i] +=auxiliary_line[3] + " ";
                }
                else
                {
                    for_file[i] +="0" + " ";
                }

                // left top point 
                if ((i % (number_of_trace * Time) / Time) != 0 & (i % (number_of_trace * Time) % Time != 0))
                {
                    string[] auxiliary_line = for_file[i - Time - 1].Split(" ");
                    for_file[i] += auxiliary_line[3] + " ";
                }
                else
                {
                    for_file[i] += "0" + " ";
                }

                //left
                if ((i % (number_of_trace * Time) / Time) != 0)
                {
                    string[] auxiliary_line = for_file[i - Time].Split(" ");
                    for_file[i] += auxiliary_line[3] + " ";
                }
                else
                {
                    for_file[i] += "0" + " ";
                }

                // left bottom point
                if ((i % (number_of_trace * Time) / Time) != 0 & (i % (number_of_trace * Time) % Time != (Time - 1)))
                {
                    string[] auxiliary_line = for_file[i - Time + 1].Split(" ");
                    for_file[i] += auxiliary_line[3] +  " ";
                }
                else
                {
                    for_file[i] += "0" + " ";
                }

                //bottom
                if ((i % (number_of_trace * Time) % Time != (Time - 1)))
                {
                    string[] auxiliary_line = for_file[i + 1].Split(" ");
                    for_file[i] += auxiliary_line[3] + " ";
                }
                else
                {
                    for_file[i] += "0" + " ";
                }

                // right bottom point
                if ((i % (number_of_trace*Time) / Time) != (number_of_trace - 1) & (i % (number_of_trace * Time) % Time != (Time-1)))
                {
                    string[] auxiliary_line = for_file[i + Time + 1].Split(" ");
                    for_file[i] += auxiliary_line[3];
                }
                else
                {
                    for_file[i] += "0";
                }
                
            }
            return for_file;
        }

    }
}
