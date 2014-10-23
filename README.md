Rectangle Overlap
=================

This is an interview question that I didn't get to really develop during the interview itself, and it felt interesting to actually see it working.

The problem is about calculating rectangle overlaps. Take a set of rectangles and, from all subsets where all the rectangles overlap, give the maximum size.
You can visualize it as if the rectangles are pieces of fabric and you're "heaping them up", what would be the height of the heap?

The problem can be approached with a depth-first-traversal, keeping running counts of the heights

In the interview I was told that calculating the individual overlaps wasn't the focus of the question and that I could assume the availability of appropriate methods, taking advantage of methods like Rect.Intersect() is not "cheating"