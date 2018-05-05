<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ITextSharp.aspx.cs" Inherits="ITextSharp"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>  
        <br />
        <table class="auto-style1">
            <tr>
                <td>PDF文档的内容</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>           
                </td>
            </tr>
           
            <tr>
                <td>添加图片</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            
        </table>
    </div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="生成pdf文档" />
    </form>
</body>
</html>
