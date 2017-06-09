<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>TryIt </h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Get WSDL Operations</h2>
            <p>
                This service returns the operation names and their input parameter and return types.
            </p>
            <p>
                Enter a WSDL URL:</p>
            <p>
                <asp:TextBox ID="textBox1" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btn_getOps" runat="server" OnClick="btn_getOps_Click" Text="Get Operations &gt;&gt;" />
            </p>
            <p>
                <asp:Label ID="lbl_opNameDefault" runat="server" Text="Operation name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_retTypeDefault" runat="server" Text="Return type"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_paramDefault" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lbl_opName" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_retType" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_paramType" runat="server"></asp:Label>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
        </div>
    </div>

</asp:Content>
