<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ServiciiREST.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table {
          font-family: arial, sans-serif;
          border-collapse: collapse;
          width: 100%;
        }

        td, th {
          border: 1px solid #dddddd;
          text-align: left;
          padding: 8px;
        }

        tr:nth-child(even) {
          background-color: #dddddd;
        }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table id="raportTable" runat="server" CellPadding="10" HorizontalAlign="Center">
                <asp:TableRow>
                    <asp:TableHeaderCell Text="Spital" Width="600"/>
                    <asp:TableHeaderCell Text="Suma de decontat" />
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
