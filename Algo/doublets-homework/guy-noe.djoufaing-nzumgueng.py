# -*- coding: utf-8 -*-
__license__ = 'Junior (c) EPITA'
__docformat__ = 'reStructuredText'
__revision__ = '$Id: doublets.py 2021-11-17'

"""
Doublet homework
2021-11
@author: guy-noe.djoufaing-nzumgueng
"""


from algopy import graph, queue
###############################################################################
# Do not change anything above this line, except your login!
# Do not add any import


#   LEVEL 0
def __add_edges(G, src, str, k):
    for dir in G.labels:
        i = 0
        while i < k and dir[i] == str[i]:
            i+=1

        if i != k:
            i+=1

            while i < k and dir[i] == str[i]:
                i += 1

            if i == k:
                graph.Graph.addedge(G, src, G.labels.index(dir))


def buildgraph(filename, k):
    """
    Build and return a graph with words of length k from the lexicon in filename
    """
    file = open(filename)
    lines = file.readlines()
    lenfile = len(lines)

    G = graph.Graph(0, 0, [])

    vert = 0
    for i in range(lenfile):
        if len(lines[i]) == k+1:
            str = lines[i].strip()
            graph.Graph.addvertex(G)
            __add_edges(G, vert, str, k)
            vert += 1
            G.labels += [str]

    file.close()

    return G



###############################################################################
#   LEVEL 1

def mostconnected(G):
    """ Return the list of words that are directly linked to the most other words in G

    """
    maxAdj, listofword = 0, []

    for noeud in range(len(G.adjlists)):
        lenght = len(G.adjlists[noeud])

        if maxAdj < lenght:
            maxAdj = lenght
            listofword = [G.labels[noeud]]
        elif maxAdj == lenght:
            listofword.append(G.labels[noeud])

    return listofword


def ischain(G, L):
    """ Test if L (word list) is a valid elementary *chain* in the graph G
    """
    if len(L) == 0:
        return True
    old = G.labels.index(L[0])

    for i in range(1, len(L)):
        if L[i] not in G.labels:
            return False
        new = G.labels.index(L[i])

        if new in G.adjlists[old]:
            old = new
        else:
            return False
    return G.labels[old] == L[len(L) - 1]

###############################################################################
#   LEVEL 2

def alldoublets(G, start):
    """ Return the list of all words that can form a *doublet* with the word start in the lexicon in G

    """
    l , p = [], [0] * G.order
    id , p[id] = G.labels.index(start), 1

    q = queue.Queue()
    for adj in G.adjlists[id]:
        q.enqueue(adj)

    while not q.isempty():
        id = q.dequeue()

        if p[id] != 1:
            p[id] = 1
            l.append(G.labels[id])

            for adj in G.adjlists[id]:
                q.enqueue(adj)

    return l


# ========================================  STOP  ===============================

def __bfs_ladder(G, start, end, p):
    """Do a breadth-first search until finding the nodes end

    """
    index = G.labels.index(start)
    p[index] = -1
    q = queue.Queue()
    q.enqueue(start)

    while not q.isempty():
        current = q.dequeue()
        for adj in G.adjlists[G.labels.index(current)]:
            if p[adj] is None:
                p[adj] = current
                word = G.labels[adj]
                if word != end:
                    q.enqueue(word)
                else:
                    return True
    return False


def ladder(G, start, end):
    """ Return a *ladder* to the *doublet* (start, end) in G

    """
    l, p = [], [None] * G.order

    if __bfs_ladder(G, start, end, p):
        c = end
        while c != -1:
            l.insert(0, c)
            c = p[G.labels.index(c)]
    return l


###############################################################################
#   LEVEL 3

def nosolution(G):
    """ Return a *doublet* without solution in G, (None, None) if none

    """
    p = [None] * G.order
    q = queue.Queue()
    q.enqueue(0)
    while not q.isempty():
        c = q.dequeue()
        for adj in G.adjlists[c]:
            if p[adj] is None:
                p[adj] = 1
                q.enqueue(adj)
    i = 1
    while i < G.order and p[i] == 1:
        i += 1

    if i == G.order:
        return None, None
    return G.labels[0], G.labels[i]


def longestdoublet(G):
    """ Find in G one of the most difficult *doublets* (that has the longest *ladder*)

    """
    max = 0

    for lab in G.labels:
        i = G.labels.index(lab)
        dst = [-1] * G.order
        dst[i] = 0

        q = queue.Queue()
        q.enqueue(i)

        while not q.isempty():
            c = q.dequeue()
            for adj in G.adjlists[c]:
                if dst[adj] == -1:
                    q.enqueue(adj)
                    dst[adj] = dst[c] + 1

        if dst[c] > max:
            max = dst[c]
            l = [G.labels[i], G.labels[c]]

    return l[0], l[1], max + 1


###############################################################################
#   BONUS (just for the fun...)

def isomorphic(G1, G2):
    """BONUS: test if G1 and G2 (graphs of same length words) are isomorphic

    """
    # FIXME
    pass



G3 = buildgraph("lexicons/lex_some.txt", 3)
G4 = buildgraph("lexicons/lex_some.txt", 4)

print(mostconnected(G4))
print(mostconnected(G3))

print(ischain(G3, ['ape', 'apt', 'opt', 'oat', 'mat', 'man']))
print(ischain(G3, ['man', 'mat', 'sat', 'sit', 'pit', 'pig']))
print(ischain(G3, ['ape', 'apt', 'opt', 'oat', 'mat', 'oat', 'mat', 'man']))

print(alldoublets(G3, "pen"))

print(ladder(G3, "ape", "man"))
print(ladder(G3, "man", "pig"))
print(ladder(G4, "work", "food"))

print(nosolution(G3))
print(nosolution(G4))

print(longestdoublet(G3))
print(longestdoublet(G4))