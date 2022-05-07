let rec length = function
    [] -> 0
  | _::l -> 1 + length l ;;

let rec append l1 l2 = match l1 with
        [] -> l2
       |e::l1 -> e:: append l1 l2;;

let rec product = function
        [] -> 1
        |e::l -> e * product l;;

let nth n list =
  if n < 0 then
    invalid_arg "nth: index must be a natural"
  else
    let rec nth_rec = function
      | ([], _) -> failwith "nth: list is too short"
      | (e::_, 0) -> e
      | (_::l, n) -> nth_rec (l, n-1)
    in
      nth_rec (list, n) ;;

let rec search_pos x = function
    [] -> failwith "search_pos: not found"
  | e :: l -> (if e = x then 0 else 1) + search_pos x l ;;

let assoc degre poly =
	if degre < 0 then
		failwith "assoc: negative degree"
	else

		let rec search = function
		[] -> 0
		| (c, d)::l -> if d = degre then c
						else if d < degre then 0
						else search l
	in search poly ;;

(***********************  BUILD / MODIFY LISTS  *************************)

(* init_list *)

let init_list n value =
  if n < 0 then
    invalid_arg "init_list: n must be a natural"
  else
    let rec build = function
      | 0 -> []
      | n -> value :: build (n-1)
    in
      build n ;;

(* put_list *)

let put_list v i list =
  if i < 0 then
    invalid_arg "put_list: index must be a natural"
  else
    let rec put = function
      | (_, []) -> []
      | (0, _::l) -> v :: l
      | (n, e::l) -> e :: (put ((n-1), l))
    in
      put (i, list) ;;

(* init_board: generate a nblines x nbcolumn  matrix filled with x *)

let init_board (nblines, nbcolumns) x =
  if nblines <= 0 || nbcolumns <= 0 then
    invalid_arg "init_board: one dimension not a non-zero natural"
  else
    init_list nblines (init_list nbcolumns x) ;;


(* get_cell: extract value at position (x, y) from an 'a list list *)

let get_cell (x, y) board =
  nth y (nth x board) ;;


(* put_cell: replace value at (x,y) in board by cell (no "out of bound" test!) *)

let put_cell cell (x, y) board =
  let rec process_row = function
    | (_, []) -> []
    | (0, l::ll) -> (put_list cell y l) :: ll
    | (n, l::ll) -> l :: (process_row ((n-1), ll))
  in
    process_row (x, board);;


(*------------------------------------------------------------------------------------------------------------
                                                Game Of Life
------------------------------------------------------------------------------------------------------------*)
(*# load "graphics.cma" ;;
open Graphics ;;        
let open_window size = open_graph ( " " ^ string_of_int size ^ " x " ^ string_of_int ( size + 20) ) ;;
clear_graph();;*)


let draw_cell (x, y) cell_size color =
  begin

    set_color color;
    fill_rect x y cell_size cell_size;

    set_color (rgb 127 127 127);
    draw_rect x y cell_size cell_size;

  end;;


let cell_color = function 
  |0 -> white
  |_ -> black 
;;



let draw_board board cell_size =
  clear_graph ();

  let rec colonne x y board = match board with
    |e::c -> 
      begin
        draw_cell (x, y) cell_size (cell_color e);
        colonne x (y + cell_size) c;
      end;
    |_ -> ()
  in

  let rec ligne x board = match board with
    |l::board -> 
      begin
        colonne x cell_size l;
        ligne (x + cell_size) board;
      end;
    |_ -> () 

  in ligne cell_size board;;


(*let board = [[1; 1; 1; 1; 1; 1; 1; 1; 1; 1];
[0; 0; 0; 0; 0; 0; 0; 0; 0; 0];
[1; 0; 1; 0; 1; 0; 1; 0; 1; 0];
[0; 1; 0; 1; 0; 1; 0; 1; 0; 1];
[0; 0; 0; 0; 0; 0; 0; 0; 0; 0];
[1; 1; 1; 1; 1; 1; 1; 1; 1; 1];
[0; 0; 0; 0; 0; 0; 0; 0; 0; 0];
[1; 0; 1; 0; 1; 0; 1; 0; 1; 0];
[0; 1; 0; 1; 0; 1; 0; 1; 0; 1];
[0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
] ;;

let test_display board cell_size = open_window ( length board * cell_size + 40) ;
draw_board board cell_size ;;

test_display board 10 ;;*)
