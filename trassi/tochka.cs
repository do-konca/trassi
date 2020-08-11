using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace trassi

{
    class tochka

    {
        public int Number { get; set; }

        public int Time  { get; set; }

        public double Amplitude  { get; set; }

        public int Number_Trace  { get; set; }

        public int Target  { get; set; }


        public tochka() { Number = 0; Time = 0; Amplitude = 0; Number_Trace = 0; Target = 0; }

        
        public static tochka[] Return_Trace(int number_points, double[] signal, double amplitude_shum, int first_introduction, int second_introduction,int third_introduction, int Trace_number, int amplitude,bool mute,bool strong_amplitude_noize)
        {
            tochka[] Trace = new tochka[number_points];
            for (int i = 0; i < number_points; i++) 
            {
                Trace[i] = new tochka();
            }

            Random rnd = new Random();

            double max = signal.Max();
            double min = signal.Min();
            if (max <= Math.Abs(min)) 
            {
                max = Math.Abs(min);
            }
            //задать всем точкам началальные значения
            for (int i = 0; i < number_points; i++) 
            {
                Trace[i].Number_Trace = Trace_number;
                Trace[i].Time = i+1;
            }
            if (mute)
            {
                Trace[first_introduction + rnd.Next(-1 * amplitude, amplitude)].Target = 1;
            }
            if (mute)
            {
                if (first_introduction >= second_introduction)
                {
                    Trace[second_introduction + rnd.Next(-1 * amplitude, amplitude)].Target = 1;
                }
            }
            if (mute)
            {
                Trace[third_introduction + rnd.Next(-1 * amplitude, amplitude)].Target = 3;
            }

            for (int i = first_introduction; i < first_introduction + signal.Length; i++) 
            {
                Trace[i].Amplitude += signal[i - first_introduction] / max ;
            }

            for (int i = second_introduction; i < second_introduction + signal.Length; i++)
            {
                if (first_introduction >= second_introduction)
                {
                    Trace[i].Amplitude += signal[i - second_introduction] / max;
                }
            }

            for (int i = third_introduction; i < third_introduction + signal.Length; i++)
            {
                Trace[i].Amplitude += signal[i - third_introduction] / max;
            }


            for (int i = 0; i < number_points; i++) 
            {
                if (rnd.Next(1, 4) == 1)
                {
                    Trace[i].Amplitude += (rnd.NextDouble() - 0.5) * amplitude_shum;
                }
                if (rnd.Next(1, 10) == 1 & strong_amplitude_noize) 
                {
                    Trace[i].Amplitude += (rnd.NextDouble() - 0.5) * 2;
                }
                if (Trace[i].Amplitude < -1 ) 
                {
                    Trace[i].Amplitude = -1;
                }
                if (Trace[i].Amplitude > 1) 
                {
                    Trace[i].Amplitude = 1;
                }
            }

            
            return Trace;
        }

    }
}
