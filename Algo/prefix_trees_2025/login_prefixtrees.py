__license__ = 'Nathalie (c) EPITA'
__docformat__ = 'reStructuredText'
__revision__ = '$Id: prefixtrees.py 2021-10-13'

"""
Prefix Trees homework
2021-10 - S3
@author: login
"""

from algopy import ptree

###############################################################################
# Do not change anything above this line, except your login!
# Do not add any import

##############################################################################
## Measure

def countwords(T):
    """ count words in the prefix tree T (ptree.Tree)
    return type: int
    """
    
    #FIXME
    pass
    

def longestwordlength(T):
    """ longest word length in the prefix tree T (ptree.Tree)
    return type: int    
    """
    
    #FIXME
    pass


def averagelength(T):
    """ average word length in the prefix tree T (ptree.Tree)
    return type: float
    """
    
    #FIXME
    pass
    
###############################################################################
## search and list

def wordlist(T):
    """ generate the word list of the prefix tree T (ptree.Tree)
    return type: str list
    """
    
    #FIXME
    pass


def searchword(T, w):
    """ search for the word w (str) in the prefix tree T (ptree.Tree)
    return type: bool
    """
    
    #FIXME
    pass
    
    
def completion(T, prefix):
    """ generate the list of words in the prefix tree T (ptree.Tree) with a common prefix 
    return type: str list    
    """
    
    #FIXME
    pass


###############################################################################
## Build

def buildlexicon(T, filename):
    """ save the tree T (ptree.Tree) in the file filename (str)
    """
    
    #FIXME
    pass


def addword(T, w):
    """ add the word w (str) in the tree T (ptree.Tree)
    """
    
    #FIXME
    pass


def buildtree(filename):
    """ build the prefix tree from the file of words filename (str)
    return type: ptree.Tree
    """
    
    #FIXME
    pass   
