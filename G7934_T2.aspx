<%@ Page Language="C#" AutoEventWireup="true" CodeFile="G7934_T2.aspx.cs" Inherits="G7934_T2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="found" runat="server">
        <asp:Button ID="btnAll" runat="server" Text="Kaikki" OnClick="btnAll_Click" />
        <asp:Button ID="btnVakkarit" runat="server" Text="Vakituiset" OnClick="btnVakkarit_Click" />
        <asp:Button ID="btnMaaraikaset" runat="server" Text="Määräaikaiset" OnClick="btnMaaraikaset_Click" />
        <asp:Button ID="btnElse" runat="server" Text="Muut" OnClick="btnElse_Click" />
        <br />
        <asp:Button ID="btnCountAll" runat="server" Text="Laske kaikki" OnClick="btnCountAll_Click" />
        <asp:Button ID="btnCountVakkarit" runat="server" Text="Laske vakituiset" OnClick="btnCountVakkarit_Click" />
        <asp:Button ID="btnCountMaaraikaset" runat="server" Text="Laske määräaikaiset" OnClick="btnCountMaaraikaset_Click" />
        <asp:Button ID="btnCountElse" runat="server" Text="Laske muut" OnClick="btnCountElse_Click" />
        <br />
        <asp:Button ID="btnCountSalariesAll" runat="server" Text="Laske kaikkien palkat" OnClick="btnCountSalariesAll_Click" />
        <asp:Button ID="btnCountSalariesVakkarit" runat="server" Text="Laske vakituisten palkat" OnClick="btnCountSalariesVakkarit_Click" />
        <asp:Button ID="btnCountSalariesMaaraikaset" runat="server" Text="Laske määräaikaisten palkat" OnClick="btnCountSalariesMaaraikaset_Click" />
        <asp:Button ID="btnCountSalariesElse" runat="server" Text="Laske muiden palkat" OnClick="btnCountSalariesElse_Click" />
        <br />
        <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
        <br />
        <asp:GridView ID="gvData" runat="server"></asp:GridView>
    </div>
    <div id="notfound" runat="server" visible="false">
        <h1>XML MÄÄRITTELYTIEDOSTOA EI LÖYDY!</h1>
    </div>
    </form>
</body>
</html>
