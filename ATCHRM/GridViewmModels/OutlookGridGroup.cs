using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace OutlookStyleControls
{
    #region IOutlookGridGroup - declares the arrange/grouping interface here
    public interface IOutlookGridGroup : IComparable, ICloneable
    {
        string Text { get; set; }
        object Value { get; set; }
        bool Collapsed { get; set; }
        DataGridViewColumn Column { get; set; }
        int ItemCount { get; set; }
        int Height { get; set; }
    }
    #endregion define the arrange/grouping interface here

    #region OutlookgGridDefaultGroup - implementation of the default grouping style
    public class OutlookgGridDefaultGroup : IOutlookGridGroup
    {
        protected object val;
        protected string text;
        protected bool collapsed;
        protected DataGridViewColumn column;
        protected int itemCount;
        protected int height;

        public OutlookgGridDefaultGroup()
        {
            val = null;

            this.column = null;
            height = 34; // default height
        }

        #region IOutlookGridGroup Members

        public virtual string Text
        {
            get {
                if (column == null)
                    return string.Format("Unbound group: {0} ({1})", Value.ToString(), itemCount == 1 ? "1 item" : itemCount.ToString() + " items");
                else
                    return string.Format("{0}: {1} ({2})", column.HeaderText, Value.ToString(), itemCount == 1 ? "1 item" : itemCount.ToString() + " items"); 
                }
            set { text = value; }
        }

        public virtual object Value
        {
            get { return val; }
            set { val = value; }
        }

        public virtual bool Collapsed
        {
            get { return collapsed; }
            set { collapsed = value; }
        }

        public virtual DataGridViewColumn Column
        {
            get { return column; }
            set { column = value; }
        }

        public virtual int ItemCount
        {
            get { return itemCount; }
            set { itemCount = value; }
        }

        public virtual int Height
        {
            get { return height; }
            set { height = value; }
        }

        #endregion

        #region ICloneable Members

        public virtual object Clone()
        {
            OutlookgGridDefaultGroup gr = new OutlookgGridDefaultGroup();
            gr.column = this.column;
            gr.val = this.val;
            gr.collapsed = this.collapsed;
            gr.text = this.text;
            gr.height = this.height;
            return gr;
        }

        #endregion

        #region IComparable Members

        /// <summary>
        /// this is a basic string comparison operation. 
        /// all items are grouped and categorised based on their string-appearance.
        /// </summary>
        /// <param name="obj">the value in the related column of the item to compare to</param>
        /// <returns></returns>
        public virtual int CompareTo(object obj)
        {
            return string.Compare(val.ToString(), obj.ToString());
        }

        #endregion
    }
    #endregion OutlookgGridDefaultGroup - implementation of the default grouping style

    #region OutlookGridAlphabeticGroup - an alphabet group implementation
    public class OutlookGridAlphabeticGroup : OutlookgGridDefaultGroup
    {
        public OutlookGridAlphabeticGroup()
            : base()
        {
            
        }

        public override string Text
        {
            get
            {
                return string.Format("Alphabetic: {1} ({2})", column.HeaderText, Value.ToString(), itemCount == 1 ? "1 item" : itemCount.ToString() + " items");
            }
            set { text = value; }
        }

        public override object Value
        {
            get { return val; }
            set { val = value.ToString().Substring(0,1).ToUpper(); }
        }

        #region ICloneable Members
        
        public override object Clone()
        {
            OutlookGridAlphabeticGroup gr = new OutlookGridAlphabeticGroup();
            gr.column = this.column;
            gr.val = this.val;
            gr.collapsed = this.collapsed;
            gr.text = this.text;
            gr.height = this.height;
            return gr;
        }

        #endregion

        #region IComparable Members
        
        public override int CompareTo(object obj)
        {
            return string.Compare(val.ToString(), obj.ToString().Substring(0, 1).ToUpper());
        }

        #endregion IComparable Members

    }
    #endregion OutlookGridAlphabeticGroup - an alphabet group implementation
    
}
