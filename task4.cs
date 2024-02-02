using System;
class chess{   
    private bool isIndexInBoard(int x){
        if (x>=0){
            return x < 8;
        }return false;
    }
    public int[,] one_clear(int[,] board){
        for (int i = 0; i<8;i++){
            for (int j = 0; j<8;j++){
                if(board[i,j] == 1){
                    board[i,j] = 0;
                }
            }
        }
        return board;
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


    public int[,] move_knight_randomly(int[,] board, int x, int y){
        Random rand = new Random();
        y = 7 - (y - 1);
        x = x - 1;
        int[,] index = new int[8,3];

        if(isIndexInBoard(x + 2) && isIndexInBoard(y + 1) && board[y + 1, x + 2] <= 1){
            index[0,0] = x + 2;
            index[0,1] = y + 1;
            index[0,2] = 1;
        }
        if(isIndexInBoard(x + 2) && isIndexInBoard(y - 1) && board[y - 1, x + 2] <= 1){
            index[1,0] = x + 2;
            index[1,1] = y - 1;
            index[1,2] = 1;
        }
        if(isIndexInBoard(x - 2) && isIndexInBoard(y - 1) && board[y - 1, x - 2] <= 1){
            index[2,0] = x - 2;
            index[2,1] = y - 1;
            index[2,2] = 1;
        }
        if(isIndexInBoard(x - 2) && isIndexInBoard(y + 1) && board[y + 1, x - 2] <= 1){
            index[3,0] = x - 2;
            index[3,1] = y + 1;
            index[3,2] = 1;
        }
        if(isIndexInBoard(x + 1) && isIndexInBoard(y + 2) && board[y + 2, x + 1] <= 1){
            index[4,0] = x + 1;
            index[4,1] = y + 2;
            index[4,2] = 1;
        }
        if(isIndexInBoard(x + 1) && isIndexInBoard(y - 2) && board[y - 2, x + 1] <= 1){
            index[5,0] = x + 1;
            index[5,1] = y - 2;
            index[5,2] = 1;
        }
        if(isIndexInBoard(x - 1) && isIndexInBoard(y + 2) && board[y + 2, x - 1] <= 1){
            index[6,0] = x - 1;
            index[6,1] = y + 2;
            index[6,2] = 1;
        }
        if(isIndexInBoard(x - 1) && isIndexInBoard(y - 2) && board[y - 2, x - 1] <= 1){
            index[7,0] = x - 1;
            index[7,1] = y - 2;
            index[7,2] = 1;
        }
        int move = rand.Next(0,8);
        while(index[move,2]!= 1){
            move = rand.Next(0,8);
        }
        
        board[y,x] = 0;
        board[index[move,1],index[move,0]] = 2; 

        return board;
    
    }
}

public class Program{
    public static void Main(string[] args){
        chess knight = new chess();
        int[,] board = new int[8,8];
        board = knight.knight(board, 1, 1);
              
        knight.print_chess_board(board);
        Console.WriteLine();
        board = knight.one_clear(board);
        knight.print_chess_board(knight.move_knight_randomly(board, 1, 1)); 
    }
    
}  