//-----------------------------------------------------------------------
// <copyright file="RectangleHeapTests.cs" company="Eusebio Rufian-Zilbermann">
//   Copyright (c) Eusebio Rufian-Zilbermann
// </copyright>
//-----------------------------------------------------------------------
namespace RectangleOverlapTests
{
   using System;
   using System.Collections.Generic;
   using System.Windows;
   using Microsoft.VisualStudio.TestTools.UnitTesting;
   using RectangleOperations;

   /// <summary>
   /// Tests for the rectangle operations heap class
   /// </summary>
   [TestClass]
   public class RectangleHeapTests
   {
      /// <summary>
      /// Test with disjoint rectangles (no points in common, largest heap = 1)
      /// </summary>
      [TestMethod]
      public void Disjoint()
      {
         List<Rect> rects = new List<Rect>
         {
            new Rect(new Point(0.0, 0.0), new Point(3.0, 1.0)),
            new Rect(new Point(1.0, 2.0), new Point(2.0, 3.0))
         };

         Heap ov = new Heap(rects);
         Assert.AreEqual(1, ov.Height);
      }

      /// <summary>
      /// Test with adjacent rectangles (only an edge in common, largest heap = 1)
      /// </summary>
      [TestMethod]
      public void Adjacent()
      {
         List<Rect> rects = new List<Rect>
         {
            new Rect(new Point(0.0, 0.0), new Point(3.0, 1.0)),
            new Rect(new Point(1.0, 1.0), new Point(2.0, 2.0))
         };

         Heap ov = new Heap(rects);
         Assert.AreEqual(1, ov.Height);
      }

      /// <summary>
      /// Test with adjacent rectangles plus another one that overlaps both
      /// </summary>
      [TestMethod]
      public void TwoAdjacentOneSuperimposed()
      {
         List<Rect> rects = new List<Rect>
         {
            new Rect(new Point(0.0, 0.0), new Point(3.0, 1.0)),
            new Rect(new Point(1.0, 1.0), new Point(2.0, 2.0)),
            new Rect(new Point(1.0, 0.0), new Point(2.0, 2.0))
         };

         Heap ov = new Heap(rects);
         Assert.AreEqual(2, ov.Height);
      }

      /// <summary>
      /// Test with three rectangles where each one contains all the smaller ones
      /// </summary>
      [TestMethod]
      public void ThreeContained()
      {
         List<Rect> rects = new List<Rect>
         {
            new Rect(new Point(0.0, 0.0), new Point(5.0, 5.0)),
            new Rect(new Point(1.0, 1.0), new Point(4.0, 4.0)),
            new Rect(new Point(2.0, 2.0), new Point(3.0, 3.0))
         };

         Heap ov = new Heap(rects);
         Assert.AreEqual(3, ov.Height);
      }

      /// <summary>
      /// Test with four rectangles, 
      /// for three of them each one contains all the smaller ones
      /// the fourth rectangle doesn't have any points in common with the other three
      /// </summary>
      [TestMethod]
      public void ThreeContainedPlusOneDisjoint()
      {
         List<Rect> rects = new List<Rect>
         {
            new Rect(new Point(0.0, 0.0), new Point(5.0, 5.0)),
            new Rect(new Point(1.0, 1.0), new Point(4.0, 4.0)),
            new Rect(new Point(2.0, 2.0), new Point(3.0, 3.0)),
            new Rect(new Point(6.0, 6.0), new Point(7.0, 7.0))
         };

         Heap ov = new Heap(rects);
         Assert.AreEqual(3, ov.Height);
      }
   }
}
