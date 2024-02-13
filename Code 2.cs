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


  private void RunScript(List<Brep> breps, ref object A)
  {


    List<Brep> sortedBreps = new List<Brep>();

    if(breps != null && breps.Count >= 150)
    {

      sortedBreps.AddRange(breps.GetRange(0, 150));


    }

    A = sortedBreps;
  }

  // <Custom additional code> 

  // </Custom additional code> 
}
