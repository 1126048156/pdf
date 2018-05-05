<%@ Page Language="C#" AutoEventWireup="true" CodeFile="itextsharptable.aspx.cs" Inherits="itextsharptable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 469px;
        }
        </style>
</head>
<body>
    <form id="form" runat="server">
        <table class="auto-style1">
            <tr>
                <td>姓名：</td>
                <td class="auto-style2"><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">性别：</td>
                <td class="auto-style2"><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>年龄：</td>
                <td class="auto-style2"><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">籍贯：</td>
                <td class="auto-style2"><asp:TextBox ID="TextBox5" runat="server" style="margin-top: 118px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>联系电话：</td>
                <td class="auto-style2"><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">联系地址：</td>
                <td class="auto-style2"><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="转为pdf文档" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="打开pdf文档" />
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
