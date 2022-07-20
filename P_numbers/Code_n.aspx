<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Code_n.aspx.cs" Inherits="P_numbers.Code_n" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
        <asp:GridView ID="GV_country" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="number" HeaderText="Number" />
                <asp:BoundField DataField="country" HeaderText="Country" />
                <asp:BoundField DataField="code" HeaderText="Code" />
            </Columns>
        </asp:GridView>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Return" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Export" />
        </div>
    </form>
</body>
</html>
