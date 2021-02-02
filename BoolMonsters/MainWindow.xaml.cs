
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoolMonsters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            int[] pascalRowDecimal = PascalTriangleRow(5);
            int bitSpaceMax = BitSpaceCalculator(pascalRowDecimal);

            int[,] binaryArray = new int[pascalRowDecimal.Length, bitSpaceMax];

            for (int i = 0; i < pascalRowDecimal.Length; i++)
            {
                var c = DecimalToBinary(pascalRowDecimal[i], bitSpaceMax);
                for (int j = 0; j < c.Length; j++)
                {
                    binaryArray[i, j] = c[j];
                }
            }

            bool[,] boolMonster = Boolify(binaryArray);
        }

        public int[] PascalTriangleRow(int monsteLevel) /// Should output an array containing values of pascals triangle at row monsterLevel
        {
            int[] pascalArray = new int[monsteLevel];
            int trianglePointValue = 1;

            for (int i = 1; i < monsteLevel - 1; i++)
            {
                trianglePointValue = (trianglePointValue * (monsteLevel - i)) / i;
                pascalArray[i] = trianglePointValue;
            }

            pascalArray[0] = 1;
            pascalArray[monsteLevel - 1] = 1;

            return pascalArray;
        }

        public int BitSpaceCalculator(int[] pascalArray) /// Calculates the total number of bits to store the largest value in the pascal row
        {
            int n, i;
            n = pascalArray.Max();
            for (i = 0; n > 0; i++)
            {
                n = n / 2;
            }

            return i;
        }

        public int[] DecimalToBinary(int decimalInput, int bitSpaceRequired) /// Should convert from decimal to binary for any given decimal and bit space
        {
            int n, i;
            n = decimalInput;
            int[] intArray = new int[bitSpaceRequired];
            for (i = 0; n > 0; i++)
            {
                intArray[i] = n % 2;
                n = n / 2;
            }

            return intArray;
        }

        public int[,] ArrayMerge(List<int[]> arrays) /// Puts any given arrays next to eachother in one array
        {
            if (arrays.Count == 0)
                return new int[,] { };

            int[,] newArray = new int[arrays[0].Length, arrays.Count];

            for (int x = 0; x < arrays[0].Length; x++)
            {
                for (int y = 0; y < arrays.Count; y++)
                {
                    newArray[x, y] = arrays[x][y];
                }
            }
            return newArray;
        }

        public bool[,] Boolify(int[,] binary) /// Converts a binary matrix into a bool matrix
        {
            int xMax = binary.GetLength(0);
            int yMax = binary.GetLength(1);
            bool[,] boolArray = new bool[xMax, yMax];

            for (int x = 0; x < xMax; x++)
                for (int y = 0; y < yMax; y++)

                    if (binary[x, y] == 1)
                    {
                        boolArray[x, y] = true;
                    }
                    else
                    {
                        boolArray[x, y] = false;
                    }

            return boolArray;
        }
    }
}
