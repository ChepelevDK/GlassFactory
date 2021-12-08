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
    /// Логика взаимодействия для TransportEx.xaml
    /// </summary>
    public partial class TransportEx : Window
    {
        public TransportEx()
        {
            InitializeComponent();
        }

        private bool IsAmountEqual(int cSum, int mSum)
        {
            return cSum == mSum;
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (c1Amount.Text != null && c2Amount.Text != null && c3Amount.Text != null && c4Amount.Text != null)
            {
                if (m1Amount.Text != null && m2Amount.Text != null && m3Amount.Text != null && m4Amount.Text != null && m5Amount.Text != null)
                {
                    int cSum = Convert.ToInt32(c1Amount.Text) + Convert.ToInt32(c2Amount.Text) + Convert.ToInt32(c3Amount.Text) + Convert.ToInt32(c4Amount.Text);
                    int mSum = Convert.ToInt32(m1Amount.Text) + Convert.ToInt32(m2Amount.Text) + Convert.ToInt32(m3Amount.Text) + Convert.ToInt32(m4Amount.Text) + Convert.ToInt32(m5Amount.Text);

                    cValue.Text = cSum.ToString();
                    mValue.Text = mSum.ToString();

                    if (IsAmountEqual(cSum, mSum))
                    {
                        int c1m1 = Convert.ToInt32(c1m1Value.Text);
                        int c1m2 = Convert.ToInt32(c1m2Value.Text);
                        int c1m3 = Convert.ToInt32(c1m3Value.Text);
                        int c1m4 = Convert.ToInt32(c1m4Value.Text);
                        int c1m5 = Convert.ToInt32(c1m5Value.Text);

                        int c2m1 = Convert.ToInt32(c2m1Value.Text);
                        int c2m2 = Convert.ToInt32(c2m2Value.Text);
                        int c2m3 = Convert.ToInt32(c2m3Value.Text);
                        int c2m4 = Convert.ToInt32(c2m4Value.Text);
                        int c2m5 = Convert.ToInt32(c2m5Value.Text);

                        int c3m1 = Convert.ToInt32(c3m1Value.Text);
                        int c3m2 = Convert.ToInt32(c3m2Value.Text);
                        int c3m3 = Convert.ToInt32(c3m3Value.Text);
                        int c3m4 = Convert.ToInt32(c3m4Value.Text);
                        int c3m5 = Convert.ToInt32(c3m5Value.Text);

                        int c4m1 = Convert.ToInt32(c4m1Value.Text);
                        int c4m2 = Convert.ToInt32(c4m2Value.Text);
                        int c4m3 = Convert.ToInt32(c4m3Value.Text);
                        int c4m4 = Convert.ToInt32(c4m4Value.Text);
                        int c4m5 = Convert.ToInt32(c4m5Value.Text);

                        int c1 = Convert.ToInt32(c1Amount.Text);
                        int c2 = Convert.ToInt32(c2Amount.Text);
                        int c3 = Convert.ToInt32(c3Amount.Text);
                        int c4 = Convert.ToInt32(c4Amount.Text);

                        int m1 = Convert.ToInt32(m1Amount.Text);
                        int m2 = Convert.ToInt32(m2Amount.Text);
                        int m3 = Convert.ToInt32(m3Amount.Text);
                        int m4 = Convert.ToInt32(m4Amount.Text);
                        int m5 = Convert.ToInt32(m5Amount.Text);

                        int[,] table = { { c1m1, c1m2, c1m3, c1m4, c1m5, c1},
                             { c2m1, c2m2, c2m3 , c2m4, c2m5, c2},
                             { c3m1, c3m2, c3m3, c3m4, c3m5, c3},
                             { c4m1, c4m2, c4m3, c4m4, c4m5, c4},
                             { m1, m2, m3, m4, m5, 0}};

                        int[,] outTable = new int[5, 6];
                        // Добавление в список и сортировка значений в порядке возрастания
                        var list = new List<int>();
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                list.Add(table[i, j]);
                            }
                        }
                        list.Sort();

                        // Заполнение запасов и потребностей в выходную таблицу
                        for (int i = 0; i < 4; i++)
                        {
                            outTable[i, 5] = table[i, 5];
                        }

                        for (int i = 0; i < 5; i++)
                        {
                            outTable[4, i] = table[4, i];
                        }

                        // Обработка элементов
                        for (int n = 0; n < list.Count; n++)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    // Проверка, если значение таблицы совпало со списком и выходная ячейка не больше или равно нуля
                                    if (table[i, j] == list[n])
                                    {
                                        if (outTable[i, 5] != 0 && outTable[4, j] != 0)
                                        {
                                            if (outTable[i, 5] - outTable[4, j] >= 0)
                                            {
                                                outTable[i, 5] = outTable[i, 5] - outTable[4, j];
                                                outTable[4, j] = 0;
                                                outTable[i, j] = table[4, j];
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        c1m1ValueOut.Text = outTable[0, 0].ToString();
                        c1m2ValueOut.Text = outTable[0, 1].ToString();
                        c1m3ValueOut.Text = outTable[0, 2].ToString();
                        c1m4ValueOut.Text = outTable[0, 3].ToString();
                        c1m5ValueOut.Text = outTable[0, 4].ToString();
                                 
                        c2m1ValueOut.Text = outTable[1, 0].ToString();
                        c2m2ValueOut.Text = outTable[1, 1].ToString();
                        c2m3ValueOut.Text = outTable[1, 2].ToString();
                        c2m4ValueOut.Text = outTable[1, 3].ToString();
                        c2m5ValueOut.Text = outTable[1, 4].ToString();
                                 
                        c3m1ValueOut.Text = outTable[2, 0].ToString();
                        c3m2ValueOut.Text = outTable[2, 1].ToString();
                        c3m3ValueOut.Text = outTable[2, 2].ToString();
                        c3m4ValueOut.Text = outTable[2, 3].ToString();
                        c3m5ValueOut.Text = outTable[2, 4].ToString();
                                
                        c4m1ValueOut.Text = outTable[3, 0].ToString();
                        c4m2ValueOut.Text = outTable[3, 1].ToString();
                        c4m3ValueOut.Text = outTable[3, 2].ToString();
                        c4m4ValueOut.Text = outTable[3, 3].ToString();
                        c4m5ValueOut.Text = outTable[3, 4].ToString();

                        int sum;
                        int toSpend = 0;

                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (outTable[i, j] != 0)
                                {
                                    sum = table[i, j] * outTable[i, j];
                                    toSpend += sum;
                                }
                            }
                        }

                        spentValue.Text = toSpend.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Расчёт невозможен! Сумма запасов и сумма потребности не равна!");
                    }
                }
            }
        }
    }
}
