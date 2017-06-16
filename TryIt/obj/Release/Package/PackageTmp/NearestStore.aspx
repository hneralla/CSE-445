<%@ Page Title="Nearest Store" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NearestStore.aspx.cs" Inherits="TryIt.NearestStore" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            <h3>
                Find the Nearest Store Service</h3>
            <h4>
                Returns store address and details using the given ZIP code and store name.
                Uses existing Google Maps API.</h4>
            <p class="absolute">
                Method Name: findNearestStore(...)<br />
            Input parameters: string
                (zipcode), string (storeName)<br />
                Return type: string</p>
            <p class="absolute">
                Enter a valid ZIP code:&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtBox_ZIP2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; </p>
            <p class="absolute">
                &nbsp;Enter a store name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtBox_storeName" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_submit2" runat="server" OnClick="btn_submit2_Click" Text="Submit" />
            </p>
            <p class="absolute">
                <asp:Image ID="IMG2" runat="server" />
            </p>
            <p class="absolute">
                <asp:Label ID="lbl_info2" runat="server"></asp:Label>
            </p>
        
</asp:Content>
