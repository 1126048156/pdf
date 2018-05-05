using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Collections;

public partial class CreatePdfWeb : System.Web.UI.Page
{
    static float pageWidth = 594.0f;
    static float pageDepth = 828.0f;
    static float pageMargin = 30.0f;
    static float fontsize = 10.0f;
    static float leadSize = 10.0f;
    

    static MemoryStream mPDF = new MemoryStream();
    static void ConvertToByteAndAddtoStream(string strMsg)
    {
        Byte[] buffer = null;
        buffer = ASCIIEncoding.ASCII.GetBytes(strMsg);
        mPDF.Write(buffer, 0, buffer.Length);//向pdf文件中写入数据信息
        buffer = null;
    }
    //格式化数据
    static string xRefFormatting(long xValue)
    {
        string strMsg = xValue.ToString();//初始化变量
        int iLen = strMsg.Length;
        if (iLen < 0)
        {
            StringBuilder s = new StringBuilder();
            int i = 10 - iLen;
            s.Append('0', i);
            strMsg = s.ToString() + strMsg;
        }
        return strMsg;//返回变量值
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   

    protected void Button1_Click(object sender, EventArgs e)
    {
        //创建一个数组
        ArrayList xRefs = new ArrayList();
        float yPos = 0f;
        long streamStart = 0;
        long streamEnd = 0;
        long streamLen = 0;
        string strPDFMessage = null;
        //PDF头信息
        strPDFMessage = "%PDF-1.1\n";
        ConvertToByteAndAddtoStream(strPDFMessage);
        //创建一个信息的PDF页
        xRefs.Add(mPDF.Length);
        strPDFMessage = "1 0 obj\n";
        ConvertToByteAndAddtoStream(strPDFMessage);
        strPDFMessage = "<< /Length 2 0 R >>\n";
        ConvertToByteAndAddtoStream(strPDFMessage);
        strPDFMessage = "stream\n";
        ConvertToByteAndAddtoStream(strPDFMessage);

        //开始获得数据流
        streamStart = mPDF.Length;
        strPDFMessage = "BT\n/F0 " + fontsize + " Tf\n";
        ConvertToByteAndAddtoStream(strPDFMessage);
        yPos = pageDepth - pageMargin;
        strPDFMessage = pageMargin + " " + yPos + " Td\n";
        ConvertToByteAndAddtoStream(strPDFMessage);
        strPDFMessage = leadSize + " TL\n";
        ConvertToByteAndAddtoStream(strPDFMessage);

        //向pdf文档中加入数据信息
        strPDFMessage = "("+TextBox1.Text+")Tj\n";
        ConvertToByteAndAddtoStream(strPDFMessage);
        strPDFMessage = "ET\n";
        ConvertToByteAndAddtoStream(strPDFMessage);
        //结束数据流
        streamEnd = mPDF.Length;
        //获取数据流长度
        streamLen = streamEnd - streamStart;
        strPDFMessage = "endstream\nendobj\n";
        ConvertToByteAndAddtoStream(strPDFMessage);

        
        xRefs.Add(mPDF.Length);
        strPDFMessage = "2 0 obj\n" + streamLen + "\nendobj\n";
        ConvertToByteAndAddtoStream(strPDFMessage);

        //再次增加一个PDF页
        xRefs.Add(mPDF.Length);
        strPDFMessage = "3 0 obj\n<</Type/Page/Parent 4 0 R/Contents 1 0 R>>\nendobj\n";
        ConvertToByteAndAddtoStream(strPDFMessage);

        
        xRefs.Add(mPDF.Length);
        strPDFMessage = "4 0 obj\n<</Type /Pages /Count 1\n";
        ConvertToByteAndAddtoStream(strPDFMessage);
        strPDFMessage = "/Kids[\n3 0 R\n]\n";
        ConvertToByteAndAddtoStream(strPDFMessage);
        strPDFMessage = "/Resources<</ProcSet[/PDF/Text]/Font<</F0 5 0 R>> >>\n";
        ConvertToByteAndAddtoStream(strPDFMessage);
        strPDFMessage = "/MediaBox [ 0 0 " + pageWidth + " " + pageDepth + " ]\n>>\nendobj\n";
        ConvertToByteAndAddtoStream(strPDFMessage);

        //添加字体
        xRefs.Add(mPDF.Length);
        strPDFMessage = "5 0 obj\n<</Type/Font/Subtype/Type1/BaseFont/Courier/Encoding/WinAnsiEncoding>>\nendobj\n";
        ConvertToByteAndAddtoStream(strPDFMessage);

        //添加目录
        xRefs.Add(mPDF.Length);
        strPDFMessage = "6 0 obj\n<</Type/Catalog/Pages 4 0 R>>\nendobj\n";
        ConvertToByteAndAddtoStream(strPDFMessage);

        //xRefs Entry 
        streamStart = mPDF.Length;
        strPDFMessage = "xref\n0 7\n0000000000 65535 f \n";
        for (int i = 0; i < xRefs.Count; i++)
        {
            strPDFMessage += xRefFormatting((long)xRefs[i]) + " 00000 n \n";
        }
        ConvertToByteAndAddtoStream(strPDFMessage);
        
        strPDFMessage = "trailer\n<<\n/Size " + (xRefs.Count + 1) + "\n/Root 6 0 R\n>>\n";
        ConvertToByteAndAddtoStream(strPDFMessage);
        
        strPDFMessage = "startxref\n" + streamStart + "\n%%EOF\n";
        ConvertToByteAndAddtoStream(strPDFMessage);
        string s = Server.MapPath(".") + @"\test.pdf";
        //指定要生成pdf文件的路径
        StreamWriter pPDF = new StreamWriter(s);
        //存储pdf文档
        mPDF.WriteTo(pPDF.BaseStream);
        //Close the Stream
        mPDF.Close();
        pPDF.Close();
        Response.Write("成功");
    }
}