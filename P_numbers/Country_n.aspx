<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Country_n.aspx.cs" Inherits="P_numbers.Country_n" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

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
        <asp:GridView ID="GV_country" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="country" HeaderText="Country" />
                <asp:BoundField DataField="count" HeaderText="Phone numbers" />
            </Columns>
        </asp:GridView>
        <div class="auto-style1">
            <asp:Button ID="Bt_return" runat="server" Text="Return" OnClick="Bt_return_Click" />
            <br />
            <br />
            <asp:Chart ID="Chart1" runat="server" BorderlineColor="Black" BorderlineDashStyle="DashDotDot" Height="264px" Palette="EarthTones" Width="475px">
                <series>
                    <asp:Series LabelAngle="90" Name="Series1" XValueType="String" YValueType="Int32">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False" LabelAutoFitMinFontSize="5" LabelAutoFitStyle="IncreaseFont, DecreaseFont, StaggeredLabels, LabelsAngleStep30, LabelsAngleStep45, LabelsAngleStep90, WordWrap" MaximumAutoSize="85" TextOrientation="Stacked">
                            <LabelStyle Angle="90" Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
                        </AxisX>
                    </asp:ChartArea>
                </chartareas>
                <BorderSkin SkinStyle="Raised" />
            </asp:Chart>
        </div>
    </form>
</body>
</html>
