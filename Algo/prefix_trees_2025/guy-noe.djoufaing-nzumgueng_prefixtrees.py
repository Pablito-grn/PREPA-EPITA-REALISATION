__license__ = 'Nathalie (c) EPITA'
__docformat__ = 'reStructuredText'
__revision__ = '$Id: prefixtrees.py 2021-10-13'

"""
Prefix Trees homework
2021-10 - S3
@author: guy-noe.djoufaing-nzumgueng
"""

from algopy import ptree

###############################################################################
# Do not change anything above this line, except your login!
# Do not add any import

##############################################################################
## Measure


def __countwords(T, res):
    """ count words in the prefix tree T (ptree.Tree)
    return type: int
    with res an integer containing the result
    """
    res = 0
    (k, b) = T.key
    if b == True:
        res += 1
    for child in T.children:
        res += __countwords(child)
    return res
def countwords(T):
    """ count words in the prefix tree T (ptree.Tree)
    return type: int
    """
    if T == None:
        return 0
    else:
        return __countwords(T, 0)


def __longestwordlength(T):
    """subfunction longest word length in the prefix tree T (ptree.Tree)
    return type: int
    """
    res = 0
    for child in T.children:
        res = max(__longestwordlength(child) + 1, res)

    return res
def longestwordlength(T):
    """ longest word length in the prefix tree T (ptree.Tree)
    return type: int    
    """

    if T == None:
        return 0
    else:
        return __longestwordlength(T)


def __wordslenght(T, word=1):
    """subfunction calculates the total length of all words

    """
    average = 0
    for child in T.children:
        (k, b) = child.key
        average += __wordslenght(child, word + 1)
        if b:
            average += word
    return average
def averagelength(T):
    """ average word length in the prefix tree T (ptree.Tree)
    return type: float
    """
    if T == None:
        return 0
    else:
        average = __wordslenght(T)
        countword = countwords(T)

        if countword > 0:
            return average / countword

        return 0


###############################################################################
## search and list


def __wordlist(T, s="", l=[]):
    """subfunction generate the word list of the prefix tree T (ptree.Tree)
    return type: str list
    """

    (k, b) = T.key
    if b == True:
        l.append(s + k)

    for child in T.children:
        __wordlist(child, s + k, l)
    return l
def wordlist(T):
    """ generate the word list of the prefix tree T (ptree.Tree)
    return type: str list
    """
    if T == None:
        return 0

    return __wordlist(T, "", [])


def __searchword(T, w, l, i=0):
    """ subfunction search for the word w (str) in the prefix tree T (ptree.Tree)
    return type: bool
    """

    for child in T.children:
        (k, b) = child.key
        if i < l and k == w[i] and __searchword(child, w, l, i+1):
            return True
    return i == (l-1)
def searchword(T, w):
    """ search for the word w (str) in the prefix tree T (ptree.Tree)
    return type: bool
    """
    
    return __searchword(T, w, len(w), 0)


def __completion(T, prefix, i, l, tempW):
    (k, b) = T.key
    tempW += k
    if b:
        l.append(tempW)

    if i > len(prefix)-1 or k == prefix[i]:
        for child in T.children:
            __completion(child, prefix, i + 1, l, tempW)
def completion(T, prefix):
    """ generate the list of words in the prefix tree T (ptree.Tree) with a common prefix
    return type: str list
    """
    L = []
    for child in T.children:
        __completion(child, prefix, 0, L, "")
    return L


###############################################################################
## Build


def buildlexicon(T, filename):
    """ save the tree T (ptree.Tree) in the file filename (str)
    """
    L = wordlist(T)
    L.sort()
    file = open(filename, "w")
    for C in L:
        file.write(C + "\n")
    file.close()


def __searchindex(T, w, l):
    index = 0
    for child in T.children:
        if child.key[0] >= l:
            break
        else:
            index = index + 1
    return index
def __addword(T, w, l, i):
    if i < l + 1:
        boolean = True
        for child in T.children:
            if child.key[0] == w[i]:
                __addword(child, w, l, i + 1)
                return
        if boolean:
            for a in range(i, l):
                index = __searchindex(T, w, w[a])
                T.children.insert(index, ptree.Tree((w[a], False), []))
                T = T.children[index]

            index = __searchindex(T, w, w[l])
            T.children.insert(index, ptree.Tree((w[l], True), []))
    else:
        (letter, _) = T.key
        T.key = (letter, True)
def addword(T, w):
    """ add the word w (str) in the tree T (ptree.Tree)
    """
    l = len(w) - 1
    if l > -1:
        __addword(T, w, l, 0)


def buildtree(filename):
    """ build the prefix tree from the file of words filename (str)
    return type: ptree.Tree
    """
    L = []
    T = ptree.Tree(('', False), [])
    file = open(filename, "r")
    lines = file.readlines()
    for line in lines:
        L.append(line.strip())
    file.close()
    for C in L:
        addword(T, C)
    return T
