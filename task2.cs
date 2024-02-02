using System;
class chess{
    
    private bool isIndexInBoard(int x){
        if (x>=0){
            return x < 8;
        }return false;
    }
    
    public void print_chess_board(int[,] board){
        for(int i = 0; i<8; i++){
            for(int j = 0; j<8; j++){
                Console.Write(board[i,j]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
    
    
    public int[,] queen(int[,] board, int x, int y){
        y = 7 - (y - 1);
        x = x - 1;
        
        if (board[y,x] == 0){
            board[y,x] = 9;
        }else{
            Console.WriteLine("There is already exist a figure");
            return board;
        }
        int i = x + 1;
        int j = y + 1;
        while (isIndexInBoard(i) && isIndexInBoard(j) && (board[j, i] == 0 || board[j, i] == 1)){
            board[j, i] = 1;
            i++;
            j++;
        }
        i = x - 1;
        j = y + 1;
        while (isIndexInBoard(i) && isIndexInBoard(j) && (board[j, i] == 0 || board[j, i] == 1)){
            board[j, i] = 1;
            i--;
            j++;
        }
        i = x + 1;
        j = y - 1;
        while (isIndexInBoard(i) && isIndexInBoard(j) && (board[j, i] == 0 || board[j, i] == 1)){
            board[j, i] = 1;
            i++;
            j--;
        }
        i = x - 1;
        j = y - 1;
        while (isIndexInBoard(i) && isIndexInBoard(j) && (board[j, i] == 0 || board[j, i] == 1)){
            board[j, i] = 1;
            i--;
            j--;
        }
        i = x;
        j = y + 1;
        while (isIndexInBoard(i) && isIndexInBoard(j) && (board[j, i] == 0 || board[j, i] == 1)){
            board[j, i] = 1;
            j++;
        }
        i = x;
        j = y - 1;
        while (isIndexInBoard(i) && isIndexInBoard(j) && (board[j, i] == 0 || board[j, i] == 1)){
            board[j, i] = 1;
            j--;
        }
        i = x + 1;
        j = y;
        while (isIndexInBoard(i) && isIndexInBoard(j) && (board[j, i] == 0 || board[j, i] == 1)){
            board[j, i] = 1;
            i++;
        }
        i = x - 1;
        j = y;
        while (isIndexInBoard(i) && isIndexInBoard(j) && (board[j, i] == 0 || board[j, i] == 1)){
            board[j, i] = 1;
            j--;
        }
       
        return board;
    } 
    
    
}

public class Program{
    public static void Main(string[] args){
        int[,] board = new int[8,8];
        chess queen = new chess();
        board = queen.queen(board,4,5);
        queen.print_chess_board(board);
    }
    
}  