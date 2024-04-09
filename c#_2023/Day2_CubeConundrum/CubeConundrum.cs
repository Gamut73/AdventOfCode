using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class CubeConundrum
{

    private const string RED = "red";
    private const string GREEN = "green";
    private const string BLUE = "blue";


    public static void Main(string[] args)
    {
        int possibleGames = 0;
        int totalMinCubes = 0;

        int redCubes = 12;
        int greenCubes = 13;
        int blueCubes = 14;


        string[] lines = ReadInput("input.txt");

        foreach (string line in lines)
        {
            string game = line;

            int indexOfColon = game.IndexOf(":");
            int gameId = int.Parse(game.Substring("Game".Length + 1, indexOfColon - "Game".Length - 1));
            game = game.Substring(indexOfColon + 1);

            string[] sets = game.Split(";");
            bool isGamePossible = true;

            int minRedCubes = 0;
            int minGreenCubes = 0;
            int minBlueCubes = 0;


            foreach (string set in sets)
            {
                int redCubeCount = 0;
                int greenCubeCount = 0;
                int blueCubeCount = 0;

                string[] cubes = set.Split(",");

                foreach (string cube in cubes)
                {
                    string trimmedCube = cube.Trim();
                    string numOfCubesString = trimmedCube.Substring(0, trimmedCube.IndexOf(" "));
                    int numOfCubes = int.Parse(numOfCubesString);

                    if (isGamePossible) {
                        if (trimmedCube.Contains(RED))
                        {
                            redCubeCount += numOfCubes;
                            
                        }
                        else if (trimmedCube.Contains(GREEN))
                        {
                            greenCubeCount += numOfCubes;
                        }
                        else if (trimmedCube.Contains(BLUE))
                        {
                            blueCubeCount += numOfCubes;
                        }
                    }

                    if (trimmedCube.Contains(RED) && numOfCubes > minRedCubes)
                    {
                        minRedCubes = numOfCubes;
                    } else if (trimmedCube.Contains(GREEN) && numOfCubes > minGreenCubes)
                    {
                        minGreenCubes = numOfCubes;
                    } else if (trimmedCube.Contains(BLUE) && numOfCubes > minBlueCubes)
                    {
                        minBlueCubes = numOfCubes;
                    }


                    if (isGamePossible && (redCubeCount > redCubes || greenCubeCount > greenCubes || blueCubeCount > blueCubes))
                    {
                        isGamePossible = false;
                    }
                }
            }

            totalMinCubes += minBlueCubes * minGreenCubes * minRedCubes;

            if (isGamePossible)
            {
                possibleGames += gameId;
            }
        }
        Console.WriteLine($"Possible games: {possibleGames}, Total min cubes: {totalMinCubes}");
    }

    private static string[] ReadInput(string path)
    {
        try
        {
            return File.ReadAllLines(path);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}