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
    public int[,] knight(int[,] board, int x, int y){
        y = 7 - (y - 1);
        x = x - 1;
  
        if (board[y,x] == 0){
            board[y,x] = 2;
        }else{
            Console.WriteLine("There is already exist a figure");
            return board;
        }
        
        if(isIndexInBoard(y + 2) && isIndexInBoard(x + 1)){
            if(board[y + 2, x + 1] == 0){
                board[y + 2, x + 1] = 1;
            }
        }
        if(isIndexInBoard(y + 2) && isIndexInBoard(x - 1)){
            if(board[y + 2, x - 1] == 0){
                board[y + 2, x - 1] = 1;
            }
        }
        if(isIndexInBoard(y - 2) && isIndexInBoard(x + 1)){
            if(board[y - 2, x + 1] == 0){
                board[y - 2, x + 1] = 1;
            }
        }
        if(isIndexInBoard(y - 2) && isIndexInBoard(x - 1)){
            if(board[y - 2, x - 1] == 0){
                board[y - 2, x - 1] = 1;
            }
        }
        if(isIndexInBoard(y + 1) && isIndexInBoard(x + 2)){
            if(board[y + 1, x + 2] == 0){
                board[y + 1, x + 2] = 1;
            }
        }
        if(isIndexInBoard(y - 1) && isIndexInBoard(x + 2)){
            if(board[y - 1, x + 2] == 0){
                board[y - 1, x + 2] = 1;
            }
        }
        if(isIndexInBoard(y + 1) && isIndexInBoard(x - 2)){
            if(board[y + 1, x - 2] == 0){
                board[y + 1, x - 2] = 1;
            }
        }
        if(isIndexInBoard(y - 1) && isIndexInBoard(x - 2)){
            if(board[y - 1, x - 2] == 0){
                board[y - 1, x - 2] = 1;
            }
        }
        return board;
    }
    
    

    
}

public class Program{
    public static void Main(string[] args){
        chess knight = new chess();
        int[,] board = new int[8,8];
        knight.print_chess_board(knight.knight(board,3,4)); 
    }
    
}  