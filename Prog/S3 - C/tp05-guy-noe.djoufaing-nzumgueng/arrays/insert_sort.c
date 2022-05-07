#include <stdio.h>
#include <stdlib.h>
#include "insert_sort.h"
#include "helper.h"


void array_insert(int *begin, int *end, int element){

 while (end >= begin && element < *(end-1)){
*(end) = *(end-1);
end--;
}

 *end = element;
}

void array_insert_sort(int *begin, int *end){
for (int *first = begin+1; begin < end; begin++)
array_insert(first, begin, *begin);
}


/*
recherche_dichotomique_récursive(élément, liste_triée):
   len = longueur de liste_triée ;
   m = len / 2 ;
   si liste_triée[m] = élément :
       renvoyer m ;
   si liste_triée[m] > élément :
       renvoyer recherche_dichotomique_récursive(élément, liste_triée[1:m-1]) ;
   sinon :
       renvoyer m+recherche_dichotomique_récursive(élément, liste_triée[m+1:len]) ;
*/
int* RecursiveBinarySearch(int *begin, int *end, int x) {
    if (begin > end)
        return begin;

    int *mid = begin + (end - begin) / 2;
    if (x == *mid)
        return mid;
    else if (x >= *mid)
		return RecursiveBinarySearch(mid + 1, end, x);
	return RecursiveBinarySearch(begin, mid - 1, x);

}
void array_insert_bin(int *begin, int *end, int x){
    int *i = RecursiveBinarySearch(begin, end, x);
    while(end > i){
        *end = *(end - 1);
        end--; 
    }
    *i = x;
}

// Insertion sort using binary search.
void array_insert_sort_bin(int *begin, int *end){
	for (int *i = begin; i < end; i++)
		array_insert_bin(begin, i, *i);
}







