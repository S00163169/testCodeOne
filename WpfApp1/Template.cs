using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Template: IComparable
    {
        public string latitude { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public string longitude { get; set; }

        public int CompareTo(object obj)
        {
            int returnal;

            Template tempCustomer = (Template)obj;

            if (this.user_id > tempCustomer.user_id)
            {
                returnal = 1;
            }
            else if (this.user_id < tempCustomer.user_id)
            {
                returnal = -1;
            }
            else
                returnal = 0;

            return returnal;
        }

        public override string ToString()
        {
            return this.user_id + "    " + this.name;
        }
    }
}
