<%@ Page Title="" Language="C#" MasterPageFile="~/JAMK-master.master" AutoEventWireup="true" CodeFile="G7934_T3c.aspx.cs" Inherits="G7934_T3c" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="start" runat="server" visible="false">
        <asp:Label ID="lblCoursesAmount" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="lblStudentsAmount" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="gvData" runat="server"></asp:GridView>
        <asp:Button ID="btnShowAllStudents" runat="server" Text="Näytä kaikki oppilaat" OnClick="btnShowAllStudents_Click" />
        <asp:Button ID="btnOrderByLastName" runat="server" Text="Listaa sukunimen mukaan" OnClick="btnOrderByLastName_Click" />
        <asp:DropDownList ID="ddlCourses" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="ddlStudents" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStudents_SelectedIndexChanged"></asp:DropDownList>
    </div>
</asp:Content>

