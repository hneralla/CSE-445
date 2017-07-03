<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Staff.aspx.cs" Inherits="Protected_Staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1> Welcome to the Staff Page! </h1> <br />
    <h4> This page is for all staff users</h4><h5>Unfortunately, there isn't much you can do as a staff member. Please register as a regular member! You cannot reuse your staff username!</h5> <br />
    
    
    <li>
        <p >As a staff member, you have access to one of these pages:</p>
            <h6><a runat="server" href="~/Protected/Staff1">Staff Page 1</a></h6> 
            <h6><a runat="server" href="~/Protected/Staff2">Staff Page 2</a></h6>
         <p>If you do not have access to a page, you will be redirected to log in to a valid account.</p>
        </li>
    <h6> If you would like to contact the administrator, please go to the "Contact" tab in the navigation bar. </h6>
</asp:Content>

