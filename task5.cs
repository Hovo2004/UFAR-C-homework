using System;

class MaxMin{
    int max_row(int[,] matrix, int m, int i){
        int[] arr = new int[m];
        for (int j = 0; j < m; j++){
            arr[j] = matrix[j,i];
        }
        int max = arr[0];
        for (int j = 0; j < m; j++){
            if(arr[j] > max){
                max = arr[j];
            }
        }
        return max;
    }

    int min_column(int[,] matrix, int n, int i){    
        int min = matrix[i,0];
        for (int j = 0; j < n; j++){
            if(matrix[i,j] < min){
                min = matrix[i,j];
            }
        }
        return min;
    }

    public int[] max_row_min_column(int[,] matrix, int m, int n){
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(min_column(matrix, n, i) == matrix[i,j] && max_row(matrix, m, j) == matrix[i,j]){
                    int[] index = {i,j};
                    return index;
                }
            }
        }
        int[] ind = {-1,-1};
        return ind;
    }
}
public class Program{
    public static void Main(string[] args){
        MaxMin element = new MaxMin();
        int[,] arr = {{9, 2, 1},
                       {0,-1,3}};
        int[] index = new int[2];
        index = element.max_row_min_column(arr, 2,3);
        if (index[0] != -1){
            Console.WriteLine(arr[index[0],index[1]]);
        }else{
            Console.WriteLine("no");
        }
    }
    
} 