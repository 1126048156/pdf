using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data;

public partial class itextsharptable : System.Web.UI.Page
{
    static DataTable mytable = new DataTable("temppdf");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //设计表结构
            DataColumn col1 = new DataColumn("Names", typeof(System.String));
            DataColumn col2 = new DataColumn("Sex", typeof(System.String));
            DataColumn col3 = new DataColumn("Age", typeof(System.Int32));
            DataColumn col4 = new DataColumn("JG", typeof(System.String));
            DataColumn col5 = new DataColumn("Phone", typeof(System.String));
            DataColumn col6 = new DataColumn("Address", typeof(System.String));
            //将创建的列添加到数据表当 中
            mytable.Columns.Add(col1);
            mytable.Columns.Add(col2);
            mytable.Columns.Add(col3);
            mytable.Columns.Add(col4);
            mytable.Columns.Add(col5);
            mytable.Columns.Add(col6);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       //创建表的一行数据
        DataRow myrow = mytable.NewRow();
        //添加行数据xinx
        myrow["Names"] = TextBox2.Text;
        myrow["Sex"] = TextBox3.Text;
        myrow["Age"] = TextBox4.Text;
        myrow["JG"] = TextBox5.Text;
        myrow["Phone"] = TextBox6.Text;
        myrow["Address"] = TextBox7.Text;
        mytable.Rows.Add(myrow);
        String path = Server.MapPath(".") + @"\test3.pdf";
        ConvertToPdf(mytable,path);
        
    }
    public static bool ConvertToPdf(DataTable datatable,String s){
         //初始化一个文档类
        Document document = new Document();
        //调用PDF的写法写入方法流
        PdfWriter write = PdfWriter.GetInstance(document, new FileStream(s, FileMode.Create));

        //加密创建的pdf文档
        write.SetEncryption(PdfWriter.STRENGTH128BITS,"ljm","ownerpass",PdfWriter.ALLOW_COPY|PdfWriter.ALLOW_PRINTING);//密码ljm

        document.Open();
        //创建字体
        BaseFont bfHei = BaseFont.CreateFont("c://windows//fonts//msyh.ttc,0", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        Font font = new Font(bfHei, 32);
       
        //创建表的一行数据
       
        //创建一个pdf格式的表格
        PdfPTable table = new PdfPTable(datatable.Columns.Count);
        //遍历表中的内容
        for (int i = 0; i < datatable.Rows.Count; i++)
        {
            for (int j = 0; j < datatable.Columns.Count; j++)
            {
                table.AddCell(new Phrase(datatable.Rows[i][j].ToString(), font));
            }
        }
        //添加转化后的表格数据
        document.Add(table);
        document.Close();
        write.Close();
        return true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //设计浏览器的输出格式
        Response.ContentType = "Application/pdf";
        //获得打开pdf文件的路径
        String filepaths = Server.MapPath(".")+@"\test3.pdf";
        //在浏览器中打开pdf文件
        Response.WriteFile(filepaths);
        Response.End();
    }
}