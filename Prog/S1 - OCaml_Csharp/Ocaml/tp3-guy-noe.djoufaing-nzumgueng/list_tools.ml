(*-----------------------length--------------------------------*)
(*
length [0; 1; 0; 1; 0; 0; 0; 0; 1; 1] ;;
*)

let rec length = function
    [] -> 0
  |e::r -> 1+ length r;;

 (* -----------------------append--------------------------------*)
(*
append ['a'; 'b'; 'c'] [] ;;
append [’a ’; ’b ’; ’c ’] [] ;;
*)

let rec append l1 l2 = match l1 with
    [] -> l2
  |e::r -> e::(append r l2);;

 (* -----------------------product--------------------------------*)
(*
 product [1; 2; 3; 4; 5] ;;
*)

let rec product = function
    [] -> 1 
  |e::r -> e*product r

  
 (* -----------------------nth--------------------------------*)
(*
 nth 5 [1; 2; 3; 4; 5] ;;
 nth 0 [’a ’; ’b ’; ’c ’] ;;
*)

let nth i l =
  if i < 0 then
    raise(Invalid_argument"nth : index must be a natural")
  else 
    
    
    let rec nth_rec i = function
        [] -> raise (Failure "nth: list is too short")
      |e::r -> if i = 0 then 
            e
          else 
            nth_rec (i-1) r
    in nth_rec i l;;
 (* ----------------------- search_pos --------------------------------*)
(*
search_pos 0 [1; 5; -1; 0; 8; 0] ;;
search_pos 'z' ['r';'h';'j';'o'] ;;
*)

let rec search_pos k r = match r with
  
  | e::r -> if e =  k then 

        0

      else  1+search_pos k r 

  |_ -> raise(Failure " search_pos: not found");;



  
  (*----------------------- assoc --------------------------------*)
(*
 assoc 1 [(4 ,5) ; (1 ,2) ; ( -3 ,1) ; (1 ,0)] ;;
 assoc 3 [(4 ,5) ; (1 ,2) ; ( -3 ,1) ; (1 ,0)] ;;
*)

let assoc k l = 
  if k < 0 then 
    raise(Failure "assoc: negative degree")
  else 
    let rec assoc_rec k = function 
        [] -> 0
      |(a, b)::[] -> if b=k then 
            a 
          else 
            0
      |(a, b)::l -> if b=k then 
            a
          else 
            assoc_rec k l
    in assoc_rec k l;;

    

(*======================== CONSTRUIRE - MODIFIER =======================*)

 (* -----------------------init_list--------------------------------*)
(*
init_list 5 0 ;;
init_list 0 'a' ;;
init_list ( -5) 1.5 ;;
*)

let init_list n k = if n < 0 then
    raise(Invalid_argument"init_list: n must be a natural")
  else
    let rec init_listrec n k = match n with
        n when n = 0 -> []
      |n when n = 1 -> [k]
      |n -> k::( init_listrec (n-1) k )
    in init_listrec n k;;

  (*-----------------------put_list--------------------------------*)
(*
put_list 'x' 3 ['-'; '-'; '-'; '-'; '-'; '-'] ;;
put_list 0 10 [1; 1; 1; 1] ;;
*)

let rec put_list v n = function
    [] -> []
  |e::l -> if n > 0 then 
        e::(put_list v (n-1) l)
      else 
        v::l


(*========================= 'a list list ================================*)

  (*-----------------------init_board--------------------------------*)
(*
init_board (5, 3) 0 
*)
let init_board (l, c) a = 

  let rec listeInterne c a = match c with

    |c when c < 0 -> raise(Invalid_argument"init_board must be positive")
    |c when c = 0 -> []
    |c -> a::(listeInterne (c-1) a)

  in 
  
  if l<0 then

    raise(Invalid_argument"init_board must be positive")

  else
    let li = listeInterne c a in 

    let rec init_board_rec (l, c) a = match l with

        (*l when l<0 -> raise(Invalid_argument"init_board must be positive")*) 

      |l when l >= 1 -> (li)::((init_board_rec((l-1), c) a))
      |_ -> []
                
    in init_board_rec (l,c) a;;
 (* -----------------------get_cell--------------------------------*)
(*

*)

    let get_cell (x, y) l = 
                if y < 0 || x < 0 then 
                    raise (Invalid_argument "Negative value")
                else
                    let rec get_cell_y y = function
                            [] -> raise (Invalid_argument "empty list y")
                        | e::r -> if y = 0 then e else get_cell_y (y-1) r
                    in
                    let rec get_cell_x x = function
                            [] -> raise (invalid_arg "empty list x")
                        | e::r -> if x = 0 then get_cell_y y e else get_cell_x (x-1) r
                    in get_cell_x x l;;


  (*-----------------------put_cell--------------------------------*)
(*
                                        
*)
    let put_cell a (x, y) l = 
                if y < 0 || x < 0 then 
                    raise (Invalid_argument "Negative value")

                else
                    let rec put_cell_y y = function
                            [] -> raise (Invalid_argument "empty list y")
                        | e::r -> if y = 0 then
                                    a::r 
                                  else 
                                    e::(put_cell_y (y-1) r)

                    in
                    let rec put_cell_x x = function
                            [] -> raise (Invalid_argument "empty list x")
                        | e::r -> if x = 0 then
                                   (put_cell_y y e)::r
                                  else
                                   e::( put_cell_x (x-1) r)
                    in put_cell_x x l;;
