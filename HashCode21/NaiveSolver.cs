using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode21
{
    // MODEL
    public class Street
    {
        public int B; // the intersection at the start
        public int E; // the intersection at the stop
        public string Name;
        public int L; // the time it takes a car to get from the beginning to the end of that street
    }

    public class CarPath
    {
        public int P; // the number of streets that the car wants to travel
        public List<string> Streets; // The car starts at the end of first street and follows the path until the end of the last street
    }

    public class IntersectionSchedule
    {
        public int i; // the ID of the intersection
        public int Ei; // the number of incoming streets (of the intersection i) covered by this schedule
        public List<GreenlightSchedule> greenLightSchedules;
    }

    public class GreenlightSchedule
    {
        public string StreetName; // the street name
        public int Duration; // for how long each street will have a green light
    }

    // SOLVER

    class NaiveSolver
    {
        public NaiveSolver(string inputFileName, string outputFileName, char delimiter)
        {
            // Model initializations

            int D; // the duration of the simulation, in seconds
            int I; // the number of intersections (with IDs from 0 to I -1)
            int S; // the number of streets
            int V; // the number of cars
            int F; // the bonus points for each car that reaches its destination before time D

            List<Street> streets = new List<Street>();
            List<CarPath> carPathes = new List<CarPath>();

            List<IntersectionSchedule> schedules = new List<IntersectionSchedule>();

            /**************************************************************************************
             *  Input loading
             **************************************************************************************/

            Console.WriteLine("Input loading... " + inputFileName);

            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
            string[] lines = File.ReadAllLines(inputFilePath);

            // Metadata parsing
            string[] line0 = lines[0].Split(delimiter);
            D = int.Parse(line0[0]);
            I = int.Parse(line0[1]);
            S = int.Parse(line0[2]);
            V = int.Parse(line0[3]);
            F = int.Parse(line0[4]);

            // Streets parsing
            for (int i = 1; i <= S; i++)
            {
                string[] lineStreet = lines[i].Split(delimiter);

                Street newStreet = new Street()
                {
                    B = int.Parse(lineStreet[0]),
                    E = int.Parse(lineStreet[1]),
                    Name = lineStreet[2],
                    L = int.Parse(lineStreet[3])
                };

                streets.Add(newStreet);
            }

            // Pathes parsing
            for (int i = S + 1; i <= S + V; i++)
            {
                string[] lineCarPath = lines[i].Split(delimiter);

                CarPath newCarPath = new CarPath()
                {
                    P = int.Parse(lineCarPath[0]),
                    Streets = new List<string>()
                };

                for (int j = 1; j <= newCarPath.P; j++)
                {
                    newCarPath.Streets.Add(lineCarPath[j]);
                }

                carPathes.Add(newCarPath);
            }

            /**************************************************************************************
             *  Solver
             **************************************************************************************/



            /**************************************************************************************
             *  Output
             **************************************************************************************/

            Console.WriteLine("Output to file...");

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), outputFileName)))
            {
                outputFile.WriteLine(schedules.Count);

                foreach (IntersectionSchedule schedule in schedules)
                {
                    outputFile.WriteLine(schedule.i);
                    outputFile.WriteLine(schedule.Ei);

                    foreach (GreenlightSchedule greenLightSchedule in schedule.greenLightSchedules)
                    {
                        outputFile.WriteLine(greenLightSchedule.StreetName + " " + greenLightSchedule.Duration);
                    }
                }
            }

            Console.WriteLine("Done...");
            Console.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), outputFileName));
        }
    }
}