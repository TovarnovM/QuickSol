using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinesCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initialDirs =
                {
                //@"C:\Users\User\Desktop\CAMERA 25 07"
                @"C:\Users\User\Source\Repos\Interpolator\InterpSolution\RobotSim",
                  @"C:\Users\User\Source\Repos\Interpolator\InterpSolution\RobotSimTests",
                  @"C:\Users\User\Source\Repos\Interpolator\InterpSolution\RobotIM",
                  @"C:\Users\User\Source\Repos\Interpolator\InterpSolution\RobotIMTests",
                  @"C:\Users\User\Source\Repos\Interpolator\InterpSolution\AeroApp",
            //@"C:\Users\User\Source\Repos\Interpolator\InterpSolution\DoubleEnumGenetic",
            //@"C:\Users\User\Source\Repos\Interpolator\InterpSolution\Experiment",
            //@"C:\Users\User\Source\Repos\Interpolator\InterpSolution\GeneticNik",
            //@"C:\Users\User\Source\Repos\Interpolator\InterpSolution\GraphsFromExcel",
            @"C:\Users\User\Source\Repos\Interpolator\InterpSolution\InterpApp",
            //@"C:\Users\User\Source\Repos\Interpolator\InterpSolution\MassDrummer",
            //@"C:\Users\User\Source\Repos\Interpolator\InterpSolution\MultiGenetic",
            //@"C:\Users\User\Source\Repos\Interpolator\InterpSolution\OneDemSPH",
            @"C:\Users\User\Source\Repos\Interpolator\InterpSolution\ReactiveODE",
            //@"C:\Users\User\Source\Repos\Interpolator\InterpSolution\RobotSim",
            @"C:\Users\User\Source\Repos\Interpolator\InterpSolution\SimpleIntegrator"
            };

            var t = (0,0);
            foreach (var dir in initialDirs)
            {
                var (l,c) = PrintInfo(dir);
                t.Item1 += l;
                t.Item2 += c;
            }

            Console.WriteLine($"{"SUMM ="}  {t.Item1,5} строк  {t.Item2,5} символвов");
            Console.ReadLine();

        }

        static (int,int) PrintInfo(string initialDir)
        {
            var allFiles = FileSearcher.Search(initialDir,".cs");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(initialDir);
            foreach (var fp in allFiles)
            {
                Console.WriteLine($"{Path.GetFileName(fp),-30}  { File.ReadAllLines(fp).Length,5} строк  {File.ReadAllText(fp).Length,5} символов");
            }

            var linesSum = allFiles
                .Select(fp => File.ReadAllLines(fp).Length)
                .Sum();
            var charSum = allFiles
                .Select(fp => File.ReadAllText(fp).Length)
                .Sum();
            Console.WriteLine($"{"SUMM =",30}  {linesSum,5} строк  {charSum,5} символвов");
            return (linesSum, charSum);
        }


    }
}
