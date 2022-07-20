<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Import.aspx.cs" Inherits="P_numbers.Import" %>

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
            <asp:FileUpload ID="F_upload" runat="server" />
            <br />
            <br />
            <asp:Button ID="Bt_upload" runat="server" OnClick="Bt_upload_Click" Text="Upload" />
            <br />
            <br />
            <asp:Button ID="Bt_gencountry" runat="server" OnClick="Bt_gencountry_Click" Text="Numbers by country" />
            &nbsp&nbsp&nbsp
            <asp:Button ID="Bt_gennumber" runat="server" OnClick="Bt_gennumber_Click" Text="Numbers with codes" />
        </div>
    </form>
</body>
</html>
