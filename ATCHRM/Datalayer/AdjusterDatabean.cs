using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATCHRM.Datalayer
{
  public class AdjusterDatabean
    {

        int adjusterid = 0;

        public int Adjusterid
        {
            get { return adjusterid; }
            set { adjusterid = value; }
        }
      string adjustercode;

      public string Adjustercode
      {
          get { return adjustercode; }
          set { adjustercode = value; }
      }
      int userpk;

      public int Userpk
      {
          get { return userpk; }
          set { userpk = value; }
      }
      DateTime fromdate;

      public DateTime Fromdate
      {
          get { return fromdate; }
          set { fromdate = value; }
      }
      DateTime todate;

      public DateTime Todate
      {
          get { return todate; }
          set { todate = value; }
      }
      DateTime doneon;

      public DateTime Doneon
      {
          get { return doneon; }
          set { doneon = value; }
      }
      int branchlctnPk;

      public int BranchlctnPk
      {
          get { return branchlctnPk; }
          set { branchlctnPk = value; }
      }

      int id;

      public int Aid
      {
          get { return id; }
          set { id = value; }
      }
    }
}
