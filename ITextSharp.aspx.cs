using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public partial class ITextSharp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //创建pdf文档对象
        Document documents = new Document();
        //实例化生成文档
        PdfWriter.GetInstance(documents,new FileStream(Server.MapPath(".")+@"\test2.pdf",FileMode.Create));
      
        documents.Open();
        
       //设置字体
        BaseFont bfHei = BaseFont.CreateFont("c://windows//fonts//msyh.ttc,0", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        Font font = new Font(bfHei, 32);
        documents.Add(new Paragraph(TextBox1.Text,font));//添加内容

        //添加图片
        string filename = Path.GetFileName(FileUpload1.FileName);//获得文件名和后缀          
        FileUpload1.SaveAs(Server.MapPath("~/") + filename);//保存文件到本程序的文件夹下 
        iTextSharp.text.Image jpge = iTextSharp.text.Image.GetInstance(Server.MapPath("~/") + filename);
        documents.Add(jpge);

        documents.Close();
        Response.Write("pdf文档成功保存");
    }

    

    
}