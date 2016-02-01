using Hackathon.Core;
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

namespace _13a_Hackathon1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonGetNutrition_Click(object sender, RoutedEventArgs e)
        {
            var hit = NutritionService.GetNutritionFor(textBoxEnterFoodItem.Text);

            textBlockBrandName.Text = hit.brand_name;
            textBlockCalories.Text = hit.nf_calories.ToString() + " Calories";
            textBlockItemName.Text = hit.item_name;
            textBlockFat.Text = hit.nf_total_fat.ToString() + " Total Fat";
        }
    }
}
