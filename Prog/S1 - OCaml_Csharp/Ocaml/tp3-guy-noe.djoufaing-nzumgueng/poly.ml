
#use "list_tools.ml";;


let add_poly l1 l2 = 

let i = if length l1 > length l2 then 
          length l1
        else 
          length l2 in 


let rec add_poly_rec  l1 l2 = function
    0 -> [(assoc 0 l1) + (assoc 0 l2), 0]
  |i -> ((assoc i l1) + (assoc i l2), i)::(add_poly_rec l1 l2 (i-1))
 in add_poly_rec l1 l2 (i+1);;



let rec times l (a, b) = match l with
[]->[]
|((e, c)::r) -> (a*e, c+b)::(times r (a, b));;



let rec product_poly (l1, l2)= match (l1, l2) with
[],_ |_,[] -> []
|((e, c)::r), ((e2, c2)::r2) -> 
  times ((e, c)::r) (e2, c2)::(product_poly ((e, c)::r, r2));;





