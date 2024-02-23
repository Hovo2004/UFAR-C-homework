using System;
class quadratic_equation{
    public double a;
    public double b;
    public double c;
    public double x1;
    public double x2;

    public quadratic_equation(double x, double y, double z){
        a = x;
        b = y;
        c = z;
    }
    

    public void solver_with_ref(ref double x1, ref double x2){
        double d = Math.Pow(b,2) - 4*a*c;

        if (0 < d && 0 != a){
            x1 = (-b + Math.Pow(d,0.5))/(2*a);
            x2 = (-b - Math.Pow(d,0.5))/(2*a);
        }else if(0 == d && 0 != a){
            x1 = -b/(2*a);
            x2 = -b/(2*a);
        }else{
            Console.WriteLine("There is no real root");
        }
        
    }
    
    public (double, double) solver_with_tuple(){
        double d = Math.Pow(b,2) - 4*a*c;
        if (0 < d && 0 != a){
            x1 = (-b + Math.Pow(d,0.5))/(2*a);
            x2 = (-b - Math.Pow(d,0.5))/(2*a);
        }else if(0 == d && 0 != a){
            x1 = -b/(2*a);
            x2 = -b/(2*a);
        }else{
            Console.WriteLine("There is no real root");
        }
        
        return (x1, x2);
    }
    
    public double[] solver_with_array(){
        double d = Math.Pow(b,2) - 4*a*c;
        double[] arr = new double[2];
        if (0 < d && 0 != a){
            x1 = (-b + Math.Pow(d,0.5))/(2*a);
            x2 = (-b - Math.Pow(d,0.5))/(2*a);
        }else if(0 == d && 0 != a){
            x1 = -b/(2*a);
            x2 = -b/(2*a);
            
        }else{
            Console.WriteLine("There is no real root");
        }
        arr[0] = x1;
        arr[1] = x2;
        return arr;
    }
    
    public void Deconstruct( out double x, out double y){
        double d = Math.Pow(b,2) - 4*a*c;
        if (0 < d && 0 != a){
            x1 = (-b + Math.Pow(d,0.5))/(2*a);
            x2 = (-b - Math.Pow(d,0.5))/(2*a);
        }else if(0 == d && 0 != a){
            x1 = -b/(2*a);
            x2 = -b/(2*a);
            
        }else{
            Console.WriteLine("There is no real root");
        }
        x = x1; y = x2;
     }

}

public class Program{
    public static void Main(string[] args){
        quadratic_equation ob = new quadratic_equation(1, -3, 2);
        ob.solver_with_ref(ref ob.x1, ref ob.x2);
        Console.WriteLine(ob.x1 + " ref " + ob.x2);
        
        
        
        (double xx, double yy) = ob; // Deconstruction
        Console.WriteLine(xx + " Deconstructor " + yy);
        
        (double, double) x = ob.solver_with_tuple();
        
        Console.WriteLine(x.Item1 + " tuple " + x.Item2);
        
        double[] arr = ob.solver_with_array();
        Console.WriteLine(x.Item1 + " array " + x.Item2);
        
    }
}
