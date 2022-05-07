let rec build_line n str = 
  if n < 1 then invalid_arg "n est inferieur a 1"
  else
    match n with
      (1) -> str
    |(n) -> str^build_line(n-1) str;;


(----------------------------------------------------------------------------------------------------------)

let square n str =
  let y = build_line n str in
  let rec square_rec n=
    if n > 0 then
      begin
        print_endline y ;
        square_rec (n-1)
      end
  in square_rec n;;

(----------------------------------------------------------------------------------------------------------)


let square2 n (str1, str2) =
  let y = build_line n (str1^str2) in 
  let z = build_line n (str2^str1) in 
  
  if n mod 2 != 0 then 
    let rec square_rec2 n=
      if n > 0 then
        begin
          if n mod 2  = 0 then print_endline z 
          else 
            print_endline y;
          square_rec2 (n-1)
        end
    in square_rec2 n

  else

    let rec square_rec2bis n=
      if n > 0 then
        begin
          if n mod 2  = 0 then print_endline y 
          else 
            print_endline z;
          square_rec2bis (n-1)
        end
    in square_rec2bis n;;

  square2 5 ("*", ".") ;;
  square2 6 ("&", " ") ;;

  (----------------------------------------------------------------------------------------------------------)


let rec triangle n str=
  if n > 0 then
    begin
      triangle(n-1) str; 
      print_endline (build_line n str) ;
    end 

(----------------------------------------------------------------------------------------------------------)

let pyramid n (str1, str2) = let a = n in 
  let rec pyramid_rec n =   
    if n > 1 then 
      begin
        print_endline( (build_line (n-1) str1)^(build_line (a*2 - (2* n-1) + 1) str2)^(build_line (n-1) str1) ); 
        pyramid_rec (n-1)
      end 
    else
      print_endline (build_line (a*2) str2) ;
  in pyramid_rec n;;
