using System;
public class figura2D {
    protected double posX;

    protected double posY; 

    public void ShowPos() { 

        Console.WriteLine("Las coordenadas del objeto son " + 

        posX + " and " + posY); 
    }

}

public class rectangulo:figura2D{ 

   double ancho; 
    double altura; 

   public double Area(){ 

      return ancho*altura; 

   } 

   public rectangulo(double an, double al){ 

      ancho=an; 

      altura=al; 

   }

   public rectangulo(double X, double Y,  

                     double an, double al){ 

      posX = X; 

      posY = Y; 

      ancho=an; 

      altura=al; 

   } 

    

} 
public class cuadrado : figura2D{
    
}
public interface triangulo{

}
public class isosceles : triangulo, figura2D{

}
public class trectangulo : triangulo, figura2D{

}
public class equilatero : triangulo, figura2D{

}
class figuras{ 

  static int Main(){ 

    figura2D fig=new figura2D(); 

    fig.ShowPos(); 

    rectangulo r = new rectangulo(3.0,5); 

    rectangulo r2 = new rectangulo(5,7,3.0,5); 

    r2.ShowPos(); 

    Console.WriteLine("El area del rectangulo r2 es:"+ 

    r2.Area()); 

    return 0; 

  } 

} 