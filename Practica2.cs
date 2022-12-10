using System;
using System.Threading;
public class ComplexException : Exception{
    public ComplexException(){
        Console.WriteLine("Error not found\n");
    }
    public ComplexException(string message) : base(message){
        Console.WriteLine("Error: " + message + "\n");
    }
}
public class ComplexNumber{
    private string _number;
    private int _last, _last2;
    private double _realNumber, _imaginaryNumber;
    private double _getRealNumber(){
        try{
            bool negative = false;
            string realNumber = "";
            for(int i = 0 ; i < _number.Length ; i++){
                if(_number[0] == '-' && !negative){i++ ; negative = true;}
                char value = _number[i];
                if((int)value >= 48 && (int)value <= 57){
                    realNumber += value;
                }else{
                    if(value == 'i') throw new ComplexException("Invalid Format");
                    _last = i;
                    break;
                }
            }
            _realNumber = (negative) ? (-1)*Convert.ToDouble(realNumber) : Convert.ToDouble(realNumber);
            return _realNumber;
        }catch(Exception exception){
            Console.WriteLine("Error detected trying to convert: " + exception.ToString() + "\n");
            return -1;
        }
    }
    private double _getImaginaryNumber(){
        if(_last > 0){
            try{
                bool negative = false;
                while((int)_number[_last] < 48 || (int)_number[_last] > 57){
                    if(_number[_last] == '-' && !negative) negative = true;
                    _last++;
                }
                string number = "";
                for(int i = _last ; i < _number.Length - 1 ; i++){
                    number += _number[i];
                }
                _imaginaryNumber = (negative) ? (-1)*Convert.ToDouble(number) : Convert.ToDouble(number);
                return _imaginaryNumber;
            }catch(Exception ex){
                Console.WriteLine("Error trying to convert the imaginary number: " + ex.ToString());
                return -1;
            }
        }else throw new ComplexException("No real number detected");
    }
    private double _getRealNumber(string number){
        try{
            bool negative = false;
            string realNumber = "";
            for(int i = 0 ; i < number.Length ; i++){
                if(number[0] == '-' && !negative) { i++ ; negative = true;}
                char value = number[i];
                if((int)value >= 48 && (int)value <= 57){
                    realNumber += value;
                }else{
                    if(value == 'i') throw new ComplexException("Invalid Format");
                    _last2 = i;
                    break;
                }
            }
            return (negative) ? (-1)*Convert.ToDouble(realNumber) : Convert.ToDouble(realNumber);
        }catch(Exception exception){
            Console.WriteLine("Error detected trying to convert: " + exception.ToString() + "\n");
            return -1;
        }
    }
    private double _getImaginaryNumber(string number){
        if(_last2 > 0){
            bool negative = false;
            while((int)number[_last2] < 48 || (int)number[_last2] > 57){
                if(!negative && number[_last2] == '-') negative = true;
                _last2++;
            }
            string retNumber = "";
            for(int i = _last2 ; i < number.Length - 1 ; i++){
                retNumber += number[i];
            }
            return (negative) ? (-1)*Convert.ToDouble(retNumber) : Convert.ToDouble(retNumber);
        }else throw new ComplexException("No real number detected");
    }
    public ComplexNumber(string number){
        this._number = number;
        _realNumber = _getRealNumber();
        _imaginaryNumber = _getImaginaryNumber();
        _last = 0;
        _last2 = 0;
    }
    public ComplexNumber(){
        this._number = null;
        _last = 0;
        _last2 = 0;
    }
    public string getNumber(){
        return this._number;
    }
    public double getImaginaryNumber(){
        return this._imaginaryNumber;
    }
    public double getRealNumber(){
        return this._realNumber;
    }
    public void Addition(string newNumber){
        try{
            double realPart = _realNumber + _getRealNumber(newNumber);
            double imagPart = _imaginaryNumber + _getImaginaryNumber(newNumber);
            _number = realPart.ToString() + " + " + imagPart.ToString() + "i";
        }catch(Exception exception){
            Console.WriteLine("Error trying to complete the operation: " + exception.ToString());
        }
    }
    public void Subtraction(string newNumber){
        try{

            double realPart = _realNumber - _getRealNumber(newNumber);
            double imagPart = _imaginaryNumber - _getImaginaryNumber(newNumber);
            _number = realPart.ToString() + " + " + imagPart.ToString() + "i";
        }catch(Exception exception){
            Console.WriteLine("Error trying to complete the operation: " + exception.ToString());
        }
    }
    public void Divide(string newNumber){
        try{
            double realPartNew = _getRealNumber(newNumber), imagPartNew = _getImaginaryNumber(newNumber);
            double topReal = (_realNumber*realPartNew)+(_imaginaryNumber*imagPartNew);
            double topImag = (_imaginaryNumber*realPartNew)-(_realNumber*imagPartNew);
            double bottom = (Math.Pow(realPartNew,2) + Math.Pow(imagPartNew,2));
            _number = "(" + topReal + " / " + bottom.ToString() + ") + (" + topImag + " / " + bottom.ToString() + ")i";
        }catch(Exception exception){
            Console.WriteLine("Error trying to complete the operation: " + exception.ToString());
        }
    }
    public void Multiply(string newNumber){
        try{
            double realPartOriginal = _realNumber, realPartNew = _getRealNumber(newNumber), imagPartOriginal = _imaginaryNumber, imagPartNew = _getImaginaryNumber(newNumber);
            _number = ((realPartOriginal*realPartNew) - (imagPartOriginal*imagPartNew)).ToString() + " + " + ((realPartOriginal*imagPartNew) + (imagPartOriginal*realPartNew)).ToString() + "i";
        }catch(Exception exception){
            Console.WriteLine("Error trying to complete the operation: " + exception.ToString());
        }
    }
    public static ComplexNumber operator +(ComplexNumber number1,ComplexNumber number2){
        try{
            double realPart = number1.getRealNumber() + number2.getRealNumber();
            double imagPart = number1.getImaginaryNumber() + number2.getImaginaryNumber();
            ComplexNumber result = new ComplexNumber((realPart.ToString() + " + " + imagPart.ToString() + "i").ToString());
            return result;
        }catch(Exception exception){
            Console.WriteLine("Error trying to complete the operation: " + exception.ToString());
            return null;
        }
    }
    public static ComplexNumber operator -(ComplexNumber number1,ComplexNumber number2){
        try{
            double realPart = number1.getRealNumber() - number2.getRealNumber();
            double imagPart = number1.getImaginaryNumber() - number2.getImaginaryNumber();
            ComplexNumber result = new ComplexNumber(realPart.ToString() + " + " + imagPart.ToString() + "i");
            return result;
        }catch(Exception exception){
            Console.WriteLine("Error trying to complete the operation: " + exception.ToString());
            return null;
        }
    }
    public static ComplexNumber operator *(ComplexNumber number1,ComplexNumber number2){
        try{
            double realPartOriginal = number1.getRealNumber(), realPartNew = number2.getRealNumber(), imagPartOriginal = number1.getImaginaryNumber(), imagPartNew = number2.getImaginaryNumber();
            ComplexNumber result = new ComplexNumber(((realPartOriginal*realPartNew) - (imagPartOriginal*imagPartNew)).ToString() + " + " + ((realPartOriginal*imagPartNew) + (imagPartOriginal*realPartNew)).ToString() + "i");
            return result;
        }catch(Exception exception){
            Console.WriteLine("Error trying to complete the operation: " + exception.ToString());
            return null;
        }
    }
    public static ComplexNumber operator /(ComplexNumber number1,ComplexNumber number2){
        try{
            double realPartNew = number2.getRealNumber(), imagPartNew = number2.getImaginaryNumber(), realPartOriginal = number1.getRealNumber(), imagPartOriginal = number1.getImaginaryNumber();
            double topReal = (realPartOriginal*realPartNew)+(imagPartOriginal*imagPartNew);
            double topImag = (imagPartOriginal*realPartNew)-(realPartOriginal*imagPartNew);
            double bottom = (Math.Pow(realPartNew,2) + Math.Pow(imagPartNew,2));
            string res = (topReal/bottom) + " + " + (topImag/bottom) + "i";
            ComplexNumber result = new ComplexNumber(res);
            return result;
        }catch(Exception exception){
            Console.WriteLine("Error trying to complete the operation: " + exception.ToString());
            return null;
        }
    }
}
namespace Practica2{
    class MainClass{
        static void Main(){
            Console.WriteLine("Type the first complex number (First the real, and the de complex) (Eg. 123 + 123i)\n");
            string num1 = Console.ReadLine();
            Console.WriteLine("Type the second complex number (First the real, and the de complex) (Eg. 123 + 123i)\n");
            string num2 = Console.ReadLine();
            ComplexNumber number1 = new ComplexNumber(num1), number2 = new ComplexNumber(num2);
            string decision;
            bool continues = true;
            do{
                try{
                    ComplexNumber result = new ComplexNumber();
                    Console.WriteLine("1) Addition\n2) Subtraction\n3) Multiplication\n4) Division\n5) Change numbers\n");
                    int n = Convert.ToInt32(Console.ReadLine());
                    switch(n){
                        case 1: result = number1 + number2; break;
                        case 2: result = number1 - number2; break;
                        case 3: result = number1 * number2; break;
                        case 4: result = number1 / number2; break;
                        case 6: num1 = Console.ReadLine(); num2 = Console.ReadLine(); number1 = new ComplexNumber(num1); number2 = new ComplexNumber(num2); break;
                        default: Console.WriteLine("Invalid number, try again\n"); break;
                    }
                    if(result.getNumber() != string.Empty) Console.WriteLine("The result is: " + result.getNumber() + "\n");
                    Console.WriteLine("Do you want to continue? (y/n): \n");
                    decision = Console.ReadLine();
                    if(decision == "n" || decision == "N") continues = false;
                }catch(Exception ex){
                    Console.WriteLine("Error unexpected: " + ex.ToString());
                    Thread.Sleep(1000);
                    Console.WriteLine("Clearing data...\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("Clearing buffer...\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("Restarting...\n");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Type the first complex number (First the real, and the de complex) (Eg. 123 + 123i)\n");
                    num1 = Console.ReadLine();
                    Console.WriteLine("Type the second complex number (First the real, and the de complex) (Eg. 123 + 123i)\n");
                    num2 = Console.ReadLine();
                    number1 = new ComplexNumber(num1); number2 = new ComplexNumber(num2); break;
                }
            }while(continues);
            /*
            Another way to use the operations
            var addition = number1.Addition(number2.getNumber());
            var subtraction = number1.Subtraction(number2.getNumber());
            var multiplication = number1.Multiply(number2.getNumber());
            var division = number1.Divide(number2.getNumber());
            */
        }
    }
}