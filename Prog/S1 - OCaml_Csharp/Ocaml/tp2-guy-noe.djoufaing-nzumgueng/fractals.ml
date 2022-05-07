(*------------------------------------------------------------MOUNTAIN-------------------------------------------------------------*)


#load "graphics.cma" ;;
open  Graphics  ;;
open_graph " 1200 x800" ;;
set_color black;
clear_graph  ();

		let rec mountain_rec (x,y) (z,t) n =
			if n = 0 then 
				begin
					moveto x y ;
					lineto z t ;
				end
				
			else 
				let h= (y+t)/2 + Random.int(10 * n) and m = (x + z)/2 in
				 begin 
				 mountain_rec (x, y) (m, h) (n-1);
				 mountain_rec (m, h) (z, t) (n-1);
				end
			in mountain_rec n (x,y) (z,t);;

mountain_rec (50 ,50) (500 ,50) 10;;


(*------------------------------------------------------------DRAGON-------------------------------------------------------------*)

#load "graphics.cma" ;;
open  Graphics  ;;
open_graph " 1200 x800" ;;
set_color black;;
clear_graph  ();;
	
let rec dragon_rec n (x,y) (z,t)= 
	if n = 0 then
		begin
			moveto x y ;
			lineto z t ;
		end

	else 
		let u= (x+z)/2 + (t-y)/2 and 
		v= (y+t)/2-(z-x)/2 in 
		begin 
			dragon_rec (n-1) (x, y) (u, v);
			dragon_rec (n-1) (z, t) (u, v);
		end;;

dragon_rec 19 (150 ,150) (350 ,350);;

(*------------------------------------------------------------SPONGE-------------------------------------------------------------*)
#load "graphics.cma" ;;
open  Graphics  ;;
open_graph " 2000 x 2000" ;;
clear_graph ();;



let sponge (x, y) n = 

	set_color black;
	moveto x y;
	fill_rect (x) (y) (n*3) (n*3);
	set_color white;
	
	let rec draw_sponge (x, y) n = 
		if n > 1 then

			begin
				let d = n/3 in

				fill_rect (x+n) (y+n) n n;

				draw_sponge (x,y) d;
				draw_sponge ((x+n), y) d;
				draw_sponge ((x+2*n), y) d;

				draw_sponge ((x),(y+n)) d;
				draw_sponge ((x+2*n),(y+n)) d;

				draw_sponge ((x),(y+2*n)) d;
				draw_sponge ((x+n),(y+2*n)) d;
				draw_sponge ((x+2*n),(y+2*n)) d;

			end

	in draw_sponge (x, y) n;;



sponge (10 ,10) 243 ;;

(*------------------------------------------------------------TRIANGLE-------------------------------------------------------------*)

#load "graphics.cma" ;;
open  Graphics  ;;
open_graph "" ;;
clear_graph ();;
set_color black;;

let triangles x y n t =

		let fx = x * t and fy = y and hx = x * (t + 1) / 2 and hy = t * 8 in


		let draw_triangle (x, y) (fx, fy) (hx, hy) =
			begin
				moveto x y;
					lineto fx fy;
					lineto hx hy;
					lineto x y;    
			end  
	in

		let moitie a b c d = 
				( ((c+a)/2), ((b+d)/2) ) in

		draw_triangle (x, y) (fx, fy) (hx, hy);

				let rec triangle_rec n (x, y) (fx, fy) (hx, hy) = 

				if n > 0 then
						begin 

								let (x2, y2) = moitie x y fx fy 
								and (fx2, fy2) = moitie x y hx hy 
								and (hx2, hy2) = moitie fx fy hx hy in

								draw_triangle (x2, y2) (fx2, fy2) (hx2, hy2);

								triangle_rec (n-1) (x, y) (x2, y2) (fx2, fy2);
								triangle_rec (n-1) (fx, fy) (x2, y2) (hx2, hy2);
								triangle_rec (n-1) (hx, hy) (fx2, fy2) (hx2, hy2);
						end
				in triangle_rec n (x, y) (fx, fy) (hx, hy);;
	 
		


triangles 10 10 7 75 ;;



(*------------------------------------------------------------CIRCLE-------------------------------------------------------------*)
#load "graphics.cma" ;;
open  Graphics  ;;
open_graph " 1200 x800" ;;
	set_color blue;;
	clear_graph ();;
	let circle (x, y) r =

	clear_graph ();
	moveto x y;
	set_color blue;

	let rec circle_rec (x, y) r = 

			if r > 0 then

					begin 


							let nr = r/2 in

							draw_circle x y r;

							circle_rec ((x + nr),y) nr; 
							circle_rec ((x - nr),y) nr; 
							
					end

	in circle_rec (x, y) r;;


circle (150, 150) 100;;