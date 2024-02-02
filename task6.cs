using System;

class Matrix{
    public int[,] matrix;
    public int n;
    public int m;
    
    public Matrix(int y, int x){
        n = y;
        m = x;
        matrix = new int[n, m];
        generate_matrix();
        print_matrix();
    }

    public void print_matrix(){
        for (int i = 0; i < n; i++){
            for (int j = 0; j < m; j++){
                Console.Write(matrix[i, j]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    int generate_number(){
        Random num = new Random();
        return num.Next();
    }
    bool is_num_in_matrix(int num, int cur_i, int cur_j, int m){
        for(int i = 0; i < cur_i; i++){
            for(int j = 0; j < m; j++){
                if(matrix[i,j] == num){
                    return true;
                }
            }
        }

        for(int j = 0; j <= cur_j; j++){
            if(matrix[cur_i,j] == num){
                    return true;
                }
        }

        return false;
    }
    void generate_matrix(){
        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++){
                int number = generate_number();
                
                while (is_num_in_matrix(number, i, j, m)){
                    number = generate_number();
                }
                
                matrix[i, j] = number; 
            }
        }
    }
}

public class Program{
    public static void Main(string[] args){
        Matrix mat = new Matrix(2, 2);
        Matrix ob = new Matrix(9, 10);
    }
    
} 