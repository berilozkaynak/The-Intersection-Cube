using System;
using System.Collections;
using System.Collections.Generic;

using Rhino;
using Rhino.Geometry;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

using Rhino.Geometry.Intersect;


  private void RunScript(List<Brep> breps, ref object A, ref object B)
  {


    List<Brep> sortedBreps = new List<Brep>();
    List<Brep> remainingBreps = new List<Brep>();

    if(breps != null && breps.Count > 0)
    {
      int count = Math.Min(150, breps.Count);
      sortedBreps.AddRange(breps.GetRange(0, count));

      if (breps.Count > 150)
      {

        remainingBreps.AddRange(breps.GetRange(150, breps.Count - 150));
      }
    }

    A = sortedBreps;
    B = remainingBreps;
  }

  // <Custom additional code> 

  // </Custom additional code> 
}
