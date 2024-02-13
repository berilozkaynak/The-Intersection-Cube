using System;
using System.Collections;
using System.Collections.Generic;

using Rhino;
using Rhino.Geometry;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;




  private void RunScript(List<Curve> curves, ref object A)
  {



    List<Curve> sortedCurves = new List<Curve>();


    if(curves != null && curves.Count >= 250)
    {

      sortedCurves.AddRange(curves.GetRange(0, 250));
      sortedCurves.Sort((a, b) => a.GetLength().CompareTo(b.GetLength()));
    }


    A = sortedCurves;



  }

  // <Custom additional code> 

  // </Custom additional code> 
}
