<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreatePdfWeb.aspx.cs" Inherits="CreatePdfWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        PDF文档的内容<br />
        <asp:TextBox ID="TextBox1" runat="server" Height="222px" TextMode="MultiLine" Width="373px"></asp:TextBox>
    
    </div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="保存" />
    </form>
</body>
</html>
