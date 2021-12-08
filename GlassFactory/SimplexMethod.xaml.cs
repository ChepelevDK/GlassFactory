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
using System.Windows.Shapes;

namespace GlassFactory
{
    /// <summary>
    /// Логика взаимодействия для SimplexMethod.xaml
    /// </summary>
    public partial class SimplexMethod : Window
    {
        public SimplexMethod()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        public void Calculate()
        {
            double[,] SimplexMat = new double[3, 3];
            double[,] tempSimplexMat = new double[3, 3];

            double x1SandAmount = Convert.ToDouble(x1SandValue.Text);
            double x2SandAmount = Convert.ToDouble(x2SandValue.Text);

            double x1MixAmount = Convert.ToDouble(x1MixValue.Text);
            double x2MixAmount = Convert.ToDouble(x2MixValue.Text);

            double sand = Convert.ToDouble(sandAmount.Text);
            double mix = Convert.ToDouble(mixAmount.Text);

            double costX1 = Convert.ToDouble(x1Cost.Text);
            double costX2 = Convert.ToDouble(x2Cost.Text);

            double[,] table = { {sand, x1SandAmount, x2SandAmount},
                                {mix, x1MixAmount, x2MixAmount},
                                {0, -costX1, -costX2} };
            double[] result = new double[2];
            double[,] table_result;
            Simplex s = new Simplex(table);
            table_result = s.Calculate(result);

            profitValue.Text = Convert.ToString(table_result[2, 0]);
            x1Value.Text = Convert.ToString(result[0]);
            x2Value.Text = Convert.ToString(result[1]);
        }
    }
}
