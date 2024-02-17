heurostic_placement_queen a = new heurostic_placement_queen();
int[,] board = new int[8,8];
a.queen_heurostic_placement(board, 7, 5);
a.print_chess_board(board);


class heurostic_placement_queen{
    private bool isInBoard(int x, int y){
        if(x >= 0 && y>=0 && y < 8 && x < 8){
            return true;
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

    private int zero_count(int[,] board){
        int count = 0;
        for(int i = 0; i < 8; i++){
            for(int j = 0; j < 8; j++){
                if (board[i, j] == 0){
                    count++;
                }
            }
        }
        return count;
    }

    private int[,] queen_placement(int[,] board, int x, int y){
        x = 7 - (x - 1);
        y = y - 1;

        if(board[x, y] == 0){
            board[x, y] = 9;
        }else{
            return board;
        }

        int i = x + 1;
        int j = y + 1;
        while(isInBoard(i, j) && (board[i, j] == 0 || board[i, j] == 1)){
            board[i, j] = 1;
            i++;
            j++;
        }

        i = x - 1;
        j = y + 1;
        while(isInBoard(i, j) && (board[i, j] == 0 || board[i, j] == 1)){
            board[i, j] = 1;
            i--;
            j++;
        }

        i = x + 1;
        j = y - 1;
        while(isInBoard(i, j) && (board[i, j] == 0 || board[i, j] == 1)){
            board[i, j] = 1;
            i++;
            j--;
        }

        i = x - 1;
        j = y - 1;
        while(isInBoard(i, j) && (board[i, j] == 0 || board[i, j] == 1)){
            board[i, j] = 1;
            i--;
            j--;
        }

        i = x + 1;
        while(isInBoard(i, y) && (board[i, y] == 0 || board[i, y] == 1)){
            board[i, y] = 1;
            i++;
        }

        i = x - 1;
        while(isInBoard(i, y) && (board[i, y] == 0 || board[i, y] == 1)){
            board[i, y] = 1;
            i--;
        }

        j = y + 1;
        while(isInBoard(x, j) && (board[x, j] == 0 || board[x, j] == 1)){
            board[x, j] = 1;
            j++;
        }

        j = y - 1;
        while(isInBoard(x, j) && (board[x, j] == 0 || board[x, j] == 1)){
            board[x, j] = 1;
            j--;
        }
        return board;
    }

    private (int, int) best_place(int[,] board){
        int[,] best_place = new int[8,8];
        int[,] new_board = board;
        int count = 0;
        int[] max = new int[3];
        bool flag = false;
        for(int i = 0; i < 8; i++){
            for(int j = 0; j < 8; j++){
                if (board[i,j] == 0){
                    new_board = queen_placement(new_board, 8 - i, j + 1);
                    count = zero_count(new_board);
                    best_place[i, j] = count;
                    new_board = board;
                    flag = true;
                }
            }
        }

        if(!flag){
            return (-1, -1);
        }
        for(int i = 0; i < 8; i++){
            for(int j = 0; j < 8; j++){
                if (best_place[i,j] > max[2]){
                    max[0] = i;
                    max[1] = j;
                    max[2] = best_place[i,j];
                }
            }
        }

        return (max[0], max[1]);
    }

    public int[,] queen_heurostic_placement(int[,] board, int x, int y){
        board = queen_placement(board, x, y);
        (int, int) place = best_place(board);
        while(-1 != place.Item1){
            board = queen_placement(board, 8 - place.Item1, place.Item2 + 1);
            place = best_place(board);
        }
        return board;
    }

}