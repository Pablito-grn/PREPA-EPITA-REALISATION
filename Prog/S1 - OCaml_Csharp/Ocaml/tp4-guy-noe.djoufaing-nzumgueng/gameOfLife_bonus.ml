let remaining board size = 
 
  let rec remain_rec x y board = 
    if x < size then
      if y < size then 
        if is_cell_alive (get_cell (x, y) board) = true  then
          true
        else
          remain_rec x (y+1) board
      else
       remain_rec (x+1) 0 board
    else
      false

  in remain_rec 0 0 board;;

let new_game size nb_cell n_gen = 
  open_window (size);
  clear_graph ();

  if n_gen = 0 then
    let rec new_game_rec size board = 
      if remaining (board) size = true then
        begin
          game board size 1;
          new_game_rec size (next_generation board size) ;
        end
    in new_game_rec size (new_board size nb_cell)

  else
    game (new_board size nb_cell) size n_gen;;

new_game 23 100 0;
