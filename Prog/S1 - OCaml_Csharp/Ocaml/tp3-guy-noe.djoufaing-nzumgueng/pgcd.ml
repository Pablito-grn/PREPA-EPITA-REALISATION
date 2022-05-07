#use "list_tools.ml";;

let decompose n =
let d = 2 in 
  if n <= 1 then 

    raise(Invalid_argument " decompose : parameter <= 1")

  else 

    let rec diviseur d n  = match (n, d) with
        (n, d) when  n < 2 -> []

      |(n, d) when n mod d = 0 -> d::(diviseur d (n / d) )

      |_ ->  diviseur (d+1) n 

    in diviseur d n;;





let rec shared l1 l2 = match (l1, l2) with


    ([], _)|(_, []) -> []

  |(e1::r1, e2::r2) -> if e1 = e2 then 

                         e1::(shared r1 r2)

                       else

                         if e1 < e2 then 

                           shared (r1) (e2::r2)

                         else

                           shared (e1::r1) (r2)
;;





let gcd l1 l2 = 

  if l1 <2  || l2 < 2 then 
    raise (Invalid_argument "gcd : parameters < 2 ")

  else

    let ll1 = decompose l1 in
    let ll2 = decompose l2 in

    let shared_lists = shared ll1 ll2 in

    let i = length shared_lists in



    let pgcd i  = search_pos i shared_lists in pgcd i ;;
