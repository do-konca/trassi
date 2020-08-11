using System;
using System.IO;
using System.Text.Json;

namespace trassi
{
    class Program
    {
        static void Main(string[] args)
        {
            
            tochka[] trace = new tochka[150];

            double[] signal = { 1.0, 2.0, 3.0, 2.0, 1.0,-1.0, -2.0, -3.0, -2.0, -1.0 };

            int number_of_trace = 100;

            int number_of_seismograms = 100;
            Random rnd = new Random();
            int Time = 150;
            //for (double i = 0.0; i < 5.0; i++)
            //{
            //    string[] for_file = new string[1 + Time * number_of_trace * number_of_seismograms];

            //    for_file = methods_for_computing.Get_Train_Seismorgrams(number_of_trace, number_of_seismograms, signal, Time, true, 1.0 + rnd.NextDouble()-0.3, 3.0 + rnd.NextDouble() - 0.5, 10.0);
            //    //for_file = methods_for_computing.make_five_signs(for_file, Time, number_of_trace, number_of_seismograms);
            //    string file_name = "for_test_real_";
            //    string[] zagolovok = { "Number Time Trace Amplitude_0 Target_0" };
            //    File.WriteAllLines(@"C:\Users\Тимофей\Desktop\" + file_name + i.ToString() + ".txt", zagolovok);
            //    File.AppendAllLines(@"C:\Users\Тимофей\Desktop\" + file_name + i.ToString() + ".txt", for_file);
            //}

            string[] for_file = new string[1 + Time * number_of_trace * number_of_seismograms];

            for_file = methods_for_computing.Get_Seismorgram_for_radex(number_of_trace, number_of_seismograms, signal, Time, true, 1.0 + rnd.NextDouble() - 0.3, 3.0 + rnd.NextDouble() - 0.5, 10.0);
            //for_file = methods_for_computing.make_five_signs(for_file, Time, number_of_trace, number_of_seismograms);
            string file_name = "for_test_real_---";
            //string[] zagolovok = { "Number Time Trace Amplitude_0 Target_0" };
            //File.WriteAllLines(@"C:\Users\Тимофей\Desktop\" + file_name  + ".txt", zagolovok);
            File.AppendAllLines(@"C:\Users\Тимофей\Desktop\" + file_name  + ".txt", for_file);
        }
    }
}
