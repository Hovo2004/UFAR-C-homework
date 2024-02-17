
Console.WriteLine("Hello, World!");
int[,] board = {{2,3,4,4,4,4,3,2},
                {3,4,6,6,6,6,4,3},
                {4,6,8,8,8,8,6,4},
                {4,6,8,8,8,8,6,4},
                {4,6,8,8,8,8,6,4},
                {4,6,8,8,8,8,6,4},
                {3,4,6,6,6,6,4,3},
                {2,3,4,4,4,4,3,2}};

knight_heuristic ob = new knight_heuristic();
board = ob.knight_heuristic_placement(board, 1, 4);
ob.print_chess_board(board);

class knight_heuristic{
    int[,] print_board = new int[8,8];
    

    private bool isIndexInBoard(int x){
        if (x>=0){
            return x < 8;
        }return false;
    }

    public void print_chess_board(int[,] board){
        for (int i = 0; i < 8; i++){
            for(int j = 0; j < 8; j++){
                Console.Write(board[i, j]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

    }
    private int[,] knight_move(int[,] board, int x, int y){
        board[x, y] = -1;
        if(isIndexInBoard(x + 2) && isIndexInBoard(y + 1) && board[x + 2, y + 1] != -1){
            board[x + 2, y + 1] -= 1;
        }
        if(isIndexInBoard(x + 2) && isIndexInBoard(y - 1) && board[x + 2, y - 1] != -1){
            board[x + 2, y - 1] -= 1;
        }
        if(isIndexInBoard(x - 2) && isIndexInBoard(y - 1) && board[x - 2, y - 1] != -1){
            board[x - 2, y - 1] -= 1;
        }
        if(isIndexInBoard(x - 2) && isIndexInBoard(y + 1) && board[x - 2, y + 1] != -1){
            board[x - 2, y + 1] -= 1;
        }
        if(isIndexInBoard(x + 1) && isIndexInBoard(y + 2) && board[x + 1, y + 2] != -1){
            board[x + 1, y + 2] -= 1;
        }
        if(isIndexInBoard(x + 1) && isIndexInBoard(y - 2) && board[x + 1, y - 2] != -1){
            board[x + 1, y - 2] -= 1;
        }
        if(isIndexInBoard(x - 1) && isIndexInBoard(y + 2) && board[x - 1, y + 2] != -1){
            board[x - 1, y + 2] -= 1;
        }
        if(isIndexInBoard(x - 1) && isIndexInBoard(y - 2) && board[x - 1, y - 2] != -1){
            board[x - 1, y - 2] -= 1;
        }
        
        return board;
    }
    private (int, int) best_place(int[,] board, int x, int y){
        int[,] index = new int[8,4];

        if(isIndexInBoard(x + 2) && isIndexInBoard(y + 1) && board[x + 2, y + 1] >= 1){
            index[0,0] = x + 2;
            index[0,1] = y + 1;
            index[0,2] = 1;
            index[0,3] = board[x + 2, y + 1];
        }
        if(isIndexInBoard(x + 2) && isIndexInBoard(y - 1) && board[x + 2, y - 1] >= 1){
            index[1,0] = x + 2;
            index[1,1] = y - 1;
            index[1,2] = 1;
            index[1,3] = board[x + 2, y - 1];
        }
        if(isIndexInBoard(x - 2) && isIndexInBoard(y - 1) && board[x - 2, y - 1] >= 1){
            index[2,0] = x - 2;
            index[2,1] = y - 1;
            index[2,2] = 1;
            index[2,3] = board[x - 2, y - 1];
        }
        if(isIndexInBoard(x - 2) && isIndexInBoard(y + 1) && board[x - 2, y + 1] >= 1){
            index[3,0] = x - 2;
            index[3,1] = y + 1;
            index[3,2] = 1;
            index[3,3] = board[x - 2, y + 1];
        }
        if(isIndexInBoard(x + 1) && isIndexInBoard(y + 2) && board[x + 1, y + 2] >= 1){
            index[4,0] = x + 1;
            index[4,1] = y + 2;
            index[4,2] = 1;
            index[4,3] = board[x + 1, y + 2];
        }
        if(isIndexInBoard(x + 1) && isIndexInBoard(y - 2) && board[x + 1, y - 2] >= 1){
            index[5,0] = x + 1;
            index[5,1] = y - 2;
            index[5,2] = 1;
            index[5,3] = board[x + 1, y - 2];
        }
        if(isIndexInBoard(x - 1) && isIndexInBoard(y + 2) && board[x - 1, y + 2] >= 1){
            index[6,0] = x - 1;
            index[6,1] = y + 2;
            index[6,2] = 1;
            index[6,3] = board[x - 1, y + 2];
        }
        if(isIndexInBoard(x - 1) && isIndexInBoard(y - 2) && board[x - 1, y - 2] >= 1){
            index[7,0] = x - 1;
            index[7,1] = y - 2;
            index[7,2] = 1;
            index[7,3] = board[x - 1, y - 2];
        }


        bool flag1 = false;
        bool flag2 = false;
        int min = 0;
        int tupic = 0;

        for (int i = 0; i < 8; i++){
            if(index[i, 2] == 1){
                min = i;
                break;
            }
        }

        for (int i = 0; i < 8; i++){
            if(index[i, 2] == 1){
                flag1 = true;
                if (index[i, 3] > 0 && index[i, 3] < index[min, 3]){
                    min = i;
                }else if(index[i, 3] == 0){
                    flag2 = true;
                    tupic = i;
                }
            }

        }
        
        if(flag1){
            return (index[min, 0], index[min, 1]);
        }else{
            if(flag2){
                return (index[tupic, 0], index[tupic, 1]);
            }else{
                return (-1, -1);
            }
        }
    
    }
    

    public int[,] knight_heuristic_placement(int[,] board, int x, int y){
        x = 7 - (x - 1);
        y = y - 1;
        board = knight_move(board, x, y);
        print_board[x, y] = 7;
        (int, int) move = best_place(board, x, y);
        while (-1 != move.Item1){
            board = knight_move(board, move.Item1, move.Item2);
            print_board[move.Item1, move.Item2] = 7;
            move = best_place(board, move.Item1, move.Item2);
        }

        return print_board;
    }
}