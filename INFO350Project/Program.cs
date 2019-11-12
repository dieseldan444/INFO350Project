using System;
using static System.Console;

class new_car_depreciation_calculator
{
    static void Main()
    {
        double[] numeric = new double[4];
        double[] rate = { .2, .1, .3, .15, .4, .2, .5, .25 };
        int[] ij = { 1, 1 };
        string[] makeModel = new string[2];
        int[] miss = { 0, 0, 0 };
        double depreciation, value;
        string input;

        while (true)
        {
            WriteLine("----------New Car Depreciation Calculator----------");
            WriteLine("This calculator will only work with vehicles that are the model year of the current year.");

            Write("Please enter the current year (Example: 2019): ");
            input = ReadLine();
            numeric[0] = double.Parse(input);

            Write("Please enter the year of the car (Example: 2019): ");
            input = ReadLine();
            numeric[1] = double.Parse(input);

            while (numeric[1] != numeric[0])        //depreciation calculator is only valid for cars that are made in the current year (new cars)
            {
                WriteLine(" ");
                WriteLine("This calculator will only work with vehicles that are the model year of the current year.");
                miss[0]++;
                if (miss[0] > 2)        //miss variable if car year doesn't equal current year
                {
                    break;
                }
                Write("Please enter the year of the car (Example: 2019): ");
                input = ReadLine();
                numeric[1] = double.Parse(input);
                WriteLine(" ");
            }

            if (miss[0] > 2)
            {
                break;
            }

            Write("Please enter the make of the car (Example: Toyota): ");
            input = ReadLine();
            makeModel[0] = input;

            Write("Please enter the model of the car (Example: Corolla): ");
            input = ReadLine();
            makeModel[1] = input;

            Write("Please enter the purchase price (Example: 25000): ");
            input = ReadLine();
            numeric[2] = double.Parse(input);

            while (numeric[2] < 0)      //purchase price of car cannot be below 0
            {
                WriteLine(" ");
                WriteLine("The purchase price of the car must be 0 or greater.");
                miss[1]++;
                if (miss[1] > 2)        //miss variable if purchase price of car is less than 0
                {
                    break;
                }
                Write("Please enter the purchase price (Example: 25000): ");
                input = ReadLine();
                numeric[2] = double.Parse(input);
                WriteLine(" ");
            }

            if (miss[1] > 2)
            {
                break;
            }

            Write("Please enter the number of miles on the car (Example: 50000): ");
            input = ReadLine();
            numeric[3] = double.Parse(input);

            while (numeric[3] < 0)      //mileage of car cannot be below 0
            {
                WriteLine(" ");
                WriteLine("The mileage of the car must be 0 or greater.");
                miss[2]++;
                if (miss[2] > 2)        //miss variable if mileage of car is less than 0
                {
                    break;
                }
                Write("Please enter the number of miles on the car (Example: 50000): ");
                input = ReadLine();
                numeric[3] = double.Parse(input);
                WriteLine(" ");
            }

            if (miss[2] > 2)
            {
                break;
            }

            WriteLine(" ");

            WriteLine("The year-by-year depreciation and value of the " + numeric[1] + " " + makeModel[0] + " " + makeModel[1] + " with " + numeric[3] + " miles, purchased for ${0:F2} is as follows:", numeric[2]);

            if (numeric[3] < 100000)            //calculation for depreciation if the car has less than 100000 miles for year 1
            {
                depreciation = numeric[2] * rate[0];
                value = numeric[2] - depreciation;
                WriteLine("The depreciation for year " + ij[1] + " is ${0:F2} and the value is ${1:F2}.", depreciation, value);
            }

            else if (numeric[3] >= 100000 && numeric[3] < 200000)        //calculation for 100000-200000 miles year 1
            {
                depreciation = numeric[2] * rate[2];
                value = numeric[2] - depreciation;
                WriteLine("The depreciation for year " + ij[1] + " is ${0:F2} and the value is ${1:F2}.", depreciation, value);
            }

            else if (numeric[3] >= 200000 && numeric[3] < 300000)       //calculation for 200000-300000 miles year 1
            {
                depreciation = numeric[2] * rate[4];
                value = numeric[2] - depreciation;
                WriteLine("The depreciation for year " + ij[1] + " is ${0:F2} and the value is ${1:F2}.", depreciation, value);
            }

            else            //For anything above 300000 miles on the car in the first year
            {
                depreciation = numeric[2] * rate[6];
                value = numeric[2] - depreciation;
                WriteLine("The depreciation for year " + ij[1] + " is ${0:F2} and the value is ${1:F2}.", depreciation, value);
            }

            for (ij[0] = 1; ij[0] < 5; ij[0]++)            //Loop and if statements used to calculate the depreciation in subsequent years from the first, using different depreciation modifiers
            {
                ij[1] = ij[0] + 1;
                numeric[2] = value;

                if (numeric[3] < 100000)
                {
                    depreciation = numeric[2] * rate[1];
                    value = numeric[2] - depreciation;
                    WriteLine("The depreciation for year " + ij[1] + " is ${0:F2} and the value is ${1:F2}.", depreciation, value);
                }

                else if (numeric[3] >= 100000 && numeric[3] < 200000)
                {
                    depreciation = numeric[2] * rate[3];
                    value = numeric[2] - depreciation;
                    WriteLine("The depreciation for year " + ij[1] + " is ${0:F2} and the value is ${1:F2}.", depreciation, value);
                }
                else if (numeric[3] >= 200000 && numeric[3] < 300000)
                {
                    depreciation = numeric[2] * rate[5];
                    value = numeric[2] - depreciation;
                    WriteLine("The depreciation for year " + ij[1] + " is ${0:F2} and the value is ${1:F2}.", depreciation, value);
                }

                else
                {
                    depreciation = numeric[2] * rate[7];
                    value = numeric[2] - depreciation;
                    WriteLine("The depreciation for year " + ij[1] + " is ${0:F2} and the value is ${1:F2}.", depreciation, value);
                }
            }

            break;
        }
        ReadKey();
    }
}