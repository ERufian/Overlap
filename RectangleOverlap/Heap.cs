//-----------------------------------------------------------------------
// <copyright file="Heap.cs" company="Eusebio Rufian-Zilbermann">
//   Copyright (c) Eusebio Rufian-Zilbermann
// </copyright>
//-----------------------------------------------------------------------
namespace RectangleOperations
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;
   using System.Threading.Tasks;
   using System.Windows;

   /// <summary>
   /// Operations on a set of rectangles that can be heaped up
   /// </summary>
   public class Heap
   {
      /// <summary>
      /// The list of rectangles
      /// </summary>
      private readonly List<Rect> rects;

      /// <summary>
      /// Initializes a new instance of the <see cref="Heap"/> class
      /// </summary>
      /// <param name="rectangleList">The set of rectangles to heap up</param>
      public Heap(IEnumerable<Rect> rectangleList)
      {
         this.rects = new List<Rect>(rectangleList);
      }

      /// <summary>
      /// Gets the height of the heap, the largest set of rectangles that overlap
      /// </summary>
      public int Height
      {
         get
         {
            Rect initialRect = this.rects.Aggregate((r1, r2) => { r1.Union(r2); return r1; });
            return this.HeapHeight(initialRect, 0, 0);
         }
      }

      /// <summary>
      /// Calculates the height of the heap in a given boundary.
      /// </summary>
      /// <param name="currentArea">The boundaries of the largest heap in [0, current rectangle).</param>
      /// <param name="currentIndex">The index of the current rectangle.</param>
      /// <param name="currentCount">The height of the largest heap in [0, current rectangle).</param>
      /// <returns>The height of the largest heap within the given boundary.</returns>
      private int HeapHeight(Rect currentArea, int currentIndex, int currentCount)
      {
         List<int> counts = new List<int>();
         for (int i = currentIndex; this.rects.Count > i; i++)
         {
            Rect newArea = currentArea;
            newArea.Intersect(this.rects[i]);
            if (0 < newArea.Size.Height && 0 < newArea.Size.Width)
            {
               counts.Add(this.HeapHeight(newArea, i + 1, currentCount + 1));
            }
         }

         return (0 == counts.Count) ? currentCount : counts.Max();
      }
   }
}