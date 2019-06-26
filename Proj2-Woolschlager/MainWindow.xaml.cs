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

namespace Proj2_Woolschlager
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

        private void BtnPress_Click(object sender, RoutedEventArgs e)
        {
            //set varibles 
            double feet = 0;
            double inches = 0;
            double weight = 0;
            //set the boxes to white and clear 
            feetBox.Background = Brushes.White;
            inchesBox.Background = Brushes.White;

            //check the feet value 
            if (!double.TryParse(feetBox.Text, out feet))
            {
                feetBox.Background = Brushes.Red;
                return;
            }


            //check for and inches 
            if (!double.TryParse(inchesBox.Text, out inches))
            {
                inchesBox.Background = Brushes.Red;
                return;
            }
            //get weight value
            weight = weightSlider.Value;
            //BMI fomula  
   
            double feetInch = (feet * 12) + inches;
            //display the lable under botton
            
            //check the weigth
            if (feetInch >= 1)
            {

                double BMI = Math.Round (weight / (feetInch * feetInch) * 703);
                


                if (BMI < 18.5)
                {
                    imgWeightPic.Source = new BitmapImage(new Uri("/images/Underweight.png", UriKind.Relative));
                }
                else if (BMI >= 19 && BMI <= 25)
                {
                    imgWeightPic.Source = new BitmapImage(new Uri("/images/healthy.png", UriKind.Relative));
                }
                else if (BMI > 25 && BMI <= 29.5)
                {
                    imgWeightPic.Source = new BitmapImage(new Uri("/images/overweight.png", UriKind.Relative));
                }
                else
                {
                    imgWeightPic.Source = new BitmapImage(new Uri(" images/obese.png", UriKind.Relative));
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void WeightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(weightSlider!=null)
            {
                lblWeight.Content = weightSlider.Value;
            }
        }
    }
}
