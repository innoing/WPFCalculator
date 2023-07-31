using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using static WPFCalculator.MainWindow;

namespace WPFCalculator
{

    //설계도
    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiple(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Divide(double n1, double n2)
        {
            return n1 / n2;
        }

    }
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    //enum을 이용하여 SeletedOperator.XXX를 사용하기 위해 선언 
    public enum SelectedOperator
    {
        Addition, //더하기
        Subtraction, //마이너스
        Multiplication, //곱하기
        Division //나누기
    }

    public partial class MainWindow : Window
    {
        //Method to Update expression on Text Field
        private void UpdateExpression(string ex)
        {
            //Update expression in txtBoxExpression as well as evaluationString
            evaluationString += ex;
            string text = resultLabel.Content.ToString(); 
            text += ex;
        }

        //현재 명령 및 현재 버튼 인덱스의 상태를 가져오려면
        private string currentCommand = "";
        private string currentBtnIndex = "";

        SelectedOperator selectedOperator; 
        //현재 디스플레이에 있는 페이지의 상태
        bool isSecondPage = false;

        //계산기 클래스 초기화
       // Calculator Calc = new Calculator();

        //기본 대괄호 만들기 버튼 클릭 횟수는 0입니다.
        int countOfBracket = 0;

        //계산기 모드 상태(예: 라디안 또는 도)
        bool isDegree = false;

        //평균 문자열 변수
        string evaluationString = "";

        double lastNumber;//연산하기 전 앞에 입력한 값을 저장하는 변수
     
        /*
        private void SwapValues()
        {
            //Swap values in evaluation string as well
            evaluationString = resultLabel.Content.ToString();
            txtBoxExpression.Text = resultLabel.Content.ToString();
            txtBoxResult.Text = "";
            //Reset count of bracket and change sign button
            countOfBracket = 0;
            //Place Ibeam at the last of string
            txtBoxExpression.Select(txtBoxExpression.Text.Length, 0);
        }
       */

        double result;//연산한 결과 값을 저장하는 변수
        public MainWindow()
        {
            InitializeComponent();
            //각 버튼에 대한 이벤트 함수를 안만들고 아래와 같이 상관 없음
            //AcButton.Click += AcButton_Click;
        }
      
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //아래의 이벤트 함수를 쓰려면 xaml에서 Click="numberButton_Click"로 해줘야 함
        //sender를 활용하여 sender가 각 버튼에 대한 Name일 때 적용
        //selectedValue을 사용하여 resultLabel(계산기 결과값)에 적용 
        /*
         sender는 어떤 오브젝트가 이 이벤트를 유발시켰는지를 나타나게 한다.
         다시 말해 이벤트를 보내는 객체이다.
         여러개의 버튼이 한가지 이벤트 함수를 공유하고 있을 때
         이 이벤트 함수가 어느 버튼에 의해서 유발되었는지를 알 수 있는 방법은
         sender를 확인해 보는것이다.
         즉.... 누가 이벤트를 부르고 있느냐에 대한 정보이다.!!

         e 는 EventArgs 형으로 이벤트 발생과 관련된 정보를 가지고 있다.
         즉 이벤트 핸들러가 사용하는 파라미터이다.
         예를 들어서 마우스 클릭 이벤트시에 마우스가 클릭된 곳의 좌표를 알고 싶다던가
          마우의 왼쪽 버튼인지 오른쪽 버튼인지를 알고 싶을 때 e의 내용을 참고 하면 될 것이다.

         이벤트 처리기(Event Handler)는 이벤트에 바인딩되는 메서드이다.
         이벤트가 발생하면 이벤트와 연결된 이벤트 처리기의 코드가 샐행된다.
         모든 이벤트 처리기는 위와 같은 두 개의 매개변수를 전달한다.
         */
        private void numberButtto_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("버튼 눌림")
            int selectedValue = 0;
            if (sender == ZeroButton) 
            {
                selectedValue = 0;
                if (resultLabel.Content.ToString() == "0") 
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == OneButton)
            {
                selectedValue = 1;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == TwoButton)
            {
                selectedValue = 2;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == ThreeButton)
            {
                selectedValue = 3;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == FourButton)
            {
                selectedValue = 4;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == FiveButton)
            {
                selectedValue = 5;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == SixButton)
            {
                selectedValue = 6;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == SevenButton)
            {
                selectedValue = 7;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == EightButton)
            {
                selectedValue = 8;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
            if (sender == NineButton)
            {
                selectedValue = 9;
                if (resultLabel.Content.ToString() == "0")
                {
                    resultLabel.Content = selectedValue.ToString();
                }
                else
                {
                    resultLabel.Content += selectedValue.ToString();
                }
            }
        }
        
        //Plus, Minus, Multiple, Divide 4개가 있는 이벤트 함수
        private void operationButtto_Click(object sender, RoutedEventArgs e)
        {
            lastNumber = double.Parse(resultLabel.Content.ToString());
            resultLabel.Content = 0;

            if (sender == PlusButton)
            {
                selectedOperator = SelectedOperator.Addition;
            }

            if (sender == MinusButton)
            {
                selectedOperator = SelectedOperator.Subtraction;
            }
            
            if (sender == MultipleButton)
            {
                selectedOperator = SelectedOperator.Multiplication;
            }
           
            if (sender == DivideButton)
            {
                selectedOperator = SelectedOperator.Division;..
            }




        }
        //AC 버튼 클릭
        private void ACButtto_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }
        //( )버튼 클릭
        private void PlusMinusButton_Click(object sender, RoutedEventArgs e)
        {
            double lastNumber;
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString(); 
            }
        }
        //Percent 버튼 클릭
        private void PercentButtto_Click(object sender, RoutedEventArgs e)
        {
            double lastNumber;
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * 0.01;
                resultLabel.Content = lastNumber.ToString();
            }
        }
        //Dot 버튼 클릭
        private void DotButtto_Click(object sender, RoutedEventArgs e)
        {
            Boolean a;
            a = resultLabel.Content.ToString().Contains(".");

            if(resultLabel.Content.ToString() == "0")
            {
                return; 
            }
            else
            {
                if(a == false)
                {
                    resultLabel.Content += "."; 
                }
            }
        }

        private void EqulButtto_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            newNumber = double.Parse(resultLabel.Content.ToString());

            switch(selectedOperator)
            {
                case SelectedOperator.Addition:
                    result = SimpleMath.Add(lastNumber, newNumber);
                    break;
                case SelectedOperator.Subtraction:
                    result = SimpleMath.Subtract(lastNumber, newNumber);
                    break;
                case SelectedOperator.Multiplication:
                    result = SimpleMath.Multiple(lastNumber, newNumber);
                    break;
                case SelectedOperator.Division:
                    result = SimpleMath.Divide(lastNumber, newNumber);
                    break;
            }
            resultLabel.Content = result.ToString(); 
        }

        //Eqel 버튼 클릭
    }
}
