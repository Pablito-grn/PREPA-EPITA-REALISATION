#load "graphics.cma";;
open Graphics ;;
#use "list_tools_acdc.ml";;

let open_window size = open_graph ( " " ^ string_of_int size ^ " x " ^ string_of_int ( size + 20) ) ;;
clear_graph();;

#load "unix.cma";;
open Unix;;
let sleep_time = 
  Unix.select [] [] [] 0.03;;

let new_cell = 1 ;;
let empty = 0 ;;
let is_cell_alive cell = cell <> empty ;; 



let rules0 cell near =
  if (cell = 0 && near = 3) || (cell = 1 && (near = 2 || near = 3)) then
    new_cell

  else 
    empty;;



let is_alive (x, y) board size = 
    if x > (-1) && x < size && y > (-1) && y < size && get_cell ((x), (y)) board = 1 then 
      new_cell
    else 
      empty;;



let count_neighbours (x, y) board size =
  begin
    is_alive ((x-1), (y-1)) board size + is_alive ((x-1), (y)) board size +
    is_alive ((x-1), (y+1)) board size + is_alive ((x), (y-1)) board size + 
    is_alive ((x), (y+1)) board size + is_alive ((x+1), (y-1)) board size +
    is_alive ((x+1), (y)) board size + is_alive ((x+1), (y+1)) board size
  end;;




let rec seed_life board size nb_cell = 
  if nb_cell > 0 then
    seed_life (put_cell 1 (Random.int (size), Random.int (size)) board) size (nb_cell-1)
  else
    board;;

   

let new_board size nb = 
 seed_life (init_board (size, size) 0) size nb;;


  
let next_generation board size = 
  let board_inter = board in
    let rec next_gen x y board = 
      if x < size then
        if y < size then 
          begin
            next_gen x (y+1) (put_cell (rules0 (get_cell (x, y) board_inter) (count_neighbours (x, y) board_inter size)) (x, y) board);
          end
        else
          next_gen (x+1) 0 board        
      else
        board
    in next_gen 0 0 board;;




let cell_size = 10;;

let game board size n =  
    let rec game_rec board size n = 
     match n with
    (*draw_board board cell_size ;*)
    |0 -> draw_board (next_generation board size) cell_size 
    |_ ->
        let board_inter = next_generation board size in
        begin
          draw_board board_inter cell_size ;
          game_rec board_inter size (n-1);
        end

 

    in game_rec board size n;;


let new_game size nb_cell n_gen=
  open_window (size);
  clear_graph ();

  game (new_board size nb_cell) size n_gen;;
 

new_game 50 1000 200 ;;

