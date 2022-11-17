using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giao_Dien_Dang_Nhap.Classes
{
    internal class CommonFunction
    {
        Connection connectData = new Connection();
        public void FillComboBox(ComboBox comboName, DataTable data, string displayMenber, string valueMember)
        {
            comboName.DataSource = data;
            comboName.DisplayMember = displayMenber;
            comboName.ValueMember = valueMember;
        }

        public string AutoCode(string tableName, string columnName, string startValue)
        {
            string code = "";
            bool check = false;
            int id = 0;
            code = startValue + id.ToString();
            do
            {
                DataTable dataTable = connectData.DataReader("select * from " + tableName +
                    " where " + columnName + " = " + code);
                if (dataTable.Rows.Count == 0)
                {
                    check = true;
                }
                else
                {
                    id++;
                }
            } while (check == false);

            return code;
        }
    }
}
